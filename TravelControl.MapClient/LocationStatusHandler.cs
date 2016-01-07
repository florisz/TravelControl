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

        public void Handle(VehicleStatusMessage message, List<VehiclesPerLocation> vehiclesPerLocation)
        {
            // try to find the item in the view model
            var location = vehiclesPerLocation.Where(l => l.LocationId == message.Location).FirstOrDefault();
            switch (message.Status)
            {
                case VehicleStatusEnum.Arrive:
                    if (location == null)
                    {
                        // add to the view model; can only occur if Arrive is handled before the StartRoute
                        vehiclesPerLocation.Add(CreateNewVehiclesPerLocation(message, vehiclesPerLocation));
                    }
                    else
                    {
                        location.Count++;
                    }
                    break;
                case VehicleStatusEnum.Depart:
                    // location can not be null unless messages arrive in different order
                    // do nothing because creating a new one and substracting with 1 is equivalent to doing nothing
                    if (location != null)
                    {
                        location.Count--;
                        if (location.Count == 0)
                        {
                            // delete from the view model
                            vehiclesPerLocation.Remove(location);
                        }
                    }
                    break;
                case VehicleStatusEnum.EndRoute:
                    if (location != null)
                    {
                        // delete from the view model
                        vehiclesPerLocation.Remove(location);
                    }
                    break;
            }
        }

        private VehiclesPerLocation CreateNewVehiclesPerLocation(VehicleStatusMessage message, List<VehiclesPerLocation> vehiclesPerLocation)
        {
            var stopLocation = _stopLocations.All[message.Location];
            return new VehiclesPerLocation
            {
                Count = 1,
                LocationId = message.Location,
                Location = new Location() { Latitude = stopLocation.Lattitude, Longitude = stopLocation.Longitude },
            };

        }
    }
}
