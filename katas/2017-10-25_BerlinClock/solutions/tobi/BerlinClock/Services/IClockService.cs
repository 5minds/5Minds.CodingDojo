using BerlinClock.Model;

namespace BerlinClock.Services
{
    public interface IClockService
    {
        SegmentModel GetTimeSegments(DateTime time);
    }
}
