using System.Collections.Generic;

namespace TravelControl.Domain
{
    public interface IStopLocations
    {
        IDictionary<string, StopLocation> All { get; }
    }
}
