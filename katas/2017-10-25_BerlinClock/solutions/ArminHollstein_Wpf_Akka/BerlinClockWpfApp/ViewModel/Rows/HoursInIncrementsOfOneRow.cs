using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors.UI;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class HoursInIncrementsOfOneRow : HourBase
    {
        public HoursInIncrementsOfOneRow(IActorRef publishingTickerActor)
        {
            Hour01Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 1);
            Hour02Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 2);
            Hour03Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 3);
            Hour04Beacon = new Beacon<HoursActor>(_hourOnColor, _hourOffColor, publishingTickerActor, 4);
        }

        public Beacon<HoursActor> Hour01Beacon { get; }
        public Beacon<HoursActor> Hour02Beacon { get; }
        public Beacon<HoursActor> Hour03Beacon { get; }
        public Beacon<HoursActor> Hour04Beacon { get; }
    }
}