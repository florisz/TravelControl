using System;
using System.Collections.Generic;

namespace TravelControl.Domain
{
    public interface IRoutes
    {
        Route Get(string Id);
        IEnumerable<Route> Get(TimeSpan DepartureTime);
        IEnumerable<Route> Get(TimeSpan DepartureTimeFrom, TimeSpan DepartureTimeTo);
        void Save(Route Route);
    }
}
