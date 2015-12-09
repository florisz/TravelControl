using Akka.Actor;
using System;
using TravelControl.Domain;
using TravelControl.Messages;
using COM=TravelControl.Common;
using Microsoft.Practices.Unity;

namespace TravelControl.VehicleClient
{
    public class VehicleSimulator
    {
        [Dependency]
        public COM.ITimeProvider TimeProvider { get; set; }
        [Dependency]
        public IRoutes Routes { get; set; }

        public Guid VehicleId { get; private set; }
        private readonly Route _route;
        private readonly IActorRef _vehicleClient;
        private int _index;
        private bool _vehicleOnStation;

        public VehicleSimulator(IActorRef vehicleClient, Route route, Guid vehicleId)
        {
            COM.ServiceLocator.Instance.BuildUp(this.GetType(), this);
            _vehicleClient = vehicleClient;
            _route = route;
            VehicleId = vehicleId;
            _index = 0;
            _vehicleOnStation = false;
        }

        public void StartRoute()
        {
            _route.Started = true;
            Routes.Save(_route);

            var departure = _route.Departures[0];
            var startTime = MakeDate(TimeProvider.Now, departure.PlannedArrivalTime);
            _vehicleClient.Tell(new VehicleStatus
            {
                Vehicle = VehicleId.ToString(),
                DateTime = startTime,
                Location = departure.FromLocation.LocationId,
                Status = VehicleStatusEnum.StartRoute,
                RouteId = _route.Id
            });
        }

        public void EndRoute()
        {
            _route.Finished = true;
            Routes.Save(_route);

            var departure = _route.Departures[_route.Departures.Count - 1];
            var stopTime = MakeDate(TimeProvider.Now, departure.PlannedArrivalTime);
            _vehicleClient.Tell(new VehicleStatus
            {
                Vehicle = VehicleId.ToString(),
                DateTime = stopTime,
                Location = departure.FromLocation.LocationId,
                Status = VehicleStatusEnum.EndRoute,
                RouteId = _route.Id
            });
        }

        public bool SimulateRoute()
        {
            var changes = true;
            while (changes && _index < _route.Departures.Count)
            {
                changes = false;
                var departure = _route.Departures[_index];
                if (departure.PlannedArrivalTime <= TimeProvider.Now.TimeOfDay && !_vehicleOnStation)
                {
                    Console.WriteLine("Vehicle arrived at {0}", departure.PlannedArrivalTime);
                    var arrivalTime = MakeDate(TimeProvider.Now, departure.PlannedArrivalTime);
                    _vehicleClient.Tell(new VehicleStatus
                    {
                        Vehicle = VehicleId.ToString(),
                        DateTime = arrivalTime,
                        Location = departure.FromLocation.LocationId,
                        Status = VehicleStatusEnum.Stop,
                        RouteId = _route.Id
                    });
                    _vehicleOnStation = true;
                    changes = true;
                }
                if (departure.PlannedDepartureTime.HasValue && departure.PlannedDepartureTime < TimeProvider.Now.TimeOfDay)
                {
                    Console.WriteLine("Vehicle departed at {0}", departure.PlannedDepartureTime.Value);
                    var departureTime = MakeDate(TimeProvider.Now, departure.PlannedDepartureTime.Value);
                    _vehicleClient.Tell(new VehicleStatus
                    {
                        Vehicle = VehicleId.ToString(),
                        DateTime = departureTime,
                        Location = departure.FromLocation.LocationId,
                        Status = VehicleStatusEnum.Start,
                        RouteId = _route.Id
                    });
                    _vehicleOnStation = false;
                    _index++;
                    changes = true;
                }
            }

            return _index == _route.Departures.Count;
        }

        private static DateTime MakeDate(DateTime now, TimeSpan arrivalTime)
        {
            return new DateTime(now.Year, now.Month, now.Day, arrivalTime.Hours, arrivalTime.Minutes, arrivalTime.Seconds);
        }

    }

}

