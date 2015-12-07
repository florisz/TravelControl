using System;

namespace TravelControl.Common
{
    /// <summary>
    /// Class for mocking time in an application
    /// </summary>
    public class MockTimeProvider : ITimeProvider
    {
        #region Constructors
        /// <summary>
        /// Construtor that sets the current time
        /// </summary>
        public MockTimeProvider(DateTime now)
        {
            CurrentTime = now;
        }

        /// <summary>
        /// Construtor that sets the current time 
        /// (to be used in web/app.config scenarios)
        /// </summary>
        //public MockTimeProvider(int year, int month, int day, int hour = 0, int min = 0, int sec = 0)
        //{
        //    CurrentTime = new DateTime(year, month, day, hour, min, sec);
        //}

        #endregion

        #region ITimeProvider implementation
        /// <summary>
        /// Returns the date/time as far as this mock is concerned
        /// </summary>
        public DateTime Now => CurrentTime;

        /// <summary>
        /// Gets the current time in UTC.
        /// </summary>
        public DateTime UtcNow => CurrentTime.ToUniversalTime();

        /// <summary>
        /// Returns the local date/time as far as this mock is concerned
        /// </summary>
        public DateTime LocalDateTime => CurrentTime.ToLocalTime();


        /// <summary>
        /// Returns the current date as far as this mock is concerned
        /// </summary>
        public DateTime Today => CurrentTime.Date;

        #endregion

        #region Functionality for test purposes
        /// <summary>
        /// The date/time as far as this mock is concerned; with internal setter
        /// Can be set for test purposes
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// Jumps component time ahead by the interval specified.
        /// </summary>
        /// <param name="interval">The interval.</param>
        public void FastForwardBy(TimeSpan interval)
        {
            this.CurrentTime += interval;
        }

        #endregion
    }
}
