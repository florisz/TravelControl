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

        public Guid VehicleId { get; }
        public bool HasEnded { get; private set; }

        private readonly Route _route;
        private readonly IActorRef _vehicleClient;
        private int _index;
        private bool _vehicleOnStation;

        public VehicleSimulator(IActorRef vehicleClient, Route route, Guid vehicleId)
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);

            VehicleId = vehicleId;
            HasEnded = false;
            _vehicleClient = vehicleClient;
            _route = route;
            _index = 0;
            _vehicleOnStation = false;
        }

        public void StartRoute()
        {
            _route.Started = true;
            var departure = _route.Departures[0];
            SendClientMessage(departure, VehicleStatusEnum.StartRoute, departure.PlannedArrivalTime);

            Console.WriteLine("Route started at {0}", departure.PlannedArrivalTime);
        }

        public void EndRoute()
        {
            _route.Finished = true;
            var departure = _route.Departures[_route.Departures.Count - 1];
            SendClientMessage(departure, VehicleStatusEnum.EndRoute, departure.PlannedArrivalTime);
            HasEnded = true;

            Console.WriteLine("Route ended at {0}", departure.PlannedArrivalTime);
        }

        public void SimulateRoute()
        {
            var changes = true;
            while (changes && _index < _route.Departures.Count)
            {
                changes = false;
                var departure = _route.Departures[_index];
                if (departure.PlannedArrivalTime <= TimeProvider.Now.TimeOfDay && !_vehicleOnStation)
                {
                    Console.WriteLine("Vehicle arrived at {0}", departure.PlannedArrivalTime);

                    SendClientMessage(departure, VehicleStatusEnum.Stop, departure.PlannedArrivalTime);

                    _vehicleOnStation = true;
                    changes = true;
                }
                if (departure.PlannedDepartureTime.HasValue && departure.PlannedDepartureTime < TimeProvider.Now.TimeOfDay)
                {
                    Console.WriteLine("Vehicle departed at {0}", departure.PlannedDepartureTime.Value);

                    SendClientMessage(departure, VehicleStatusEnum.Start, departure.PlannedDepartureTime.Value);

                    _vehicleOnStation = false;
                    _index++;
                    changes = true;
                }
            }
        }

        private void SendClientMessage(Departure departure, VehicleStatusEnum status, TimeSpan time)
        {
            _vehicleClient.Tell(new VehicleStatus
            {
                Location = departure.FromLocation.LocationId,
                Vehicle = VehicleId.ToString(),
                RouteId = _route.Id,
                Status = status,
                DateTime = MakeDate(TimeProvider.Now, time),
            });
        }

        private static DateTime MakeDate(DateTime now, TimeSpan arrivalTime)
        {
            return new DateTime(now.Year, now.Month, now.Day, arrivalTime.Hours, arrivalTime.Minutes, arrivalTime.Seconds);
        }

    }

}

