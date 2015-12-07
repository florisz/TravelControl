using System;
using System.Collections.Generic;
using TravelControl.Storage;

namespace TravelControl.Domain
{
    public class StopLocations : IStopLocations
    {
        private static object syncRoot = new Object();
        private IStorage _storage;
        private IDictionary<string, StopLocation> _dictionary = null;

        public StopLocations(IStorage storage)
        {
            _storage = storage;
        }

        public IDictionary<string, StopLocation> All
        {
            get
            {
                if (_dictionary == null)
                {
                    lock (syncRoot)
                    {
                        if (_dictionary == null)
                        {
                            _dictionary = new Dictionary<string, StopLocation>();
                            var list = _storage.GetAllStopLocations();

                            foreach (StopLocationEntity location in list)
                            {
                                _dictionary.Add(location.LocationId, 
                                    new StopLocation
                                    {
                                        LocationId = location.LocationId,
                                        Lattitude = location.Lattitude,
                                        Longitude = location.Longitude,
                                        Name = location.Name,
                                    });
                            }
                        }
                    }
                }

                return _dictionary;
            }
        }
    }
}
