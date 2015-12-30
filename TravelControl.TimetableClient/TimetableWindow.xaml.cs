using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Unity;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.TimeTableClient.DynamicGridView;
using TravelControl.TimeTableClient.ViewModels;

namespace TravelControl.TimeTableClient
{
    /// <summary>
    /// Interaction logic for TimetableWindow.xaml
    /// </summary>
    public partial class TimeTableWindow : Window
    {
        [Dependency]
        public IStopLocations StopLocations { get; set; }
        [Dependency]
        public IConnections Connections { get; set; }
        [Dependency]
        public IRoutes Routes { get; set; }

        private RouteStatusViewModel ViewModel { get; set; }

        public TimeTableWindow(RouteStatusViewModel viewModel)
        {
            ServiceLocator.Instance.BuildUp(GetType(), this);

            InitializeComponent();
            ViewModel = viewModel;

            CreateTimer();
        }

        private void CreateTimer()
        {
            //  DispatcherTimer setup
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //DataContext = ViewModel;
            ViewModel.Routes.ElementAt(0).Attributes["1"] = "aap noot mies";
            TimeTableView.ItemsSource = ViewModel.Routes;
        }
    }


}

