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
        IEnumerable<RouteEntity> GetRoutesByCode(string code);
        IEnumerable<RouteEntity> GetRoutesByDepartureTime(string time);
        IEnumerable<RouteEntity> GetRoutesByDepartureTime(string timeFrom, string timeTo);
        IEnumerable<VehicleStatusEntity> GetVehicleStatusesByRouteId(string routeId);
        Task<string> SaveRoute(RouteEntity route);
        int GetActiveRouteCount();

        List<VehicleStatusEntity> GetStatus(string routeId);
        Task SaveStatus(VehicleStatusEntity vehicleStatusEntity);
        void DeleteAllStatusDocuments();
    }
}
