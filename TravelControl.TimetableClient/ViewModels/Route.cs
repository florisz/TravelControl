using System;
using System.Collections.Generic;

namespace TravelControl.TimetableClient.ViewModels
{
    public class RouteStatusView
    {
        public List<string> LocationNames { get; set; } 
        public List<List<LocationStatusView>> LocationStatusList { get; set; } 
    }

    public class LocationStatusView
    {
        public string LocationCode { get; set; }
        public TimeSpan PlannedArrival { get; set; }
        public TimeSpan PlannedDeparture { get; set; }
        public TimeSpan ActualArrival { get; set; }
        public TimeSpan ActualDeparture { get; set; }
    }
}
