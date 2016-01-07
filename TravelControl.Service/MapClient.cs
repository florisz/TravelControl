using Akka.Actor;

namespace TravelControlService
{
    public class MapClient
    {
        public IActorRef ClientRef { get; set; }
        public string RouteCode { get; set; }
    }
}
