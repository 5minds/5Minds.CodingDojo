using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors.UI;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class MinutesInIncrementsOfFiveRow : MinuteBase
    {
        public MinutesInIncrementsOfFiveRow(IActorRef publishingTickerActor)
        {
            Minute05Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 5);
            Minute10Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 10);
            Minute15Beacon = new Beacon<MinutesActor>(_quarterOnColor, _quarterOffColor, publishingTickerActor, 15);
            Minute20Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 20);
            Minute25Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 25);
            Minute30Beacon = new Beacon<MinutesActor>(_quarterOnColor, _quarterOffColor, publishingTickerActor, 30);
            Minute35Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 35);
            Minute40Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 40);
            Minute45Beacon = new Beacon<MinutesActor>(_quarterOnColor, _quarterOffColor, publishingTickerActor, 45);
            Minute50Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 50);
            Minute55Beacon = new Beacon<MinutesActor>(_minuteOnColor, _minuteOffColor, publishingTickerActor, 55);
        }

        public Beacon<MinutesActor> Minute05Beacon { get; }
        public Beacon<MinutesActor> Minute10Beacon { get; }
        public Beacon<MinutesActor> Minute15Beacon { get; }
        public Beacon<MinutesActor> Minute20Beacon { get; }
        public Beacon<MinutesActor> Minute25Beacon { get; }
        public Beacon<MinutesActor> Minute30Beacon { get; }
        public Beacon<MinutesActor> Minute35Beacon { get; }
        public Beacon<MinutesActor> Minute40Beacon { get; }
        public Beacon<MinutesActor> Minute45Beacon { get; }
        public Beacon<MinutesActor> Minute50Beacon { get; }
        public Beacon<MinutesActor> Minute55Beacon { get; }
    }
}