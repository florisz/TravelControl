using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
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
        private Dictionary<string, VehiclesPerLocation> _vehiclesPerLocation = new Dictionary<string, VehiclesPerLocation>();

        public StatusHandler(IStopLocations stopLocations)
        {
            foreach (var location in stopLocations.All.Values)
            {
                _vehiclesPerLocation.Add(location.LocationId, new VehiclesPerLocation { StopLocation = location, Count = 0 });
            }

        }

        public void Handle(VehicleStatus vehicleStatus, Dictionary<Guid, IActorRef> mapClients, ILoggingAdapter logger)
        {
            var vehiclePerLocation = _vehiclesPerLocation[vehicleStatus.Location];
            if (vehicleStatus.Status == VehicleStatusEnum.Start)
                vehiclePerLocation.Count--;
            else
                vehiclePerLocation.Count++;

            foreach (var client in mapClients.Values)
            {
                logger.Debug("Sending message to mapClient {0}: location={1}, count={2}", client.Path, vehiclePerLocation.StopLocation.LocationId, vehiclePerLocation.Count);
                client.Tell(new LocationStatusMessage { Location = vehiclePerLocation.StopLocation.LocationId, VehicleCount = vehiclePerLocation.Count });
            }
        }
    }
}
