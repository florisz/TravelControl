using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Akka.Util.Internal;
using TravelControl.Domain;
using TravelControl.TimeTableClient.DynamicGridView;

namespace TravelControl.TimeTableClient.ViewModels
{
    public class RouteStatusViewModel
    {
        public ColumnConfig ColumnConfig { get; set; }
        public BlockingCollection<RouteStatusView> Routes { get; private set; }
        public BlockingCollection<Route> SortedRoutes { get; set; }

        public string RouteCode
        {
            get
            {
                if (SortedRoutes != null && SortedRoutes.Count > 0)
                {
                    return SortedRoutes.ElementAt(0).Code;
                }
                return null;
            }
        }
        public RouteStatusViewModel(ColumnConfig columnConfig, BlockingCollection<RouteStatusView> routes, List<Route> sortedRoutes)
        {
            ColumnConfig = columnConfig;
            Routes = routes;
            SortedRoutes = new BlockingCollection<Route>();
            sortedRoutes.ForEach(r => SortedRoutes.Add(r));
        }

        public static RouteStatusViewModel Create(IRoutes routes, string routeCode)
        {
            var sortedRoutes = routes.GetByCode(routeCode).OrderBy(r => r.StartTime).ToList();

            var routeViews = new BlockingCollection<RouteStatusView>();
            int count;
            foreach (var route in sortedRoutes)
            {
                var vehicleStatuses = routes.GetVehicleStatuses(route.Id).OrderBy(s => s.Time);
                foreach (var status in vehicleStatuses)
                {
                    var dep = route.Departures.FirstOrDefault(d => d.FromLocation.LocationId == status.Location);
                    if (dep == null) throw new ArgumentNullException("Unknown departure");
                    if (status.Status == VehicleStatusEnum.Arrive || status.Status == VehicleStatusEnum.EndRoute)
                        dep.ActualArrivalTime = status.Time;
                    if (status.Status == VehicleStatusEnum.Depart || status.Status == VehicleStatusEnum.StartRoute)
                        dep.ActualDepartureTime = status.Time;
                }
                count = 1;
                var locationTimes = new Dictionary<string, string>();
                foreach (var departure in route.Departures)
                {
                    locationTimes.Add($"{count++}", DepartureAsView(departure));
                }
                routeViews.Add(new RouteStatusView(route.Id, locationTimes));
            }

            var columnConfig = new ColumnConfig();
            var firstRoute = sortedRoutes?.ElementAt(0);
            if (firstRoute == null) throw new ArgumentNullException(nameof(firstRoute));
            columnConfig.Columns.Add(new Column("Route", "RouteId"));
            count = 1;
            foreach (var dep in firstRoute.Departures)
            {
                columnConfig.Columns.Add(new Column($"{dep.FromLocation.Name}", $"Attributes[{count++}]"));
            }

            return new RouteStatusViewModel(columnConfig, routeViews, sortedRoutes);
        }

        public static string DepartureAsView(Departure dep)
        {
            return
                $"{dep.PlannedArrivalTime.ToString()}   {dep.PlannedDepartureTime.ToString()}\n{dep.ActualArrivalTime.ToString()}   {dep.ActualDepartureTime.ToString()}";
        }
    }

    public class RouteStatusView
    {
        public RouteStatusView(string routeId, Dictionary<string, string> attributes)
        {
            RouteId = routeId;
            Attributes = attributes;
        }

        public string RouteId { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
