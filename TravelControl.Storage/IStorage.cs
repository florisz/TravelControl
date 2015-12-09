using System;
using System.Collections.Generic;

namespace TravelControl.Storage
{
    public interface IStorage
    {
        // return list of all connections, list is short enough to put them all in one list
        IEnumerable<ConnectionEntity> GetAllConnections();

        // return list of all stop locations, list is short enough to put them all in one list
        IEnumerable<StopLocationEntity> GetAllStopLocations();

        // Route interface is somewhat more complex because we can't get the list in memory (too big)
        RouteEntity GetRoute(string Id);
        IEnumerable<RouteEntity> GetRoutes(string DepartureTime);
        IEnumerable<RouteEntity> GetRoutes(string DepartureTimeFrom, string DepartureTimeTo);
        string SaveRoute(RouteEntity Route);
        int GetActiveRouteCount();
    }
}
