using System;

namespace TravelControl.Common
{
    public class ActualTimeProvider : ITimeProvider
    {
        /// <summary>
        /// Returns now according to the implemented time
        /// </summary>
        public DateTime Now => DateTime.Now;

        /// <summary>
        /// Returns the UtcNow according to the implemented time
        /// </summary>
        public DateTime UtcNow => DateTime.Now.ToUniversalTime();

        /// <summary>
        /// Returns the local time
        /// </summary>
        public DateTime LocalDateTime => DateTime.Now.ToLocalTime();

        /// <summary>
        /// Returns today according to the implemented time
        /// </summary>
        public DateTime Today => DateTime.Today;
    }
}
