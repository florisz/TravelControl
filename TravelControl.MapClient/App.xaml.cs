﻿using Microsoft.Practices.Unity;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.Storage;

namespace TravelControl.MapClient
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
                container.RegisterType<ILocationStatusHandler, LocationStatusHandler>(new ContainerControlledLifetimeManager());
            });

            var routeCode = ConfigurationManager.AppSettings["RouteCode"];
            if (string.IsNullOrEmpty(routeCode)) routeCode = "999999";

            var mapClientListener = new MapClientListener(routeCode);
            Task.Run(() => mapClientListener.Run());
            
            var mapClient = new MapClientWindow(mapClientListener.VehiclesPerLocation);
            mapClient.Show();

        }
    }
}
