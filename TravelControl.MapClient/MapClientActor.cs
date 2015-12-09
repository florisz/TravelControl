using Akka.Actor;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using TravelControl.Common;
using TravelControl.Constants;
using TravelControl.MapClient.ViewModels;
using TravelControl.Messages;

namespace TravelControl.MapClient
{
    class MapClientActor : TypedActor,
        IHandle<MapClientConnectRequest>,
        IHandle<MapClientConnectResponse>,
        IHandle<LocationStatusMessage>,
        ILogReceive
    {
        private readonly ActorSelection _server = Context.ActorSelection(GlobalConstant.TravelControlServerUrl);
        private Guid _id;
        private bool _connected = false;
        private List<VehiclesPerLocation> _vehiclesPerLocation;

        [Dependency]
        public ILocationStatusHandler LocationStatusHandler
        {
            get; set;
        }

        public MapClientActor(List<VehiclesPerLocation> vehiclesPerLocation)
        {
            ServiceLocator.Instance.BuildUp(this.GetType(), this);
            _vehiclesPerLocation = vehiclesPerLocation;
        }

        public void Handle(MapClientConnectRequest message)
        {
            if (message.Id == null)
            {
                message.Id = new Guid();
            }
            _id = message.Id;

            _server.Tell(message);
        }

        public void Handle(MapClientConnectResponse message)
        {
            if (!message.RequestOk)
            {
                throw message.ServerException;
            }
            _connected = true;
        }

        public void Handle(LocationStatusMessage message)
        {
            if (_connected)
            {
                LocationStatusHandler.Handle(message, _vehiclesPerLocation);
            }
        }

    }
}
