using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using COM = TravelControl.Common;
using TravelControl.Domain;
using TravelControl.GlobalConstants;
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
            // initialise all routes by resetting the isstarted and is isfinished bit
            InitialiseRoutes();

            // set time to the time of the earliest departure time
            SetTimeProvider(GetEarliestDepartureTime());

            var runningVehicles = new Dictionary<Guid, VehicleSimulator>();

            // while all routes are handled
            while (TimeProvider.Now.TimeOfDay != new TimeSpan(0,0,0))
            {
                var startTime = TimeProvider.Now;

                var routes = Routes.Get(new TimeSpan(startTime.Hour, startTime.Minute, startTime.Second));
                var routeArray = routes as Route[] ?? routes.ToArray();

                // start all new routes
                if (routes != null && routeArray.Any())
                {
                    foreach (var route in routeArray)
                    {
                        if (route.Started)
                            continue;

                        var vehicleClient = ConnectToTravelControlServer(system);
                        var vehicleId = Guid.NewGuid();
                        var simulator = new VehicleSimulator(vehicleClient, route, vehicleId);

                        simulator.StartRoute();

                        runningVehicles.Add(vehicleId, simulator);
                    }
                }

                foreach (var vehicleSimulator in runningVehicles.Values.ToList())
                {
                    WriteLine("Number of active vehicles={0}", runningVehicles.Count);
                    if (vehicleSimulator.SimulateRoute())
                    {
                        vehicleSimulator.EndRoute();
                        runningVehicles.Remove(vehicleSimulator.VehicleId);
                        WriteLine("Route is ready");
                    }
                }

                var timeProvider = TimeProvider as COM.MockTimeProvider;
                System.Threading.Thread.Sleep(2000);
                timeProvider?.FastForwardBy(new TimeSpan(0, 1, 0));
            }
        }

        private void InitialiseRoutes()
        {
            for (var hour = 0; hour <= 23; hour++)
            {
                WriteLine("Initialising routes for hour {0}", hour);
                for (var minute = 0; minute < 60; minute++)
                {
                    var timeSpan = new TimeSpan(hour, minute, 0);
                    var routes = Routes.Get(timeSpan);
                    foreach (var route in routes)
                    {
                        if (route.Finished || route.Started)
                        {
                            route.Finished = false;
                            route.Started = false;
                            Routes.Save(route);
                        }
                    }
                }
            }
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
            timeProvider.CurrentTime = startTime;

            WriteLine("Start time is set to: {0}", timeProvider.Now);
        }

        private IActorRef ConnectToTravelControlServer(ActorSystem system)
        {
            var vehicleClient = system.ActorOf(Props.Create<VehicleClientActor>());
            system.ActorSelection(GlobalConstant.TravelControlServerUrl);
            vehicleClient.Tell(new VehicleClientConnectRequest { Id = Guid.NewGuid() });

            return vehicleClient;
        }

    }
}
