﻿using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.Storage;
using TravelControl.TimeTableClient.ViewModels;

namespace TravelControl.TimeTableClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceLocator.Instance.RegisterTypes(container =>
            {
                container.RegisterType<IStorage, StorageInCouchDb>(new PerResolveLifetimeManager());
                container.RegisterType<IStopLocations, StopLocations>(new ContainerControlledLifetimeManager());
                container.RegisterType<IConnections, Connections>(new ContainerControlledLifetimeManager());
                container.RegisterType<IRoutes, Routes>(new ContainerControlledLifetimeManager());
                container.RegisterType<ITimeProvider, MockTimeProvider>(new PerResolveLifetimeManager());
            });

            var routeService = ServiceLocator.Instance.Resolve<IRoutes>();

            var routeCode = ConfigurationManager.AppSettings["RouteCode"];
            if (string.IsNullOrEmpty(routeCode)) routeCode = "999999";
            var viewModel = RouteStatusViewModel.Create(routeService, routeCode);

            var timeTableClientListener = new TimeTableClientListener(viewModel);
            Task.Run(() => timeTableClientListener.Run());

            var timetable = new TimeTableWindow(viewModel);
            timetable.Show();
        }

    }
}
