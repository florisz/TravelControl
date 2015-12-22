using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelControl.Storage
{
    public interface IStorage
    {
        // return list of all connections, list is short enough to put them all in one list
        IEnumerable<ConnectionEntity> GetAllConnections();

        // return list of all stop locations, list is short enough to put them all in one list
        IEnumerable<StopLocationEntity> GetAllStopLocations();

        // Route interface is somewhat more complex because we can't get the list in memory (too big)
        RouteEntity GetRoute(string id);
        IEnumerable<string> GetIds();
        IEnumerable<RouteEntity> GetRoutes(string departureTime);
        IEnumerable<RouteEntity> GetRoutes(string departureTimeFrom, string departureTimeTo);
        Task<string> SaveRoute(RouteEntity route);
        int GetActiveRouteCount();

        List<VehicleStatusEntity> GetStatus(string vehicleId);
        Task SaveStatus(VehicleStatusEntity vehicleStatusEntity);
        void DeleteAllStatusDocuments();
    }
}
