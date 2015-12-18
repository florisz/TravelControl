using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelControl.Storage;

namespace TravelControl.Domain
{
    public class Routes : IRoutes
    {
        private readonly IStorage _storage;
        private IStopLocations _stopLocations;

        public Routes(IStorage storage, IStopLocations stopLocations)
        {
            _storage = storage;
            _stopLocations = stopLocations;
        }

        public Route Get(string id)
        {
            return ConvertToRoute(_storage.GetRoute(id));
        }

        public IEnumerable<Route> Get(TimeSpan departureTime)
        {
            var routeEntities = _storage.GetRoutes(TimeSpanToString(departureTime));
            return ConvertRouteEntityList(routeEntities);
        }

        public IEnumerable<Route> Get(TimeSpan departureTimeFrom, TimeSpan departureTimeTo)
        {
            var routeEntities = _storage.GetRoutes(TimeSpanToString(departureTimeFrom), TimeSpanToString(departureTimeTo));
            return ConvertRouteEntityList(routeEntities);
        }

        public async Task Save(Route route)
        {
            var revision = await _storage.SaveRoute(ConvertToRouteEntity(route));
            route._rev = revision;
        }

        public void DeleteAllStatusDocuments()
        {
            _storage.DeleteAllStatusDocuments();
        }

        public int GetActiveRouteCount()
        {
            return _storage.GetActiveRouteCount();
        }

        public async Task SaveStatus(VehicleStatus status)
        {
            await _storage.SaveStatus(ConvertToVehicleStatusEntity(status));
        }

        private IEnumerable<Route> ConvertRouteEntityList(IEnumerable<RouteEntity> routeEntities)
        {
            List<Route> routeList = new List<Route>();
            foreach (var routeEntity in routeEntities)
            {
                routeList.Add(ConvertToRoute(routeEntity));
            }

            return routeList;
        }

        private Route ConvertToRoute(RouteEntity routeEntity)
        {
            var departures = new List<Departure>();
            foreach (var de in routeEntity.Departures)
            {
                var arrivalTime = StringToTimeSpan(de.PlannedArrivalTime);
                if (arrivalTime == null)
                    throw new ArgumentException("timespan planned arrival time can never be null");
                var departureTime = StringToTimeSpan(de.PlannedDepartureTime);
                departures.Add(new Departure
                    {
                        FromLocation = _stopLocations.All[de.FromLocation],
                        PlannedArrivalTime = arrivalTime.Value,
                        PlannedDepartureTime = departureTime
                });
            }

            var route = new Route
            {
                _id = routeEntity._id,
                _rev = routeEntity._rev,
                Id = routeEntity.RouteId,
                Started = routeEntity.Started,
                Finished = routeEntity.Finished,
                Departures = departures
            };

            return route;
        }

        private RouteEntity ConvertToRouteEntity(Route route)
        {
            var departures = new DepartureEntities();
            foreach (var de in route.Departures)
            {
                var actualArrivalTime = (de.ActualArrivalTime.HasValue)
                    ? TimeSpanToString(de.ActualArrivalTime.Value)
                    : null;
                var actualDepartureTime = (de.ActualDepartureTime.HasValue)
                    ? TimeSpanToString(de.ActualDepartureTime.Value)
                    : null;
                departures.Add(new DepartureEntity
                {
                    PlannedArrivalTime = TimeSpanToString(de.PlannedArrivalTime),
                    PlannedDepartureTime = de.PlannedDepartureTime.HasValue? TimeSpanToString(de.PlannedDepartureTime.Value) : "",
                    FromLocation = de.FromLocation.LocationId
                });
            }

            var routeEntity = new RouteEntity
            {
                _id = route._id,
                _rev = route._rev,
                DocType = (int) DocumentType.Route,
                RouteId = route.Id,
                Finished = route.Finished,
                Started = route.Started,
                Departures = departures
            };

            return routeEntity;
        }

        private static VehicleStatusEntity ConvertToVehicleStatusEntity(VehicleStatus status)
        {
            return new VehicleStatusEntity
                {
                    Status = (int) status.Status,
                    DocType = (int) DocumentType.VehicleStatus,
                    Location = status.Location,
                    RouteId = status.RouteId,
                    Time = TimeSpanToString(status.Time),
                    VehicleId = status.VehicleId
                };
        }

        private static string TimeSpanToString(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours,2:D2}:{timeSpan.Minutes,2:D2}";
        }

        private static TimeSpan? StringToTimeSpan(string timeSpanString)
        {
            if (string.IsNullOrEmpty(timeSpanString))
                return null;

            var parts = timeSpanString.Split(':');

            if (parts.Length != 2)
                throw new ArgumentException("Timespan string does not have two parts");

            return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
        }

    }
}
