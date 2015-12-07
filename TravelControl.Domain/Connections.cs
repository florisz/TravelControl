using System;
using System.Collections.Generic;
using TravelControl.Storage;

namespace TravelControl.Domain
{
    public class Connections : IConnections
    {
        private static readonly object _syncRoot = new object();
        private IStorage _storage;
        private IStopLocations _stopLocations;
        private IEnumerable<Tuple<StopLocation, StopLocation>> _list = null;

        public Connections(IStorage storage, IStopLocations stopLocations)
        {
            _storage = storage;
            _stopLocations = stopLocations;
        }

        public IEnumerable<Tuple<StopLocation, StopLocation>> All
        {
            get
            {
                if (_list == null)
                {
                    lock (_syncRoot)
                    {
                        if (_list == null)
                        {
                            var list = new List<Tuple<StopLocation, StopLocation>>();
                            var connections = _storage.GetAllConnections();
                            foreach(ConnectionEntity connection in connections)
                            {
                                var item1 = _stopLocations.All[connection.From];
                                var item2 = _stopLocations.All[connection.To];
                                list.Add(Tuple.Create(item1, item2));
                            }
                            _list = list;
                        }
                    }
                }

                return _list;
            }
        }
    }
}
