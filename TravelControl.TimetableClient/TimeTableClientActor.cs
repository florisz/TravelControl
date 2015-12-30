using Akka.Actor;
using NLog;
using TravelControl.Constants;
using TravelControl.Messages;
using TravelControl.TimeTableClient.ViewModels;

namespace TravelControl.TimeTableClient
{
    public class TimeTableClientActor : TypedActor,
        IHandle<TimeTableClientConnectRequest>,
        IHandle<TimeTableClientConnectResponse>,
        IHandle<VehicleStatusMessage>,
        ILogReceive
    {
        private readonly ActorSelection _server = Context.ActorSelection(GlobalConstant.TravelControlServerUrl);
        private readonly RouteStatusViewModel _viewModel;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TimeTableClientActor(RouteStatusViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Handle(TimeTableClientConnectRequest message)
        {
            Logger.Debug("Connecting...");
            _server.Tell(message);
        }

        public void Handle(TimeTableClientConnectResponse message)
        {
            Logger.Debug("TimeTableClientConnectResponse received");
            if (!message.RequestOk)
            {
                throw message.ServerException;
            }
            Logger.Debug("Connected!");
        }

        public void Handle(VehicleStatusMessage message)
        {
            Logger.Debug("Received status message");
            VehicleStatusHandler.Handle(message, _viewModel);
        }
    }
}
