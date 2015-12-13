using Akka.Actor;
using System;
using TravelControl.Domain;
using TravelControl.Messages;
using COM=TravelControl.Common;
using Microsoft.Practices.Unity;
using TravelControl.Constants;
using static System.Console;

namespace TravelControl.VehicleClient
{
    public class VehicleSimulator
    {
        [Dependency]
        public COM.ITimeProvider TimeProvider { get; set; }
        [Dependency]
        public IRoutes Routes { get; set; }

        public int VehicleId { get; }
        public bool HasEnded { get; private set; }

        private readonly Route _route;
        private readonly IActorRef _vehicleClient;
        private int _currentLocationIndex;

        public VehicleSimulator(IActorRef client, Route route, int vehicleId)
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);

            VehicleId = vehicleId;
            HasEnded = false;
            _vehicleClient = client;
            _route = route;
            _currentLocationIndex = 0;
        }

        public void SimulateRoute()
        {
            var changes = true;
            while (changes && _currentLocationIndex < _route.Departures.Count)
            {
                changes = false;
                var departure = _route.Departures[_currentLocationIndex];
                if (TimeProvider.CurrentTime >= departure.PlannedArrivalTime)
                {
                    WriteLine("Vehicle {0} arrived at {1}", VehicleId, TimeProvider.CurrentTime);

                    SendClientMessage(departure, VehicleStatusEnum.Arrive);

                    changes = true;

                    // is vehicle arrived on last location of the route?
                    if (_currentLocationIndex == _route.Departures.Count - 1)
                    {
                        HasEnded = true;
                        return;
                    }
                }
                if (departure.PlannedDepartureTime.HasValue && TimeProvider.CurrentTime >= departure.PlannedDepartureTime.Value)
                {
                    WriteLine("Vehicle {0} departed at {1}", VehicleId, TimeProvider.CurrentTime);

                    SendClientMessage(departure, VehicleStatusEnum.Depart);

                    changes = true;
                }

                if (changes)
                {
                    _currentLocationIndex++;
                }
            }
        }

        public void StartRoute()
        {
            var departure = _route.Departures[0];
            SendClientMessage(departure, VehicleStatusEnum.StartRoute);

            WriteLine("Route started at {0}", departure.PlannedArrivalTime);
        }

        public void EndRoute()
        {
            var departure = _route.Departures[_route.Departures.Count - 1];
            SendClientMessage(departure, VehicleStatusEnum.EndRoute);

            WriteLine("Route ended at {0}", departure.PlannedArrivalTime);
        }

        private void SendClientMessage(Departure departure, VehicleStatusEnum status)
        {
            _vehicleClient.Tell(new VehicleStatus
            {
                Location = departure.FromLocation.LocationId,
                Vehicle = VehicleId.ToString(),
                RouteId = _route._id,
                Status = status,
                Time = TimeProvider.CurrentTime,
            });
        }

    }

}

