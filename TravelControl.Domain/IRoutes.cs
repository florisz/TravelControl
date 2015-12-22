using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelControl.Domain
{
    public interface IRoutes
    {
        Route Get(string id);
        IEnumerable<string> GetIds();
        IEnumerable<Route> Get(TimeSpan departureTime);
        IEnumerable<Route> Get(TimeSpan departureTimeFrom, TimeSpan departureTimeTo);
        Task Save(Route route);
        Task SaveStatus(VehicleStatus status);
        void DeleteAllStatusDocuments();
        int GetActiveRouteCount();
    }

}
