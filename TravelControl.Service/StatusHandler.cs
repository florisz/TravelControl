using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelControl.Domain;
using TravelControl.Messages;

namespace TravelControlService
{
    public class VehiclesPerLocation
    {
        public int Count { get; set; }
        public StopLocation StopLocation { get; set; }
    }

    public class StatusHandler : IStatusHandler
    {
        private readonly Dictionary<string, VehiclesPerLocation> _vehiclesPerLocation;
        private readonly Dictionary<string, string> _vehicleIsOnLocation;
        private readonly IRoutes _routes;

        public StatusHandler(IStopLocations stopLocations, IRoutes routes)
        {
            _routes = routes;
            _vehicleIsOnLocation = new Dictionary<string, string>();
            _vehiclesPerLocation = new Dictionary<string, VehiclesPerLocation>();
            foreach (var location in stopLocations.All.Values)
            {
                _vehiclesPerLocation.Add(location.LocationId, new VehiclesPerLocation { StopLocation = location, Count = 0 });
            }
    }

    public void Handle(VehicleStatus vehicleStatus, Dictionary<Guid, IActorRef> mapClients, ILoggingAdapter logger)
        {
            var vehiclePerLocationNew = _vehiclesPerLocation[vehicleStatus.Location];
            var currentLocation = vehicleStatus.Location;
            switch (vehicleStatus.Status)
            {
                case VehicleStatusEnum.StartRoute:
                    // keep track of the location of the vehicle
                    _vehicleIsOnLocation[vehicleStatus.Vehicle] = vehicleStatus.Location;

                    // increment the number of vehicles on this location
                    vehiclePerLocationNew.Count++;

                    SaveRoute(vehicleStatus);

                    // send new status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }
                    break;
                case VehicleStatusEnum.EndRoute:
                    // the vehicle can be removed from the current list of vehicles
                    _vehicleIsOnLocation.Remove(vehicleStatus.Vehicle);

                    // decrement the number of vehicles on this location
                    vehiclePerLocationNew.Count--;

                    SaveRoute(vehicleStatus);

                    // send status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }
                    break;
                case VehicleStatusEnum.Depart:
                    SaveRoute(vehicleStatus);
                    break;
                case VehicleStatusEnum.Arrive:
                    // decrement the number of vehicles on the old location
                    var oldLocation = _vehicleIsOnLocation[vehicleStatus.Vehicle];
                    var vehiclePerLocationOld = _vehiclesPerLocation[oldLocation];
                    vehiclePerLocationOld.Count--;

                    // move vehicle to new location
                    _vehicleIsOnLocation[vehicleStatus.Vehicle] = currentLocation;

                    // increment the number of vehicles on the new location
                    vehiclePerLocationNew.Count++;

                    SaveRoute(vehicleStatus);

                    // send status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationOld.StopLocation.LocationId, VehicleCount = vehiclePerLocationOld.Count });
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }
                    break;
            }
        }

        private void SaveRoute(VehicleStatus vehicleStatus)
        {
            var route = _routes.Get(vehicleStatus.RouteId);
            var departure = route.Departures.FirstOrDefault(d => d.FromLocation.LocationId == vehicleStatus.Location);
            if (departure == null)
                throw new ApplicationException($"Unknown departure in save route for location {vehicleStatus.Location} and document {route._id}");

            var time = vehicleStatus.Time;
            if (vehicleStatus.Status == VehicleStatusEnum.Depart || vehicleStatus.Status == VehicleStatusEnum.StartRoute)
            {
                departure.ActualDepartureTime = time;
                if (vehicleStatus.Status == VehicleStatusEnum.StartRoute)
                {
                    route.Started = true;
                    route.Finished = false;
                }
            }
            else if (vehicleStatus.Status == VehicleStatusEnum.Arrive || vehicleStatus.Status == VehicleStatusEnum.EndRoute)
            {
                departure.ActualArrivalTime = time;
                if (vehicleStatus.Status == VehicleStatusEnum.EndRoute)
                {
                    route.Finished = true;
                }
            }

            _routes.Save(route);
        }
    }
}
