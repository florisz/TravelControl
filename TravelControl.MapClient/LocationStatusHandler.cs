using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Linq;
using TravelControl.Domain;
using TravelControl.MapClient.ViewModels;
using TravelControl.Messages;

namespace TravelControl.MapClient
{
    public class LocationStatusHandler : ILocationStatusHandler
    {
        private readonly IStopLocations _stopLocations;

        public LocationStatusHandler(IStopLocations stopLocations)
        {
            _stopLocations = stopLocations;
        }

        public void Handle(LocationStatusMessage message, List<VehiclesPerLocation> vehiclesPerLocation)
        {
            // try to find the item in the view model
            var location = vehiclesPerLocation.Where(l => l.LocationId == message.Location).FirstOrDefault();
            if (message.VehicleCount > 0)
            {
                if (location == null)
                {
                    // add to the view model
                    var stopLocation = _stopLocations.All[message.Location];
                    vehiclesPerLocation.Add(new VehiclesPerLocation
                    {
                        Count = message.VehicleCount,
                        LocationId = message.Location,
                        Location = new Location() { Latitude = stopLocation.Lattitude, Longitude = stopLocation.Longitude },
                    });
                }
                else
                {
                    // update the count in the view model
                    location.Count = message.VehicleCount;
                }
            }
            else
            {
                // delete from the view model
                vehiclesPerLocation.Remove(location);
            }
        }
    }
}
