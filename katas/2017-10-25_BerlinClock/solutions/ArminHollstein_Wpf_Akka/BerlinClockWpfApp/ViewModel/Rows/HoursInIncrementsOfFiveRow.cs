using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors.UI;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class HoursInIncrementsOfFiveRow : HourBase
    {
        public HoursInIncrementsOfFiveRow(IActorRef publishingTickerActor)
        {
            Hour05Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 5);
            Hour10Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 10);
            Hour15Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 15);
            Hour20Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 20);
        }

        public Beacon<HoursActor> Hour05Beacon { get; }
        public Beacon<HoursActor> Hour10Beacon { get; }
        public Beacon<HoursActor> Hour15Beacon { get; }
        public Beacon<HoursActor> Hour20Beacon { get; }
    }
}