using BerlinClock.Model;

namespace BerlinClock.Services
{
    public class ClockService : IClockService
    {
        public SegmentModel GetTimeSegments(DateTime time)
        {
            return new SegmentModel()
            {
                HourSegmentFirst = time.Hour / 5,
                HourSegmentSecond = time.Hour % 5,
                MinuteSegmentFirst = time.Minute / 5,
                MinuteSegmentSecond = time.Minute % 5,
            };
        }
    }
}
