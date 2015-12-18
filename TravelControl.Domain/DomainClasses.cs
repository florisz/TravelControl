using System;
using System.Collections.Generic;

namespace TravelControl.Domain
{
    public enum VehicleStatusEnum
    {
        StartRoute = 1,
        EndRoute = 2,
        Depart = 3,
        Arrive = 4
    }

    public class Route
    {
        public Route()
        {
            Departures = new List<Departure>();
        }
        public string Id { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }
        // Departure time of route is departure of first element because they're alwasy sorted
        public TimeSpan StartTime
        {
            get
            {
                if (Departures == null || Departures.Count <= 0)
                {
                    throw new ApplicationException("Route without departures");
                }
                if (!Departures[0].PlannedDepartureTime.HasValue)
                    throw new ArgumentException($"Route{Id} without departuretime of first departure");

                return Departures[0].PlannedDepartureTime.Value;
            }
        }
        public List<Departure> Departures;
        public string _id { get; set; }
        public string _rev { get; set; }
    }

    public class Departure
    {
        public StopLocation FromLocation { get; set; }
        public TimeSpan PlannedArrivalTime { get; set; }

        public TimeSpan? PlannedWaitingTime
        {
            get
            {
                if (!PlannedDepartureTime.HasValue)
                    return null;
                return PlannedDepartureTime.Value - PlannedArrivalTime;
            }
        } 
        public TimeSpan? PlannedDepartureTime { get; set; }
        public TimeSpan? ActualArrivalTime { get; set; }
        public TimeSpan? ActualWaitingTime
        {
            get
            {
                if (!ActualArrivalTime.HasValue || !ActualDepartureTime.HasValue)
                    return null;
                return ActualDepartureTime - ActualArrivalTime;
            }
        }
        public TimeSpan? ActualDepartureTime { get; set; }
        public bool HasArrived => ActualArrivalTime != null;
        public bool HasDeparted => ActualDepartureTime != null;
        public string _id { get; set; }
        public string _rev { get; set; }
    }

    public class VehicleStatus
    {
        public string VehicleId { get; set; }
        public string RouteId { get; set; }
        public VehicleStatusEnum Status { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }

        public string _id { get; set; }
        public string _rev { get; set; }
    }

    public class StopLocation
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
    }
}
