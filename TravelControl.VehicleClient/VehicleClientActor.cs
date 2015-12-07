using Akka.Actor;
using System;
using TravelControl.GlobalConstants;
using TravelControl.Messages;

namespace TravelControl.VehicleClient
{
    class VehicleClientActor : TypedActor,
        IHandle<VehicleClientConnectRequest>,
        IHandle<VehicleClientConnectResponse>,
        IHandle<VehicleStatus>,
        ILogReceive
    {
        private readonly ActorSelection _server = Context.ActorSelection(GlobalConstant.TravelControlServerUrl);
        private Guid _id;
        private bool _connected = false;

        public void Handle(VehicleClientConnectRequest message)
        {
            _id = message.Id;

            Console.WriteLine("Connecting...");

            _server.Tell(message);
        }

        public void Handle(VehicleClientConnectResponse message)
        {
            if (!message.RequestOk)
            {
                throw message.ServerException;
            }
            _connected = true;
            Console.WriteLine("Connected!");
        }

        public void Handle(VehicleStatus message)
        {
            _server.Tell(message);
        }

    }
}
