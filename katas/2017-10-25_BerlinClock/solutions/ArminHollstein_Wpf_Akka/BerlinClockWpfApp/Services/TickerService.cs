namespace BerlinClockWpfApp.Services
{
    using System;

    public class TickerService : ITickerService
    {
        #region Static Fields

        private static DateTime? now = null;

        private static double ticks = 0;

        #endregion

        #region Public Methods and Operators

        public DateTime GetNewTick()
        {
            int oneDayInSeconds = 86400;
            if (!now.HasValue)
            {
                now = DateTime.Now;
                ticks = TimeSpan.FromTicks(now.Value.Ticks).TotalSeconds;
            }
            else
            {
                ticks++;
            }

            var newTime = new DateTime(
                now.Value.Year,
                now.Value.Month,
                now.Value.Day,
                TimeSpan.FromSeconds(ticks % oneDayInSeconds).Hours,
                TimeSpan.FromSeconds(ticks % oneDayInSeconds).Minutes,
                TimeSpan.FromSeconds(ticks % oneDayInSeconds).Seconds);

            return newTime;
        }

        #endregion
    }
}