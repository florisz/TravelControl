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
        private readonly Dictionary<string, VehiclesPerLocation> _vehiclesPerLocation = new Dictionary<string, VehiclesPerLocation>();
        private readonly Dictionary<string, string> _vehicleOnLocation = new Dictionary<string, string>();
         
        public StatusHandler(IStopLocations stopLocations)
        {
            foreach (var location in stopLocations.All.Values)
            {
                _vehiclesPerLocation.Add(location.LocationId, new VehiclesPerLocation { StopLocation = location, Count = 0 });
            }

        }

        public void Handle(VehicleStatus vehicleStatus, Dictionary<Guid, IActorRef> mapClients, ILoggingAdapter logger)
        {
            switch (vehicleStatus.Status)
            {
                case VehicleStatusEnum.StartRoute:
                    {
                        _vehicleOnLocation[vehicleStatus.Vehicle] = vehicleStatus.Location;
                        var vehiclePerLocation = _vehiclesPerLocation[vehicleStatus.Location];
                        vehiclePerLocation.Count++;

                        // send status to all attached mapClients
                        foreach (var client in mapClients.Values)
                        {
                            client.Tell(new LocationStatusMessage { Location = vehiclePerLocation.StopLocation.LocationId, VehicleCount = vehiclePerLocation.Count });
                        }
                    }
                    break;
                case VehicleStatusEnum.EndRoute:
                    {
                        _vehicleOnLocation.Remove(vehicleStatus.Vehicle);

                        var vehiclePerLocation = _vehiclesPerLocation[vehicleStatus.Location];
                        vehiclePerLocation.Count--;

                        // send status to all attached mapClients
                        foreach (var client in mapClients.Values)
                        {
                            client.Tell(new LocationStatusMessage { Location = vehiclePerLocation.StopLocation.LocationId, VehicleCount = vehiclePerLocation.Count });
                        }
                    }
                    break;
                case VehicleStatusEnum.Stop:
                    // decrement counter on old location
                    var currentLocation = _vehicleOnLocation[vehicleStatus.Vehicle];
                    var vehiclePerLocationOld = _vehiclesPerLocation[currentLocation];
                    vehiclePerLocationOld.Count--;

                    // move vehicle to new location
                    _vehicleOnLocation[vehicleStatus.Vehicle] = vehicleStatus.Location;

                    // increment counter on new location
                    var vehiclePerLocationNew = _vehiclesPerLocation[vehicleStatus.Location];
                    vehiclePerLocationNew.Count++;

                    // send status to all attached mapClients
                    foreach (var client in mapClients.Values)
                    {
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationOld.StopLocation.LocationId, VehicleCount = vehiclePerLocationOld.Count });
                        client.Tell(new LocationStatusMessage { Location = vehiclePerLocationNew.StopLocation.LocationId, VehicleCount = vehiclePerLocationNew.Count });
                    }
                    break;
            }
        }
    }
}
