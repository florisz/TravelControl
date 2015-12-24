using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Unity;
using TravelControl.Common;
using TravelControl.Domain;

namespace TravelControl.TimetableClient
{
    /// <summary>
    /// Interaction logic for TimetableWindow.xaml
    /// </summary>
    public partial class TimetableWindow : Window
    {
        [Dependency]
        public IStopLocations StopLocations { get; set; }
        [Dependency]
        public IConnections Connections { get; set; }
        [Dependency]
        public IRoutes Routes { get; set; }

        public TimetableWindow()
        {
            ServiceLocator.Instance.BuildUp(GetType(), this);

            InitializeComponent();
            DataContext = CreateViewModel();
        }

        private ViewModel CreateViewModel()
        {
            var sortedRoutes = Routes.GetByCode("000004").OrderBy(r => r.StartTime);

            var routes = new List<RouteView>();
            int count;
            foreach (var route in sortedRoutes)
            {
                var vehicleStatuses = Routes.GetVehicleStatuses(route.Id).OrderBy(s => s.Time);
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
                foreach (var dep in route.Departures)
                {
                    locationTimes.Add($"{count++}",$"{dep.PlannedArrivalTime.ToString()}   {dep.PlannedDepartureTime.ToString()}\n{dep.ActualArrivalTime.ToString()}   {dep.ActualDepartureTime.ToString()}");
                }
                routes.Add(new RouteView(route.Id, locationTimes));
            }

            var columnConfig = new ColumnConfig();
            var firstRoute = sortedRoutes?.ElementAt(0);
            if (firstRoute == null) throw new ArgumentNullException(nameof(firstRoute));
            columnConfig.Columns.Add(new Column("Route", "RouteId"));
            count = 1;
            foreach (var dep in firstRoute.Departures)
            {
                columnConfig.Columns.Add(new Column($"{dep.FromLocation.Name}", $"Attributes[{count++}]" ));
            }

            return new ViewModel { ColumnConfig = columnConfig, Routes = routes };
        }
    }

    public class ViewModel
    {
        public ColumnConfig ColumnConfig { get; set; }
        public IEnumerable<RouteView> Routes { get; set; }
    }
    
    public class ColumnConfig
    {
        public ColumnConfig()
        {
            Columns = new List<Column>();
        }
        public List<Column> Columns { get; set; }
    }

    public class Column
    {
        public Column(string header, string dataField)
        {
            Header = header;
            DataField = dataField;
        }
        public string Header { get; set; }
        public string DataField { get; set; }
    }

    public class RouteView
    {
        public RouteView(string routeId, Dictionary<string, string> attributes)
        {
            RouteId = routeId;
            Attributes = attributes;
        }
        public string RouteId { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}

