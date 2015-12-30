using Akka.Actor;
using Akka.Event;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using TravelControl.Common;
using TravelControl.Messages;

namespace TravelControlService
{
    public class ServerActor :
        TypedActor,
        IHandle<VehicleClientConnectRequest>,
        IHandle<VehicleClientDisconnect>,
        IHandle<TimeTableClientConnectRequest>,
        IHandle<TimeTableClientDisconnect>,
        IHandle<MapClientConnectRequest>,
        IHandle<MapClientDisconnect>,
        IHandle<VehicleStatusMessage>,
        ILogReceive
    {
        private readonly Dictionary<Guid, IActorRef> _vehicleClients = new Dictionary<Guid, IActorRef>();
        private readonly Dictionary<Guid, TimeTableClient> _timetableClients = new Dictionary<Guid, TimeTableClient>();
        private readonly Dictionary<Guid, IActorRef> _mapClients = new Dictionary<Guid, IActorRef>();

        [Dependency]
        public IStatusHandler StatusHandler
        {
            get; set;
        }

        public ServerActor()
        {
            ServiceLocator.Instance.BuildUp(GetType(), this);
        }

        public void Handle(VehicleClientConnectRequest message)
        {
            var logger = Context.GetLogger();

            try {
                logger.Debug("Vehicle client {0} has connected", message.Id);

                if (!_vehicleClients.ContainsKey(message.Id))
                {
                    _vehicleClients.Add(message.Id, this.Sender);
                }
            }
            catch (Exception ex)
            {
                Sender.Tell(new Failure {Exception = ex}, Self);
                return;
            }

            Sender.Tell(new VehicleClientConnectResponse
            {
                Id = message.Id,
                RequestOk = true,
                ServerException = null
            }, Self);
        }

        public void Handle(VehicleClientDisconnect message)
        {
            var logger = Context.GetLogger();
            logger.Debug("Vehicle client has disconnected");

            if (_vehicleClients.ContainsKey(message.Id))
            {
                _vehicleClients.Remove(message.Id);
            }
        }

        public void Handle(TimeTableClientConnectRequest message)
        {
            var logger = Context.GetLogger();

            try
            {
                logger.Debug("TimeTable client {0} has connected", message.Id);

                if (!_timetableClients.ContainsKey(message.Id))
                {
                    _timetableClients.Add(message.Id, new TimeTableClient {ClientRef = this.Sender, RouteCode = message.RouteCode });
                }
            }
            catch (Exception ex)
            {
                Sender.Tell(new Failure { Exception = ex }, Self);
                return;
            }

            Sender.Tell(new TimeTableClientConnectResponse
            {
                Id = message.Id,
                RequestOk = true,
                ServerException = null
            }, Self);
        }

        public void Handle(TimeTableClientDisconnect message)
        {
            var logger = Context.GetLogger();
            logger.Debug("TimeTable client has disconnected");

            if (_timetableClients.ContainsKey(message.Id))
            {
                _timetableClients.Remove(message.Id);
            }
        }

        public void Handle(MapClientConnectRequest message)
        {
            var logger = Context.GetLogger();

            Exception exception = null;
            try
            {
                logger.Debug("Map client {0} has connected", message.Id);

                if (!_mapClients.ContainsKey(message.Id))
                {
                    _mapClients.Add(message.Id, this.Sender);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Sender.Tell(new MapClientConnectResponse
            {
                Id = message.Id,
                RequestOk = (exception == null),
                ServerException = exception
            }, Self);
        }

        public void Handle(MapClientDisconnect message)
        {
            var logger = Context.GetLogger();
            logger.Debug("Map client has disconnected");

            if (_mapClients.ContainsKey(message.Id))
            {
                _mapClients.Remove(message.Id);
            }
        }

        public void Handle(VehicleStatusMessage message)
        {
            var logger = Context.GetLogger();

            StatusHandler.Handle(message, _mapClients, _timetableClients, logger);
        }
    }
}
