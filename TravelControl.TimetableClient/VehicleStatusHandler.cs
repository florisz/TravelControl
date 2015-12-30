using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using TravelControl.Domain;
using TravelControl.Messages;
using TravelControl.TimeTableClient.ViewModels;

namespace TravelControl.TimeTableClient
{
    public class VehicleStatusHandler
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Handle(VehicleStatusMessage message, RouteStatusViewModel viewModel)
        {
            var route = viewModel.SortedRoutes.FirstOrDefault(r => r.Id == message.RouteId);
            if (route == null)
            {
                // assume we're just not interested in this message
                return;
            }

            var routeView = viewModel.Routes.FirstOrDefault(r => r.RouteId == message.RouteId);
            if (routeView == null) throw new ArgumentException("route view can not be found");
            var departure = route.Departures.FirstOrDefault(d => d.FromLocation.LocationId == message.Location);
            if (departure == null) throw new ArgumentException("departure unknown");

            switch (message.Status)
            {
                case VehicleStatusEnum.Arrive:
                case VehicleStatusEnum.EndRoute:
                    departure.ActualArrivalTime = message.Time;
                    break;
                case VehicleStatusEnum.Depart:
                case VehicleStatusEnum.StartRoute:
                    departure.ActualDepartureTime = message.Time;
                    break;
            }

            // update the viewmodel
            var departureIndex = route.Departures.IndexOf(departure);
            routeView.Attributes[(++departureIndex).ToString()] = RouteStatusViewModel.DepartureAsView(departure);

            _logger.Debug($"status message {message.Time} handled");
        }
    }
}
