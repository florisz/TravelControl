using System;

namespace TravelControl.Messages
{
    public enum VehicleStatusEnum
    {
        Start,
        Stop
    }

    public class VehicleStatus
    {
        public string Vehicle { get; set; }
        public VehicleStatusEnum Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }

    public class LocationStatusMessage
    {
        public string Location { get; set; }
        public int VehicleCount { get; set; }
    }

    public class VehicleClientConnectRequest
    {
        public Guid Id { get; set; }
    }

    public class VehicleClientConnectResponse
    {
        public Guid Id { get; set; }
        public bool RequestOk { get; set; }
        public Exception ServerException { get; set; }
    }

    public class VehicleClientDisconnect
    {
        public Guid Id { get; set; }
    }

    public class MapClientConnectRequest
    {
        public Guid Id { get; set; }
    }

    public class MapClientConnectResponse
    {
        public Guid Id { get; set; }
        public bool RequestOk { get; set; }
        public Exception ServerException { get; set; }
    }

    public class MapClientDisconnect
    {
        public Guid Id { get; set; }
    }

    public class TimeTableClientConnect
    {
        public Guid Id { get; set; }
    }

    public class TimeTableClientDisconnect
    {
        public Guid Id { get; set; }
    }

}
