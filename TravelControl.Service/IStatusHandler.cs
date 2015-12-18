using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using TravelControl.Messages;

namespace TravelControlService
{
    public interface IStatusHandler
    {
        void Handle(VehicleStatusMessage status, Dictionary<Guid, IActorRef> mapClients, ILoggingAdapter logger);
    }
}
