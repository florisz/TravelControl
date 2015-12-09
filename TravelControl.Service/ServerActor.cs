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
        IHandle<TimeTableClientConnect>,
        IHandle<TimeTableClientDisconnect>,
        IHandle<MapClientConnectRequest>,
        IHandle<MapClientDisconnect>,
        IHandle<VehicleStatus>,
        ILogReceive
    {
        private readonly Dictionary<Guid, IActorRef> _vehicleClients = new Dictionary<Guid, IActorRef>();
        private readonly Dictionary<Guid, IActorRef> _timetableClients = new Dictionary<Guid, IActorRef>();
        private readonly Dictionary<Guid, IActorRef> _mapClients = new Dictionary<Guid, IActorRef>();

        [Dependency]
        public IStatusHandler StatusHandler
        {
            get; set;
        }

        public ServerActor()
        {
            ServiceLocator.Instance.BuildUp(this.GetType(), this);
        }

        public void Handle(VehicleClientConnectRequest message)
        {
            var logger = Logging.GetLogger(Context);

            Exception exception = null;
            try {
                logger.Debug("Vehicle client {0} has connected", message.Id);

                if (!_vehicleClients.ContainsKey(message.Id))
                {
                    _vehicleClients.Add(message.Id, this.Sender);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Sender.Tell(new VehicleClientConnectResponse
            {
                Id = message.Id,
                RequestOk = (exception == null),
                ServerException = exception
            }, Self);
        }

        public void Handle(VehicleClientDisconnect message)
        {
            var logger = Logging.GetLogger(Context);
            logger.Debug("Vehicle client {0} has disconnected");

            if (_vehicleClients.ContainsKey(message.Id))
            {
                _vehicleClients.Remove(message.Id);
            }
        }

        public void Handle(TimeTableClientConnect message)
        {
            var logger = Logging.GetLogger(Context);
            logger.Debug("TimeTable client {0} has connected", message.Id);

            if (!_timetableClients.ContainsKey(message.Id))
            {
                _timetableClients.Add(message.Id, this.Sender);
            }

        }

        public void Handle(TimeTableClientDisconnect message)
        {
            var logger = Logging.GetLogger(Context);
            logger.Debug("TimeTable client {0} has disconnected");

            if (_timetableClients.ContainsKey(message.Id))
            {
                _timetableClients.Remove(message.Id);
            }
        }

        public void Handle(MapClientConnectRequest message)
        {
            var logger = Logging.GetLogger(Context);

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
            var logger = Logging.GetLogger(Context);
            logger.Debug("Map client {0} has disconnected");

            if (_mapClients.ContainsKey(message.Id))
            {
                _mapClients.Remove(message.Id);
            }
        }

        public void Handle(VehicleStatus message)
        {
            var logger = Logging.GetLogger(Context);
            logger.Debug("Client send status: vehicle={0}, location={1}, status={2}, time={3}", 
                message.Vehicle, 
                message.Location, 
                message.Status, 
                message.DateTime.ToShortTimeString());

            StatusHandler.Handle(message, _mapClients, logger);
        }
    }
}
