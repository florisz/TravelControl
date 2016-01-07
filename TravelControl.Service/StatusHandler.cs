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
        private readonly IRoutes _routes;

        public StatusHandler(IStopLocations stopLocations, IRoutes routes)
        {
            _routes = routes;
        }

        public async void Handle(VehicleStatusMessage vehicleStatus, Dictionary<Guid, MapClient> mapClients, Dictionary<Guid, TimeTableClient> timeTableClients, ILoggingAdapter logger)
        {
            // send message as is through to all attached timeTableClients
            foreach (var client in timeTableClients.Values)
            {
                if (vehicleStatus.RouteCode == client.RouteCode)
                {
                    client.ClientRef.Tell(vehicleStatus);
                }
            }

            // send message as is through to all attached MapClients
            foreach (var client in mapClients.Values)
            {
                if (vehicleStatus.RouteCode == client.RouteCode)
                {
                    client.ClientRef.Tell(vehicleStatus);
                }
            }

            await SaveRoute(vehicleStatus);
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
