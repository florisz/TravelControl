namespace TravelControl.Constants
{
    public static class GlobalConstant
    {
        public const string TravelControlServerProtocol = "akka.tcp";
        public const string TravelControlServerName = "TravelControl";
        public const string TravelControlAddress = "localhost";
        public const string TravelControlPort = "8082";
        public const string TravelControlLocalAddress = "user/TravelControl";

        public static string TravelControlServerUrl
        {
            get { return string.Format("{0}://{1}@{2}:{3}/{4}", TravelControlServerProtocol
                                                              , TravelControlServerName
                                                              , TravelControlAddress
                                                              , TravelControlPort
                                                              , TravelControlLocalAddress); }
        }
    }

}
