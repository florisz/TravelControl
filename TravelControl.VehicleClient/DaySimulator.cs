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

        private COM.MockTimeProvider MockTimeProvider { get { return (COM.MockTimeProvider) TimeProvider; } }

        public DaySimulator()
        {
            COM.ServiceLocator.Instance.BuildUp(GetType(), this);
        }

        internal void SimulateOneDay(ActorSystem system)
        {
            SetCurrentTime(new TimeSpan(0, 0, 0));

            var runningVehicles = new Dictionary<int, VehicleSimulator>();

            // for performance reasons use one client actor
            var client = ConnectToTravelControlServer(system);

            var vehicleCount = 0;
            var timeSimulationIsReady = false;

            while (!timeSimulationIsReady || runningVehicles.Count > 0)
            {
                WriteLine($"Simulate new minute: {TimeProvider.CurrentTime}");

                // only initialise new routes if time still has not ended
                if (!timeSimulationIsReady)
                {
                    var routes = Routes.Get(TimeProvider.CurrentTime);
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
                }

                foreach (var vehicleSimulator in runningVehicles.Values.ToList())
                {
                    vehicleSimulator.SimulateRoute();
                    if (!vehicleSimulator.HasEnded)
                        continue;

                    vehicleSimulator.EndRoute();
                    runningVehicles.Remove(vehicleSimulator.VehicleId);
                }

                System.Threading.Thread.Sleep(1000);
                MockTimeProvider.FastForwardBy(new TimeSpan(0, 1, 0));
                if (MockTimeProvider.CurrentTime == new TimeSpan(0, 0, 0))
                {
                    // we're back where we started
                    timeSimulationIsReady = true;
                }

                WriteLine("Total vehicles={0}", vehicleCount);
                WriteLine("Number of active vehicles={0}", runningVehicles.Count);
            }
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

        /// <summary>
        /// This method must be called before any other resolve of ITimeProvider
        /// It is a singleton and in this way the correct start time will be set
        /// </summary>
        private void SetCurrentTime(TimeSpan time)
        {
            var now = DateTime.Now;
            MockTimeProvider.CurrentDateTime = new DateTime(now.Year, now.Month, now.Day, time.Hours, time.Minutes, time.Seconds);

            WriteLine("Start time is set to: {0}", MockTimeProvider.Now);
        }

    }
}
