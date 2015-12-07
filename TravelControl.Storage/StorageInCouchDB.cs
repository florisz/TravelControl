using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using MyCouch;
using MyCouch.Requests;
using MyCouch.Responses;

namespace TravelControl.Storage
{
    public class StorageInCouchDb : IStorage
    {
        #region Constant stuff
        private const string DATABASE_URI = "http://127.0.0.1:5984";
        #endregion

        #region Connection functions
        public IEnumerable<ConnectionEntity> GetAllConnections()
        {
            return GetAll<ConnectionEntity>("Connections", "All");
        }
        #endregion

        #region StopLocation functions
        public IEnumerable<StopLocationEntity> GetAllStopLocations()
        {
            return GetAll<StopLocationEntity>("StopLocations", "All");
        }
        #endregion

        #region Route functions
        public IEnumerable<RouteEntity> GetRoutes(string departureTime)
        {
            return GetRoutes(departureTime, departureTime);
        }

        public RouteEntity GetRoute(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RouteEntity> GetRoutes(string departureTimeFrom, string departureTimeTo)
        {
            var client = new MyCouchClient(DATABASE_URI, "travelcontrol");
            var request = new QueryViewRequest("Routes", "ByDepartureTime")
                                    .Configure(query => query.StartKey(departureTimeFrom)
                                    .EndKey(departureTimeTo)
                                    .IncludeDocs(true));

            var viewResponse = client.Views.QueryAsync(request).Result;

            var list = new List<RouteEntity>();
            foreach (var row in viewResponse.Rows)
            {
                // Do something with your entity.
                var routeEntity = client.Serializer.Deserialize<RouteEntity>(row.IncludedDoc);
                list.Add(routeEntity);
            }

            return list;
        }

        public string SaveRoute(RouteEntity route)
        {
            var client = new MyCouchClient(DATABASE_URI, "travelcontrol");
            var doc = Serialize(route);
            var response = client.Documents.PutAsync(route._id, route._rev, doc).Result;
            if (!response.IsSuccess)
                throw new ApplicationException(
                    $"Save was not succesfull (id:{response.Id}, error:{response.Error}, reason:{response.Reason}, statuscode:{response.StatusCode})");

            return response.Rev;
        }
        #endregion

        #region Private shizzle
        /// <summary>
        /// Returns a list of entity instances as an enumerable
        /// </summary>
        /// <typeparam name="T">
        /// The type of the entity, this is the POCO reperesentation of the json document in the couch database
        /// </typeparam>
        /// <param name="viewId">Id of the corresponding mapping in the couchdb</param>
        /// <param name="viewName">Name of the map function</param>
        /// <returns></returns>
        private IEnumerable<T> GetAll<T>(string viewId, string viewName)
        {
            var client = new MyCouchClient(DATABASE_URI, "travelcontrol");
            var request = new QueryViewRequest(viewId, viewName)
                .Configure(c => c.IncludeDocs(true));

            var viewResponse = client.Views.QueryAsync(request).Result;

            var list = new List<T>();
            foreach (var row in viewResponse.Rows)
            {
                //Do something with your entity.
                var entity = Deserialize<T>(row.IncludedDoc);
                list.Add(entity);
            }

            return list;
        }

        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }
        #endregion
    }

}
