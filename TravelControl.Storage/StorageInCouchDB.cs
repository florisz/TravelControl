using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MyCouch;
using MyCouch.Requests;

namespace TravelControl.Storage
{
    public class StorageInCouchDb : IStorage
    {
        private MyCouchClient _client;

        public StorageInCouchDb()
        {
            _client = new MyCouchClient(DatabaseUri, "travelcontrol");        
        }
        #region Constant stuff
        private const string DatabaseUri = "http://127.0.0.1:5984";
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

        public IEnumerable<string> GetIds()
        {
            return GetAllIds("Routes", "AllById");
        }

        public RouteEntity GetRoute(string id)
        {
            var response = _client.Documents.GetAsync(id).Result;

            return _client.Serializer.Deserialize<RouteEntity>(response.Content);
        }

        public IEnumerable<RouteEntity> GetRoutesByCode(string key)
        {
            return GetList<RouteEntity>("Routes", "ByCode", key, key);
        }

        public IEnumerable<RouteEntity> GetRoutesByDepartureTime(string key)
        {
            return GetList<RouteEntity>("Routes", "ByDepartureTime", key, key);
        }

        public IEnumerable<RouteEntity> GetRoutesByDepartureTime(string keyFrom, string keyTo)
        {
            return GetList<RouteEntity>("Routes", "ByDepartureTime", keyFrom, keyTo);
        }

        public IEnumerable<VehicleStatusEntity> GetVehicleStatusesByRouteId(string routeId)
        {
            return GetList<VehicleStatusEntity>("VehicleStatus", "ByRoute", routeId, routeId);
        }

        public IEnumerable<T> GetList<T>(string designDocument, string viewName, string keyFrom, string keyTo)
        {
            var request = new QueryViewRequest(designDocument, viewName)
                                    .Configure(query => query.StartKey(keyFrom)
                                    .EndKey(keyTo)
                                    .IncludeDocs(true));

            var viewResponse = _client.Views.QueryAsync(request).Result;

            var list = new List<T>();
            foreach (var row in viewResponse.Rows)
            {
                var routeEntity = _client.Serializer.Deserialize<T>(row.IncludedDoc);
                list.Add(routeEntity);
            }

            return list;
        }

        public async Task<string> SaveRoute(RouteEntity route)
        {
            var doc = Serialize(route);
            var response = await _client.Documents.PutAsync(route._id, route._rev, doc);
            if (!response.IsSuccess)
                throw new ApplicationException(
                    $"Save was not succesfull (id:{response.Id}, error:{response.Error}, reason:{response.Reason}, statuscode:{response.StatusCode})");

            return response.Rev;
        }

        public int GetActiveRouteCount()
        {
            return GetValue("Routes", "Active");
        }

        public List<VehicleStatusEntity> GetStatus(string vehicleId)
        {
            var request = new QueryViewRequest("VehicleStatus", "ByRoute")
                                    .Configure(query => query.Key(vehicleId)
                                    .IncludeDocs(true));

            var viewResponse = _client.Views.QueryAsync(request).Result;

            var list = new List<VehicleStatusEntity>();
            foreach (var row in viewResponse.Rows)
            {
                var statusEntity = _client.Serializer.Deserialize<VehicleStatusEntity>(row.IncludedDoc);
                list.Add(statusEntity);
            }

            return list;
        }

        public async Task SaveStatus(VehicleStatusEntity vehicleStatusEntity)
        {
            try
            {
                var doc = Serialize(vehicleStatusEntity);
                var response = await _client.Documents.PostAsync(doc);
                if (!response.IsSuccess)
                {
                    throw new ApplicationException($"Save vehicle status raised an error: {response.Error} with reason: {response.Reason}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception in save vehicle status", ex);
            }
        }

        public void DeleteAllStatusDocuments()
        {
            var request = new QueryViewRequest("VehicleStatus", "DeleteAll");

            var response = _client.Views.QueryAsync(request).Result;

            foreach (var row in response.Rows)
            {
                var revision = row.Value.Substring(1, row.Value.Length - 2);
                var result = _client.Documents.DeleteAsync(row.Id, revision).Result;
            }
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
            var request = new QueryViewRequest(viewId, viewName)
                .Configure(c => c.IncludeDocs(true));

            var viewResponse = _client.Views.QueryAsync(request).Result;

            var list = new List<T>();
            foreach (var row in viewResponse.Rows)
            {
                //Do something with your entity.
                var entity = Deserialize<T>(row.IncludedDoc);
                list.Add(entity);
            }

            return list;
        }

        private IEnumerable<string> GetAllIds(string viewId, string viewName)
        {
            var request = new QueryViewRequest(viewId, viewName)
                .Configure(c => c.IncludeDocs(false));

            var viewResponse = _client.Views.QueryAsync(request).Result;

            var list = new List<string>();
            foreach (var row in viewResponse.Rows)
            {
                list.Add(row.Id);
            }

            return list;
        }

        private int GetValue(string viewId, string viewName)
        {
            var client = new MyCouchClient(DatabaseUri, "travelcontrol");
            var request = new QueryViewRequest(viewId, viewName);
            var response = client.Views.QueryAsync(request).Result;

            return response.RowCount == 0? 0 : int.Parse(response.Rows[0].Value);
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
