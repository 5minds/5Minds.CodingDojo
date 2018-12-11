using System;
using System.Windows.Media;
using Akka.Actor;
using BerlinClockWpfApp.ActorModel;
using BerlinClockWpfApp.ActorModel.Actors;
using BerlinClockWpfApp.ActorModel.Messages;

namespace BerlinClockWpfApp.ViewModel
{
    public class Beacon<T> : ViewModelBase where T : MonitoringReceiveActor
    {
        private SolidColorBrush _toggle;
        private SolidColorBrush OffColor { get; }
        private SolidColorBrush OnColor { get; }
        private IActorRef Actor { get; }

        public Beacon(SolidColorBrush onColor, SolidColorBrush offColor, IActorRef publishingTickerActor, int? slot = null )
        {
            OffColor = offColor;
            OnColor = onColor;
    
            Props props = 
                slot.HasValue ? 
                Props.Create<T>(slot.Value, (Action) BeaconOn, (Action) BeaconOff) :
                Props.Create<T>((Action) BeaconOn, (Action) BeaconOff) ;
        
            Actor = ActorSystemReference.ActorSystem.ActorOf(props);

            publishingTickerActor.Tell(new SubscribeToTickerMessage(Actor));
        }

        public SolidColorBrush Toggle
        {
            get => _toggle;
            set
            {
                _toggle = value;
                OnPropertyChanged();
            }
        }

        private void BeaconOn()
        {
            Toggle = OnColor;
        }

        private void BeaconOff()
        {
            Toggle = OffColor;
        }
    }
}