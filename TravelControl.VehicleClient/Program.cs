using Akka.Actor;
using Akka.Configuration;
using Microsoft.Practices.Unity;
using System;
using TravelControl.Domain;
using COM = TravelControl.Common;
using TravelControl.Storage;

namespace TravelControl.VehicleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            COM.ServiceLocator.Instance.RegisterTypes(container =>
            {
                container.RegisterType<IStorage, StorageInCouchDb>(new PerResolveLifetimeManager());
                container.RegisterType<IStopLocations, StopLocations>(new ContainerControlledLifetimeManager());
                container.RegisterType<IConnections, Connections>(new ContainerControlledLifetimeManager());
                container.RegisterType<IRoutes, Routes>(new ContainerControlledLifetimeManager());
                container.RegisterType<TravelControl.Common.ITimeProvider, COM.MockTimeProvider>(
                    new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(DateTime.Now));
                container.RegisterType<VehicleSimulator>();
                container.RegisterType<DaySimulator>();
            });

            var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
    }
    remote {
        helios.tcp {
            transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
		    applied-adapters = []
		    transport-protocol = tcp
		    port = 0
		    hostname = localhost
        }
    }
}
");
            Console.WriteLine("Hit enter to start...");
            Console.ReadLine();

            // TESTING
            //var storage = COM.ServiceLocator.Instance.Resolve<IStorage>();
            //var locations = storage.GetAllStopLocations();
            //var connections = storage.GetAllConnections();

            //var routes = storage.GetRoutes("00:01");
            //foreach (var route in routes)
            //{
            //    route.Started = false;
            //    route._rev = storage.SaveRoute(route);
            //}
            //Console.ReadLine();
            // END OF TESTING

            var daySimulator = new DaySimulator();
            using (var system = ActorSystem.Create("VehicleClient", config))
            {
                daySimulator.SimulateOneDay(system);
            }
        }

    }
}
