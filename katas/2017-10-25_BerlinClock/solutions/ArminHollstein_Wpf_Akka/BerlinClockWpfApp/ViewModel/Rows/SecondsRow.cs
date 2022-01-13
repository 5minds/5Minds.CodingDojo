using System.Windows.Media;
using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors.UI;

namespace BerlinClockWpfApp.ViewModel.Rows
{
    public class SecondsRow
    {
        private readonly SolidColorBrush _tickerOffColor =
            new BrushConverter().ConvertFromString("#33EE8D03") as SolidColorBrush;

        private readonly SolidColorBrush _tickerOnColor =
            new BrushConverter().ConvertFromString("#FFEE8D03") as SolidColorBrush;

        public SecondsRow(IActorRef publishingTickerActor)
        {
            PublishingTickerActor = publishingTickerActor;
            CreateBeacons();
        }

        private IActorRef PublishingTickerActor { get; }

        public Beacon<SecondsActor> SecondsBeacon { get; private set; }

        private void CreateBeacons()
        {
            SecondsBeacon = new Beacon<SecondsActor>(_tickerOnColor, _tickerOffColor, PublishingTickerActor);
        }
    }
}