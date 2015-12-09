using System;
using System.Collections.Generic;

namespace TravelControl.Domain
{
    public interface IRoutes
    {
        Route Get(string id);
        IEnumerable<Route> Get(TimeSpan departureTime);
        IEnumerable<Route> Get(TimeSpan departureTimeFrom, TimeSpan departureTimeTo);
        void Save(Route route);
        int GetActiveRouteCount();
    }
}
