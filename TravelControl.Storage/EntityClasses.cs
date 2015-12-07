using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TravelControl.Storage
{
    public enum DocumentType
    {
        StopLocation = 1,
        Connection = 2,
        Route = 3    
    }

    public class RouteEntity 
    {
        public int DocType { get; set; }
        public string RouteId { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public DepartureEntities Departures { get; set; }

        public string _id { get; set; }
        public string _rev { get; set; }
    }

    [CollectionDataContract]
    public class DepartureEntities : List<DepartureEntity>
    {
        
    }

    [DataContract]
    public class DepartureEntity
    {
        public DepartureEntity() { }
        public DepartureEntity(string fromLocation, string plannedArrivalTime, string plannedDepartureTime)
        {
            FromLocation = fromLocation;
            PlannedArrivalTime = plannedArrivalTime;
            PlannedDepartureTime = plannedDepartureTime;
            ActualArrivalTime = null;
            ActualDepartureTime = null;
        }
        [DataMember]
        public string FromLocation { get; set; }
        [DataMember]
        public string PlannedArrivalTime { get; set; }
        [DataMember]
        public string PlannedDepartureTime { get; set; }
        [DataMember]
        public string ActualArrivalTime { get; set; }
        [DataMember]
        public string ActualDepartureTime { get; set; }
    }

    public class StopLocationEntity 
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }

        public string _id { get; set; }
        public string _rev { get; set; }
    }

    public class ConnectionEntity
    {
        public string From { get; set; }
        public string To { get; set; }

        public string _id { get; set; }
        public string _rev { get; set; }
    }
}
