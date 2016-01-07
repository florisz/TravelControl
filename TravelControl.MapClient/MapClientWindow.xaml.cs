using Microsoft.Maps.MapControl.WPF;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.MapClient.ViewModels;

namespace TravelControl.MapClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MapClientWindow : Window
    {
        [Dependency]
        public IStopLocations StopLocations { get; set; }
        [Dependency]
        public IConnections Connections{ get; set; }
        [Dependency]
        public IRoutes Routes { get; set; }

        private List<VehiclesPerLocation> _listVehiclesPerLocation;

        public MapClientWindow(List<VehiclesPerLocation> listVehiclesPerLocation)
        {
            ServiceLocator.Instance.BuildUp(GetType(), this);

            InitializeComponent();

            InitializeMap();

            DataContext = new VehiclesPerLocationViewModel();

            _listVehiclesPerLocation = listVehiclesPerLocation;

            //Set focus on the map
            myMap.Focus();

            //  DispatcherTimer setup
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }

        private void InitializeMap()
        {
            MapLayer imageLayer = new MapLayer();

            //The map location to place the image at
            foreach (var stopLocation in StopLocations.All.Values)
            { 
                Location location = new Location() { Latitude = stopLocation.Lattitude, Longitude = stopLocation.Longitude };
                //Center the image around the location specified
                PositionOrigin position = PositionOrigin.Center;

                var ellipse = new Ellipse
                {
                    Height = 10,
                    Width = 10,
                    Fill = new SolidColorBrush { Color = Colors.DarkRed },
                    Stroke = new SolidColorBrush { Color = Colors.Black },
                    StrokeThickness = 1,
                    Uid = stopLocation.LocationId,
                };
                ellipse.MouseEnter += new MouseEventHandler(ellipse_MouseEnter);
                ellipse.MouseLeave += new MouseEventHandler(ellipse_MouseLeave);

                imageLayer.AddChild(ellipse, location, position);
            };

            foreach (var connection in Connections.All)
            {
                var line = new MapPolyline
                {
                    Stroke = new SolidColorBrush { Color = Colors.DarkRed },
                    StrokeThickness = 2,
                    Locations = new LocationCollection
                    {
                        new Location(connection.Item1.Lattitude, connection.Item1.Longitude),
                        new Location(connection.Item2.Lattitude, connection.Item2.Longitude),
                    },
                };
                myMap.Children.Add(line);
            };

            //Add the image layer to the map
            myMap.Children.Add(imageLayer);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var viewModelControl = FindVisualChildByName<MapItemsControl>(LayoutRoot, "VehiclesPerLocationItemsControl");
            if (viewModelControl != null)
            {
                var vehiclesPerLocation = new ObservableCollection<VehiclesPerLocation>();
                foreach (var loc in _listVehiclesPerLocation)
                {
                    vehiclesPerLocation.Add(loc);
                }
                viewModelControl.ItemsSource = vehiclesPerLocation;
            }
        }

        private void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            stopLocationPopup.IsOpen = false;
        }

        private void ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            var ellipse = e.Source as Ellipse;
            stopLocationPopup.PlacementTarget = ellipse;
            stopLocationPopup.Placement = PlacementMode.MousePoint;
            stopLocationPopup.IsOpen = true;
            Panel panel = FindVisualChildByName<Panel>(stopLocationPopup.Child, "stopLocationPanel");
            TextBlock textBlock = FindVisualChildByName<TextBlock>(panel, "stopLocationPopupText");
            if (textBlock != null)
            {
                var stopLocation = StopLocations.All[ellipse.Uid];
                textBlock.Text = string.Format("[{0}]: {1}", stopLocation.LocationId, stopLocation.Name);
            }
        }

        private T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            var total = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < total; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                string controlName = child.GetValue(Control.NameProperty) as string;

                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);

                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    }
}
