using Akka.Actor;
using System;
using TravelControl.Constants;
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
        private bool _connected;

        public void Handle(VehicleClientConnectRequest message)
        {
            _id = message.Id;

            Console.WriteLine("Connecting...");

            var task = _server.Ask(message, TimeSpan.FromSeconds(10));
            task.Wait();
            var result = task.Result;
            if (result.GetType() == typeof (VehicleClientConnectResponse))
            {
                _connected = true;
                Console.WriteLine("Connected!");
            }
            else if (result.GetType() == typeof(Failure))
            {
                var failure = result as Failure;
                Console.WriteLine($"Failure in connecting: {failure.Exception.Message}\nStacktrace:\n{failure.Exception.StackTrace}");
            }
        }

        public void Handle(VehicleClientConnectResponse message)
        {
            if (!message.RequestOk)
            {
                throw message.ServerException;
            }
        }

        public void Handle(VehicleStatus message)
        {
            message.Id = _id;
            _server.Tell(message);
        }

    }
}
