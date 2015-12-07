using System.Collections.Generic;
using TravelControl.MapClient.ViewModels;
using TravelControl.Messages;

namespace TravelControl.MapClient
{
    public interface ILocationStatusHandler
    {
        void Handle(LocationStatusMessage message, List<VehiclesPerLocation> vehiclesPerLocation);
    }
}
