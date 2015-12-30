using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using Topshelf;
using TravelControl.Common;
using TravelControl.Domain;
using TravelControl.Storage;
using ITimeProvider = TravelControl.Common.ITimeProvider;

namespace TravelControlService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<MyActorService>(serviceConfiguration =>
                {
                    serviceConfiguration.ConstructUsing(n => new MyActorService());
                    serviceConfiguration.WhenStarted(service => service.Start());
                    serviceConfiguration.WhenStopped(service => service.Stop());
                    //continue and restart directives are also available
                });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.UseAssemblyInfoForServiceInfo();
            });
        }
    }

    /// <summary>
    /// This class acts as an interface between your application and TopShelf
    /// </summary>
    public class MyActorService
    {
        private ActorSystem _mySystem;
        private IActorRef _myActor;

        public void Start()
        {
            // this is where you setup your actor system and other things
            var config = ConfigurationFactory.ParseString(@"
akka {  
    log-config-on-start = off
    stdout-loglevel = DEBUG
    loglevel = DEBUG
    loggers = [""Akka.Logger.NLog.NLogLogger, Akka.Logger.NLog""]
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
        debug {
              receive = off 
              autoreceive = off
              lifecycle = off
              event-stream = off
              unhandled = on
              fsm = off
        }
    }
    remote {
        log-sent-messages = on
        helios.tcp {
            transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
            applied-adapters = []
            transport-protocol = tcp
            port = 8082
            hostname = localhost
        }
    }
}
");
            ServiceLocator.Instance.RegisterTypes(container =>
                {
                    container.RegisterType<IStopLocations, StopLocations>(new ContainerControlledLifetimeManager());
                    container.RegisterType<IStorage, StorageInCouchDb>(new PerThreadLifetimeManager());
                    container.RegisterType<IConnections, Connections>(new ContainerControlledLifetimeManager());
                    container.RegisterType<IRoutes, Routes>(new ContainerControlledLifetimeManager());
                    container.RegisterType<IStatusHandler, StatusHandler>(new PerResolveLifetimeManager());
                    container.RegisterType<TravelControl.Common.ITimeProvider, MockTimeProvider>(new PerResolveLifetimeManager());
                });

            _mySystem = ActorSystem.Create("TravelControl", config);

            var logger = Logging.GetLogger(_mySystem, this);
            logger.Debug("Windows service TravelControl Central Service is starting...");
            
            // preread all static data for connections and stoplocations
            var connections = ServiceLocator.Instance.Resolve<IConnections>();
            var allConnections = connections.All;

            // TESTING
            // END OF TESTING
            logger.Debug("Windows service TravelControl static data initialised...");

            _myActor = _mySystem.ActorOf<ServerActor>("TravelControl");

            logger.Debug("Windows service TravelControl Central Service is started");
        }

        public void Stop()
        {
            var logger = Logging.GetLogger(_mySystem, this);
            logger.Debug("Windows service TravelControl Central Service is stopping...");

            // wait for actor to meltdown gracefully (but no longer than 5 seconds)
            var shutdown = _myActor.GracefulStop(new TimeSpan(0, 0, 5));
            shutdown.Wait();

            // this is where you stop your actor system
            _mySystem.Shutdown();

            logger.Debug("Windows service TravelControl Central Service stopped");
        }
    }
}
