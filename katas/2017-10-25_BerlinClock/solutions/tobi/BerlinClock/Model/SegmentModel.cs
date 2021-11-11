namespace BerlinClock.Model
{
    public record SegmentModel
    {
        public int HourSegmentFirst { get; set; }
        public int HourSegmentSecond { get; set; }
        public int MinuteSegmentFirst { get; set; }
        public int MinuteSegmentSecond { get; set; }
    }
}
