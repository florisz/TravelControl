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

        public VehicleSimulator(IActorRef client, Route route, int vehicleId)
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);

            VehicleId = vehicleId;
            HasEnded = false;
            _vehicleClient = client;
            _route = route;
        }

        public void SimulateRoute()
        {
            var index = 0;
            while (index < _route.Departures.Count)
            {
                var departure = _route.Departures[index];
                if (TimeProvider.CurrentTime >= departure.PlannedArrivalTime)
                {
                    // Vehicle arrived at the current departure?
                    if (!departure.ActualArrivalTime.HasValue)
                    {
                        //WriteLine("Vehicle {0} arrived at {1}", VehicleId, TimeProvider.CurrentTime);
                        departure.ActualArrivalTime = TimeProvider.CurrentTime;
                        SendClientMessage(departure, VehicleStatusEnum.Arrive);

                        // has vehicle arrived on last location of the route?
                        if (index == _route.Departures.Count - 1)
                        {
                            HasEnded = true;
                            return;
                        }
                    }
                }
                if (departure.PlannedDepartureTime.HasValue && TimeProvider.CurrentTime >= departure.PlannedDepartureTime.Value)
                {
                    // Vehicle departs from the current departure?
                    if (!departure.ActualDepartureTime.HasValue)
                    {
                        //WriteLine("Vehicle {0} departed at {1}", VehicleId, TimeProvider.CurrentTime);

                        departure.ActualDepartureTime = TimeProvider.CurrentTime;
                        SendClientMessage(departure, VehicleStatusEnum.Depart);
                    }
                }

                index++;
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
            _vehicleClient.Tell(new VehicleStatusMessage
            {
                Location = departure.FromLocation.LocationId,
                VehicleId = VehicleId.ToString(),
                RouteId = _route.Id,
                RouteCode = _route.Code,
                Status = status,
                Time = TimeProvider.CurrentTime,
            });
        }

    }

}

