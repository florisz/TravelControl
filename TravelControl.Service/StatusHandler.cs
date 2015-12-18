using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IRoutes _routes;

        public StatusHandler(IStopLocations stopLocations, IRoutes routes)
        {
            _routes = routes;
            _vehiclesPerLocation = new Dictionary<string, VehiclesPerLocation>();
            foreach (var location in stopLocations.All.Values)
            {
                _vehiclesPerLocation.Add(location.LocationId, new VehiclesPerLocation { StopLocation = location, Count = 0 });
            }
        }

        public async void Handle(VehicleStatusMessage vehicleStatus, Dictionary<Guid, IActorRef> mapClients, ILoggingAdapter logger)
        {
            var vehiclePerLocationNew = _vehiclesPerLocation[vehicleStatus.Location];
            switch (vehicleStatus.Status)
            {
                case VehicleStatusEnum.StartRoute:
                    // increment the number of vehicles on this location
                    vehiclePerLocationNew.Count++;

                    // send new status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }

                    await SaveRoute(vehicleStatus);
                    break;
                case VehicleStatusEnum.EndRoute:
                    // decrement the number of vehicles on this location
                    vehiclePerLocationNew.Count--;

                    // send status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }

                    await SaveRoute(vehicleStatus);
                    break;
                case VehicleStatusEnum.Depart:
                    await SaveRoute(vehicleStatus);
                    break;
                case VehicleStatusEnum.Arrive:
                    // increment the number of vehicles on the new location
                    vehiclePerLocationNew.Count++;

                    // send status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }

                    await SaveRoute(vehicleStatus);
                    break;
            }
        }


        private async Task SaveRoute(VehicleStatusMessage vehicleStatus)
        {
            var status = new VehicleStatus
            {
                RouteId = vehicleStatus.RouteId,
                VehicleId = vehicleStatus.VehicleId,
                Time = vehicleStatus.Time,
                Location = vehicleStatus.Location,
                Status = vehicleStatus.Status
            };
            await _routes.SaveStatus(status);
        }
    }
}
