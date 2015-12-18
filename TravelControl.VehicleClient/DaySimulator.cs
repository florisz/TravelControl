using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using COM = TravelControl.Common;
using TravelControl.Domain;
using TravelControl.Constants;
using TravelControl.Messages;
using Microsoft.Practices.Unity;
using static System.Console;

namespace TravelControl.VehicleClient
{
    public class DaySimulator
    {
        [Dependency]
        public IRoutes Routes { get; set; }
        [Dependency]
        public COM.ITimeProvider TimeProvider { get; set; }

        public DaySimulator()
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);
        }

        internal void SimulateOneDay(ActorSystem system)
        {
            // initialise all routes by resetting the isstarted /isfinished bit and resetting the actual time values to null
            InitialiseRoutes();

            // set time to the time of the earliest departure time
            SetTimeProvider(GetEarliestDepartureTime());

            var runningVehicles = new Dictionary<int, VehicleSimulator>();

            // for performance reasons use one client actor
            var client = ConnectToTravelControlServer(system);

            var vehicleCount = 0;

            // while not all routes are handled
            while (TimeProvider.CurrentTime != new TimeSpan(0,0,0))
            {
                var routes = Routes.Get(TimeProvider.CurrentTime);

                Console.WriteLine($"Simulate new minute: {TimeProvider.CurrentTime}");
                var routeArray = routes as Route[] ?? routes.ToArray();

                // start all new routes
                if (routes != null && routeArray.Any())
                {
                    foreach (var route in routeArray)
                    {
                        if (route.Started)
                            continue;

                        var simulator = new VehicleSimulator(client, route, vehicleCount);
                        simulator.StartRoute();

                        runningVehicles.Add(vehicleCount, simulator);
                        vehicleCount++;
                    }
                }

                foreach (var vehicleSimulator in runningVehicles.Values.ToList())
                {
                    vehicleSimulator.SimulateRoute();
                    if (!vehicleSimulator.HasEnded)
                        continue;

                    vehicleSimulator.EndRoute();
                    runningVehicles.Remove(vehicleSimulator.VehicleId);
                }

                var timeProvider = TimeProvider as COM.MockTimeProvider;
                //System.Threading.Thread.Sleep(2000);
                timeProvider?.FastForwardBy(new TimeSpan(0, 1, 0));
                WriteLine("Total vehicles={0}", vehicleCount);
                WriteLine("Number of active vehicles={0}", runningVehicles.Count);
            }
        }

        private void InitialiseRoutes()
        {
            Console.WriteLine("Delete all status documents...");
            Routes.DeleteAllStatusDocuments();
            Console.WriteLine("Delete ready");
        }

        private IActorRef ConnectToTravelControlServer(ActorSystem system)
        {
            var vehicleClient = system.ActorOf(Props.Create<VehicleClientActor>());
            system.ActorSelection(GlobalConstant.TravelControlServerUrl);
            try
            {
                var task = vehicleClient.Ask(new VehicleClientConnectRequest { Id = Guid.NewGuid() }, TimeSpan.FromSeconds(10));
                task.Wait();
            }
            catch (Exception ex)
            {
                WriteLine($"Exception: {ex.Message} while connecting");
                // no use in continuing
                throw new ApplicationException("Can not connect to travelcontrol server", ex);
            }

            return vehicleClient;
        }

        private TimeSpan GetEarliestDepartureTime()
        {
            var earliestTime = Routes
                .Get(new TimeSpan(0, 1, 0), new TimeSpan(2, 0, 0))
                .Min(r => r.StartTime);
            return earliestTime;
        }

        /// <summary>
        /// This method must be called before any other resolve of ITimeProvider
        /// It is a singleton and in this way the correct start time will be set
        /// </summary>
        private void SetTimeProvider(TimeSpan earliestTime)
        {
            var now = DateTime.Now;
            var startTime = new DateTime(now.Year, now.Month, now.Day,
                earliestTime.Hours, earliestTime.Minutes, earliestTime.Seconds);

            // we know we're using a mock time provider
            var timeProvider = TimeProvider as COM.MockTimeProvider;
            if (timeProvider == null)
                throw new ApplicationException("timeprovider is null");
            timeProvider.CurrentDateTime = startTime;

            WriteLine("Start time is set to: {0}", timeProvider.Now);
        }

    }
}
