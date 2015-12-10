using System;

namespace TravelControl.Common
{
    /// <summary>
    /// Interface for a time provider
    /// Normally (the implementation ActualTimeProvider) it provides the current date and time but 
    /// in test scenarios other requirements exist like fast forwarding time or setting it to one specific 
    /// date and time
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Returns today according to the implemented time
        /// </summary>
        DateTime Today { get; }

        /// <summary>
        /// Returns now according to the implemented time
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Returns the UtcNow according to the implemented time
        /// </summary>
        DateTime UtcNow { get; }

        /// <summary>
        /// Returns the local time
        /// </summary>
        DateTime LocalDateTime { get; }

        /// <summary>
        /// Returns the local time
        /// </summary>
        TimeSpan CurrentTime { get; }
    }
}
