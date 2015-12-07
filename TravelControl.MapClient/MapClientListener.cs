using Akka.Actor;
using Akka.Configuration;
using System.Collections.Generic;
using TravelControl.GlobalConstants;
using TravelControl.MapClient.ViewModels;
using TravelControl.Messages;

namespace TravelControl.MapClient
{
    public class MapClientListener
    {
        private IActorRef _mapClient;
        List<VehiclesPerLocation> _vehiclesPerLocation;

        public MapClientListener()
        {
            _vehiclesPerLocation = new List<VehiclesPerLocation>();
        }

        public void Run()
        {
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
            var system = ActorSystem.Create("MapClient", config);
            _mapClient = ConnectToTravelControlServer(system, _vehiclesPerLocation);

            // now wait for messages from the server till doomsday
            system.AwaitTermination();
        }

        public List<VehiclesPerLocation> VehiclesPerLocation
        {
            get { return _vehiclesPerLocation; }
        }
        
        private static IActorRef ConnectToTravelControlServer(ActorSystem system, List<VehiclesPerLocation> vehiclesPerLocation)
        {
            var mapClient = system.ActorOf(Props.Create<MapClientActor>(vehiclesPerLocation));
            system.ActorSelection(GlobalConstant.TravelControlServerUrl);
            mapClient.Tell(new MapClientConnectRequest());

            return mapClient;
        }


    }
}
