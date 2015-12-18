using Akka.Actor;
using Akka.Configuration;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NLog.Targets;
using TravelControl.Domain;
using COM = TravelControl.Common;
using TravelControl.Storage;

namespace TravelControl.VehicleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            COM.ServiceLocator.Instance.RegisterTypes(container =>
            {
                container.RegisterType<IStorage, StorageInCouchDb>(new PerResolveLifetimeManager());
                container.RegisterType<IStopLocations, StopLocations>(new ContainerControlledLifetimeManager());
                container.RegisterType<IConnections, Connections>(new ContainerControlledLifetimeManager());
                container.RegisterType<IRoutes, Routes>(new ContainerControlledLifetimeManager());
                container.RegisterType<TravelControl.Common.ITimeProvider, COM.MockTimeProvider>(
                    new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(DateTime.Now));
                container.RegisterType<VehicleSimulator>();
                container.RegisterType<DaySimulator>();
            });

            var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
    }
    remote {
        helios.tcp {
            transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
		    applied-adapters = []
		    transport-protocol = tcp
		    port = 0
		    hostname = localhost
        }
    }
}
");
            Console.WriteLine("Hit enter to start...");
            Console.ReadLine();

            // TESTING
            //var storage = COM.ServiceLocator.Instance.Resolve<IStorage>();
            //var locations = storage.GetAllStopLocations();
            //var connections = storage.GetAllConnections();

            //var routes = storage.GetRoutes("00:01");
            //foreach (var route in routes)
            //{
            //    route.Started = false;
            //    route._rev = storage.SaveRoute(route);
            //}
            //DatabaseTestAsync();
            //Console.ReadLine();
            // END OF TESTING

            var daySimulator = new DaySimulator();
            using (var system = ActorSystem.Create("VehicleClient", config))
            {
                daySimulator.SimulateOneDay(system);
            }
        }

        private static void DatabaseTest()
        {
            var routes = COM.ServiceLocator.Instance.Resolve<IRoutes>();
            var elapsedRoutesGetByTimeSpan = new TimeSpan(0, 0, 0);
            var elapsedRoutesGetById = new TimeSpan(0, 0, 0);
            var elapsedRouteSave = new TimeSpan(0, 0, 0);
            var totalRoutesGetByTimeSpan = 0;
            var totalRoutesGetById = 0;
            var totalRouteSave = 0;
            for (var hour = 0; hour < 1; hour++)
            {
                for (var minute = 0; minute < 60; minute++)
                {
                    Console.WriteLine($"Processing hour:{hour}, minute:{minute}");

                    var timeSpan = new TimeSpan(hour, minute, 0);

                    var timer = Stopwatch.StartNew();
                    var routeSet = routes.Get(timeSpan);
                    timer.Stop();
                    elapsedRoutesGetByTimeSpan += timer.Elapsed;
                    totalRoutesGetByTimeSpan++;

                    foreach (var route in routeSet)
                    {
                        timer = Stopwatch.StartNew();
                        var r = routes.Get(route._id);
                        timer.Stop();
                        elapsedRoutesGetById += timer.Elapsed;
                        totalRoutesGetById++;

                        r.Finished = false;
                        r.Started = false;
                        foreach (var departure in r.Departures)
                        {
                            departure.ActualArrivalTime = departure.PlannedArrivalTime;
                            departure.ActualDepartureTime = departure.PlannedDepartureTime;

                            timer = Stopwatch.StartNew();
                            routes.Save(r);
                            timer.Stop();
                            elapsedRouteSave += timer.Elapsed;
                            totalRouteSave++;

                            timer = Stopwatch.StartNew();
                            r = routes.Get(route._id);
                            timer.Stop();
                            elapsedRoutesGetById += timer.Elapsed;
                            totalRoutesGetById++;
                        }
                    }
                }
                Console.WriteLine($"Total routes.Get(Id)       : count={totalRoutesGetById}");
                Console.WriteLine($"                             elapsed={elapsedRoutesGetById}");
                Console.WriteLine($"Total routes.Save(Route)   : count={totalRouteSave}");
                Console.WriteLine($"                             elapsed={elapsedRouteSave}");
                Console.WriteLine($"Total routes.Get(timeSpan) : count={totalRoutesGetByTimeSpan}");
                Console.WriteLine($"                             elapsed={elapsedRoutesGetByTimeSpan}");
            }
        }

        private static void DatabaseTestAsync()
        {
            var routes = COM.ServiceLocator.Instance.Resolve<IRoutes>();
            var stopLocations = COM.ServiceLocator.Instance.Resolve<IStopLocations>();

            var count = stopLocations.All.Count;

            var timer = Stopwatch.StartNew();
            var taskList = new List<Task<int>>();

            for (var hour = 0; hour < 1; hour++)
            {
                for (var minute = 0; minute < 60; minute++)
                {
                    Console.WriteLine($"Processing hour:{hour}, minute:{minute}");

                    var hour1 = hour;
                    var minute1 = minute;
                    taskList.Add(Task<int>.Factory.StartNew( () => ProcessOneMinute(routes, hour1, minute1)));
                }
            }
            
            // ReSharper disable once CoVariantArrayConversion
            Task.WaitAll(taskList.ToArray());
            var totalSaves = taskList.Sum(t => t.Result);
            Console.WriteLine($"Total elapsed time total test : {totalSaves} in {timer.Elapsed}");
        }

        private static int ProcessOneMinute(IRoutes routes, int hour, int minute)
        {
            var timeSpan = new TimeSpan(hour, minute, 0);

            var routeSet = routes.Get(timeSpan);
            var saveCount = 0;

            foreach (var route in routeSet)
            {
                var r = routes.Get(route._id);

                var status = new VehicleStatus
                {
                    RouteId = r.Id,
                    VehicleId = r.Id,
                    Time = timeSpan,
                    Location = r.Departures[0].FromLocation.LocationId,
                    Status = VehicleStatusEnum.StartRoute
                };
                routes.SaveStatus(status);
                saveCount++;
                foreach (var departure in r.Departures)
                {
                    // arrival
                    status.Time = departure.PlannedArrivalTime;
                    status.Location = departure.FromLocation.LocationId;
                    status.Status = VehicleStatusEnum.Arrive;
                    routes.SaveStatus(status);
                    saveCount++;

                    // departure
                    if (departure.PlannedDepartureTime.HasValue)
                    {
                        status.Time = departure.PlannedDepartureTime.Value;
                        status.Location = departure.FromLocation.LocationId;
                        status.Status = VehicleStatusEnum.Depart;
                        routes.SaveStatus(status);
                        saveCount++;
                    }
                }
                var lastDeparture = r.Departures[r.Departures.Count - 1];
                status.Time = lastDeparture.PlannedArrivalTime;
                status.Location = lastDeparture.FromLocation.LocationId;
                status.Status = VehicleStatusEnum.EndRoute;
                routes.SaveStatus(status);
                saveCount++;
            }
            return saveCount;
        }
    }

    public static class StopWatchExtensions
    {
        public static long Time(this Stopwatch stopwatch, Action<Route> action, Route route, long total)
        {
            stopwatch.Reset();
            stopwatch.Start();
            action(route);
            Console.WriteLine();
            stopwatch.Stop();

            return total + stopwatch.ElapsedMilliseconds;
        }
    }
}
