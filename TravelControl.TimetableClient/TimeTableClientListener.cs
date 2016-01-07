using System;
using Akka.Actor;
using Akka.Configuration;
using NLog;
using TravelControl.Constants;
using TravelControl.Messages;
using TravelControl.TimeTableClient.ViewModels;

namespace TravelControl.TimeTableClient
{
    public class TimeTableClientListener
    {
        private IActorRef _timetableClient;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private RouteStatusViewModel ViewModel { get; set; }

        public TimeTableClientListener(RouteStatusViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public void Run()
        {
            var config = ConfigurationFactory.ParseString(@"
akka {  
    log-config-on-start = off
    stdout-loglevel = DEBUG
    loglevel = DEBUG
    loggers = [""Akka.Logger.NLog.NLogLogger, Akka.Logger.NLog""]
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
            var system = ActorSystem.Create("TimeTableClient", config);

            Logger.Debug("Timetable client created, and will connect to server...");

            _timetableClient = ConnectToTravelControlServer(system, ViewModel);

            Logger.Debug("Timetable client has connected to server.");

            // now wait for messages from the server till doomsday
            system.AwaitTermination();
        }

        private static IActorRef ConnectToTravelControlServer(ActorSystem system, RouteStatusViewModel viewModel)
        {
            var timeTableClient = system.ActorOf(Props.Create<TimeTableClientActor>(viewModel));
            system.ActorSelection(GlobalConstant.TravelControlServerUrl);
            timeTableClient.Tell(new TimeTableClientConnectRequest { Id = Guid.NewGuid(), RouteCode = viewModel.RouteCode });

            return timeTableClient;
        }
    }
}
