using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors.UI;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class MinutesInIncrementsOfOneRow : MinuteBase
    {
        public MinutesInIncrementsOfOneRow(IActorRef publishingTickerActor)
        {
            Minute01Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 1);
            Minute02Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 2);
            Minute03Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 3);
            Minute04Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 4);
        }

        public Beacon<MinutesActor> Minute01Beacon { get; }
        public Beacon<MinutesActor> Minute02Beacon { get; }
        public Beacon<MinutesActor> Minute03Beacon { get; }
        public Beacon<MinutesActor> Minute04Beacon { get; }
    }
}