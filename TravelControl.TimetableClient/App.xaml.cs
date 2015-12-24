﻿using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using System.Windows;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.Storage;

namespace TravelControl.TimetableClient
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

            var timetable = new TimetableWindow();
            timetable.Show();
        }

    }
}