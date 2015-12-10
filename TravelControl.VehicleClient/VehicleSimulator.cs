using Akka.Actor;
using System;
using TravelControl.Domain;
using TravelControl.Messages;
using COM=TravelControl.Common;
using Microsoft.Practices.Unity;
using TravelControl.Constants;

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
        private readonly ActorSystem _system;
        private IActorRef _vehicleClient;
        private int _currentLocationIndex;
        private bool _vehicleOnStation;

        public VehicleSimulator(ActorSystem system, Route route, Guid vehicleId)
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);

            VehicleId = vehicleId;
            HasEnded = false;
            _system = system;
            _route = route;
            _currentLocationIndex = 0;
            _vehicleOnStation = false;
        }

        public void SimulateRoute()
        {
            if (!_route.Started)
            {
                StartRoute();
            }

            var changes = true;
            while (changes && _currentLocationIndex < _route.Departures.Count)
            {
                changes = false;
                var departure = _route.Departures[_currentLocationIndex];
                if (TimeProvider.CurrentTime >= departure.PlannedArrivalTime)
                {
                    Console.WriteLine("Vehicle arrived at {0}", TimeProvider.CurrentTime);

                    SendClientMessage(departure, VehicleStatusEnum.Arrive);

                    changes = true;

                    // is vehicle arrived on last location of the route?
                    if (_currentLocationIndex == _route.Departures.Count - 1)
                    {
                        EndRoute();
                        HasEnded = true;
                        break;
                    }
                }
                if (departure.PlannedDepartureTime.HasValue && TimeProvider.CurrentTime >= departure.PlannedDepartureTime.Value)
                {
                    Console.WriteLine("Vehicle departed at {0}", TimeProvider.CurrentTime);

                    SendClientMessage(departure, VehicleStatusEnum.Depart);

                    changes = true;
                }

                _currentLocationIndex++;
            }
        }

        private void StartRoute()
        {
            _vehicleClient = ConnectToTravelControlServer();

            var departure = _route.Departures[0];
            SendClientMessage(departure, VehicleStatusEnum.StartRoute);

            Console.WriteLine("Route started at {0}", departure.PlannedArrivalTime);
        }

        private void EndRoute()
        {
            var departure = _route.Departures[_route.Departures.Count - 1];
            SendClientMessage(departure, VehicleStatusEnum.EndRoute);
            HasEnded = true;
            var disconnect = _vehicleClient.GracefulStop(TimeSpan.FromSeconds(5)).Result;

            if (!disconnect)
                throw new ApplicationException("vehicleclient could not be disconnected");

            Console.WriteLine("Route ended at {0}", departure.PlannedArrivalTime);
        }

        private IActorRef ConnectToTravelControlServer()
        {
            var vehicleClient = _system.ActorOf(Props.Create<VehicleClientActor>());
            _system.ActorSelection(GlobalConstant.TravelControlServerUrl);
            vehicleClient.Tell(new VehicleClientConnectRequest { Id = Guid.NewGuid() });

            return vehicleClient;
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

