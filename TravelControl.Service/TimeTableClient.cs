using Akka.Actor;

namespace TravelControlService
{
    public class TimeTableClient
    {
        public IActorRef ClientRef { get; set; }
        public string RouteCode { get; set; }
    }
}
