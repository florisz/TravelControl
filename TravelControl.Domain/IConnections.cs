using System;
using System.Collections.Generic;

namespace TravelControl.Domain
{
    public interface IConnections
    {
        IEnumerable<Tuple<StopLocation, StopLocation>> All { get; }
    }
}
