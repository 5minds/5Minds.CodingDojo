namespace BerlinClockWpfApp.ViewModel
{
    using System;
    using System.Diagnostics;
    using System.Windows.Media;

    using Akka.Actor;

    using BerlinClockWpfApp.ActorModel;
    using BerlinClockWpfApp.ActorModel.Actors;
    using BerlinClockWpfApp.ActorModel.Actors.UI;
    using BerlinClockWpfApp.ActorModel.Messages;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Fields

        private readonly IActorRef _publishingTickerActor;

        private IActorRef _hour05Actor;

        private IActorRef _hour10Actor;

        private SolidColorBrush _hour10Toggle;

        private IActorRef _hour15Actor;

        private SolidColorBrush _hour15Toggle;

        private IActorRef _hour1Actor;

        private SolidColorBrush _hour1Toggle;

        private IActorRef _hour20Actor;

        private SolidColorBrush _hour20Toggle;

        private IActorRef _hour2Actor;

        private SolidColorBrush _hour2Toggle;

        private IActorRef _hour3Actor;

        private SolidColorBrush _hour3Toggle;

        private IActorRef _hour4Actor;

        private SolidColorBrush _hour4Toggle;

        private SolidColorBrush _hour5Toggle;

        private IActorRef _minute05Actor;

        private IActorRef _minute10Actor;

        private SolidColorBrush _minute10Toggle;

        private IActorRef _minute15Actor;

        private SolidColorBrush _minute15Toggle;

        private IActorRef _minute1Actor;

        private SolidColorBrush _minute1Toggle;

        private IActorRef _minute20Actor;

        private SolidColorBrush _minute20Toggle;

        private IActorRef _minute25Actor;

        private SolidColorBrush _minute25Toggle;

        private IActorRef _minute2Actor;

        private SolidColorBrush _minute2Toggle;

        private IActorRef _minute30Actor;

        private SolidColorBrush _minute30Toggle;

        private IActorRef _minute35Actor;

        private SolidColorBrush _minute35Toggle;

        private IActorRef _minute3Actor;

        private SolidColorBrush _minute3Toggle;

        private IActorRef _minute40Actor;

        private SolidColorBrush _minute40Toggle;

        private IActorRef _minute45Actor;

        private SolidColorBrush _minute45Toggle;

        private IActorRef _minute4Actor;

        private SolidColorBrush _minute4Toggle;

        private IActorRef _minute50Actor;

        private SolidColorBrush _minute50Toggle;

        private IActorRef _minute55Actor;

        private SolidColorBrush _minute55Toggle;

        private SolidColorBrush _minute5Toggle;

        private IActorRef _secondsActor;

        private SolidColorBrush _ticker;

        private int _timeLapse;

        private SolidColorBrush hourOffColor = new BrushConverter().ConvertFromString("#33F50303") as SolidColorBrush;

        private SolidColorBrush hourOnColor = new BrushConverter().ConvertFromString("#FFF50303") as SolidColorBrush;

        private SolidColorBrush minuteOffColor = new BrushConverter().ConvertFromString("#33EE8D03") as SolidColorBrush;

        private SolidColorBrush minuteOnColor = new BrushConverter().ConvertFromString("#FFEE8D03") as SolidColorBrush;

        private SolidColorBrush quarterOffColor = new BrushConverter().ConvertFromString("#33EE0303") as SolidColorBrush;

        private SolidColorBrush quarterONColor = new BrushConverter().ConvertFromString("#FFEE0303") as SolidColorBrush;

        private SolidColorBrush tickerOffColor = new BrushConverter().ConvertFromString("#33EE8D03") as SolidColorBrush;

        private SolidColorBrush tickerOnColor = new BrushConverter().ConvertFromString("#FFEE8D03") as SolidColorBrush;

        #endregion

        #region Constructors and Destructors

        public MainViewModel()
        {
            CreateUIActors();

            _publishingTickerActor = ActorSystemReference.ActorSystem.ActorOf(Props.Create(() => new PublishingTickerActor(true)));

            SubscribeUIActors();
        }

        #endregion

        #region Public Properties

        public SolidColorBrush Hour10Toggle
        {
            get => _hour10Toggle;
            set
            {
                _hour10Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour15Toggle
        {
            get => _hour15Toggle;
            set
            {
                _hour15Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour1Toggle
        {
            get => _hour1Toggle;
            set
            {
                _hour1Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour20Toggle
        {
            get => _hour20Toggle;
            set
            {
                _hour20Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour2Toggle
        {
            get => _hour2Toggle;
            set
            {
                _hour2Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour3Toggle
        {
            get => _hour3Toggle;
            set
            {
                _hour3Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour4Toggle
        {
            get => _hour4Toggle;
            set
            {
                _hour4Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Hour5Toggle
        {
            get => _hour5Toggle;
            set
            {
                _hour5Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute10Toggle
        {
            get => _minute10Toggle;
            set
            {
                _minute10Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute15Toggle
        {
            get => _minute15Toggle;
            set
            {
                _minute15Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute1Toggle
        {
            get => _minute1Toggle;
            set
            {
                _minute1Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute20Toggle
        {
            get => _minute20Toggle;
            set
            {
                _minute20Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute25Toggle
        {
            get => _minute25Toggle;
            set
            {
                _minute25Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute2Toggle
        {
            get => _minute2Toggle;
            set
            {
                _minute2Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute30Toggle
        {
            get => _minute30Toggle;
            set
            {
                _minute30Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute35Toggle
        {
            get => _minute35Toggle;
            set
            {
                _minute35Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute3Toggle
        {
            get => _minute3Toggle;
            set
            {
                _minute3Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute40Toggle
        {
            get => _minute40Toggle;
            set
            {
                _minute40Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute45Toggle
        {
            get => _minute45Toggle;
            set
            {
                _minute45Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute4Toggle
        {
            get => _minute4Toggle;
            set
            {
                _minute4Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute50Toggle
        {
            get => _minute50Toggle;
            set
            {
                _minute50Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute55Toggle
        {
            get => _minute55Toggle;
            set
            {
                _minute55Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush Minute5Toggle
        {
            get => _minute5Toggle;
            set
            {
                _minute5Toggle = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush TickerToggle
        {
            get => _ticker;
            set
            {
                _ticker = value;
                OnPropertyChanged();
            }
        }

        public int Timelapse
        {
            get => _timeLapse;
            set
            {
                _timeLapse = value;
                Debug.WriteLine($"timelapse {_timeLapse}");
                _publishingTickerActor.Tell(new RefreshTickerMessage(_timeLapse));

                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void UpdateHour05ToOff()
        {
            Hour5Toggle = hourOffColor;
        }

        public void UpdateHour05ToOn()
        {
            Hour5Toggle = hourOnColor;
        }

        public void UpdateHour10ToOff()
        {
            Hour10Toggle = hourOffColor;
        }

        public void UpdateHour10ToOn()
        {
            Hour10Toggle = hourOnColor;
        }

        public void UpdateHour15ToOff()
        {
            Hour15Toggle = hourOffColor;
        }

        public void UpdateHour15ToOn()
        {
            Hour15Toggle = hourOnColor;
        }

        public void UpdateHour1ToOff()
        {
            Hour1Toggle = hourOffColor;
        }

        public void UpdateHour1ToOn()
        {
            Hour1Toggle = hourOnColor;
        }

        public void UpdateHour20ToOff()
        {
            Hour20Toggle = hourOffColor;
        }

        public void UpdateHour20ToOn()
        {
            Hour20Toggle = hourOnColor;
        }

        public void UpdateHour2ToOff()
        {
            Hour2Toggle = hourOffColor;
        }

        public void UpdateHour2ToOn()
        {
            Hour2Toggle = hourOnColor;
        }

        public void UpdateHour3ToOff()
        {
            Hour3Toggle = hourOffColor;
        }

        public void UpdateHour3ToOn()
        {
            Hour3Toggle = hourOnColor;
        }

        public void UpdateHour4ToOff()
        {
            Hour4Toggle = hourOffColor;
        }

        public void UpdateHour4ToOn()
        {
            Hour4Toggle = hourOnColor;
        }

        public void UpdateMinute05ToOff()
        {
            Minute5Toggle = minuteOffColor;
        }

        public void UpdateMinute05ToOn()
        {
            Minute5Toggle = minuteOnColor;
        }

        public void UpdateMinute10ToOff()
        {
            Minute10Toggle = minuteOffColor;
        }

        public void UpdateMinute10ToOn()
        {
            Minute10Toggle = minuteOnColor;
        }

        public void UpdateMinute15ToOff()
        {
            Minute15Toggle = quarterOffColor;
        }

        public void UpdateMinute15ToOn()
        {
            Minute15Toggle = quarterONColor;
        }

        public void UpdateMinute1ToOff()
        {
            Minute1Toggle = minuteOffColor;
        }

        public void UpdateMinute1ToOn()
        {
            Minute1Toggle = minuteOnColor;
        }

        public void UpdateMinute20ToOff()
        {
            Minute20Toggle = minuteOffColor;
        }

        public void UpdateMinute20ToOn()
        {
            Minute20Toggle = minuteOnColor;
        }

        public void UpdateMinute25ToOff()
        {
            Minute25Toggle = minuteOffColor;
        }

        public void UpdateMinute25ToOn()
        {
            Minute25Toggle = minuteOnColor;
        }

        public void UpdateMinute2ToOff()
        {
            Minute2Toggle = minuteOffColor;
        }

        public void UpdateMinute2ToOn()
        {
            Minute2Toggle = minuteOnColor;
        }

        public void UpdateMinute30ToOff()
        {
            Minute30Toggle = quarterOffColor;
        }

        public void UpdateMinute30ToOn()
        {
            Minute30Toggle = quarterONColor;
        }

        public void UpdateMinute35ToOff()
        {
            Minute35Toggle = minuteOffColor;
        }

        public void UpdateMinute35ToOn()
        {
            Minute35Toggle = minuteOnColor;
        }

        public void UpdateMinute3ToOff()
        {
            Minute3Toggle = minuteOffColor;
        }

        public void UpdateMinute3ToOn()
        {
            Minute3Toggle = minuteOnColor;
        }

        public void UpdateMinute40ToOff()
        {
            Minute40Toggle = minuteOffColor;
        }

        public void UpdateMinute40ToOn()
        {
            Minute40Toggle = minuteOnColor;
        }

        public void UpdateMinute45ToOff()
        {
            Minute45Toggle = quarterOffColor;
        }

        public void UpdateMinute45ToOn()
        {
            Minute45Toggle = quarterONColor;
        }

        public void UpdateMinute4ToOff()
        {
            Minute4Toggle = minuteOffColor;
        }

        public void UpdateMinute4ToOn()
        {
            Minute4Toggle = minuteOnColor;
        }

        public void UpdateMinute50ToOff()
        {
            Minute50Toggle = minuteOffColor;
        }

        public void UpdateMinute50ToOn()
        {
            Minute50Toggle = minuteOnColor;
        }

        public void UpdateMinute55ToOff()
        {
            Minute55Toggle = minuteOffColor;
        }

        public void UpdateMinute55ToOn()
        {
            Minute55Toggle = minuteOnColor;
        }

        public void UpdateTickerToOff()
        {
            TickerToggle = tickerOffColor;
        }

        public void UpdateTickerToOn()
        {
            TickerToggle = tickerOnColor;
        }

        #endregion

        #region Methods

        private void CreateUIActors()
        {
            _secondsActor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<SecondsActor>((Action)UpdateTickerToOn, (Action)UpdateTickerToOff));

            _minute1Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(1, (Action)UpdateMinute1ToOn, (Action)UpdateMinute1ToOff));
            _minute2Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(2, (Action)UpdateMinute2ToOn, (Action)UpdateMinute2ToOff));
            _minute3Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(3, (Action)UpdateMinute3ToOn, (Action)UpdateMinute3ToOff));
            _minute4Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(4, (Action)UpdateMinute4ToOn, (Action)UpdateMinute4ToOff));

            _minute05Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(5, (Action)UpdateMinute05ToOn, (Action)UpdateMinute05ToOff));
            _minute10Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(10, (Action)UpdateMinute10ToOn, (Action)UpdateMinute10ToOff));
            _minute15Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(15, (Action)UpdateMinute15ToOn, (Action)UpdateMinute15ToOff));
            _minute20Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(20, (Action)UpdateMinute20ToOn, (Action)UpdateMinute20ToOff));
            _minute25Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(25, (Action)UpdateMinute25ToOn, (Action)UpdateMinute25ToOff));
            _minute30Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(30, (Action)UpdateMinute30ToOn, (Action)UpdateMinute30ToOff));
            _minute35Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(35, (Action)UpdateMinute35ToOn, (Action)UpdateMinute35ToOff));
            _minute40Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(40, (Action)UpdateMinute40ToOn, (Action)UpdateMinute40ToOff));
            _minute45Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(45, (Action)UpdateMinute45ToOn, (Action)UpdateMinute45ToOff));
            _minute50Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(50, (Action)UpdateMinute50ToOn, (Action)UpdateMinute50ToOff));
            _minute55Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<MinutesActor>(55, (Action)UpdateMinute55ToOn, (Action)UpdateMinute55ToOff));

            _hour1Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(1, (Action)UpdateHour1ToOn, (Action)UpdateHour1ToOff));
            _hour2Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(2, (Action)UpdateHour2ToOn, (Action)UpdateHour2ToOff));
            _hour3Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(3, (Action)UpdateHour3ToOn, (Action)UpdateHour3ToOff));
            _hour4Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(4, (Action)UpdateHour4ToOn, (Action)UpdateHour4ToOff));

            _hour05Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(5, (Action)UpdateHour05ToOn, (Action)UpdateHour05ToOff));
            _hour10Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(10, (Action)UpdateHour10ToOn, (Action)UpdateHour10ToOff));
            _hour15Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(15, (Action)UpdateHour15ToOn, (Action)UpdateHour15ToOff));
            _hour20Actor = ActorSystemReference.ActorSystem.ActorOf(Props.Create<HoursActor>(20, (Action)UpdateHour20ToOn, (Action)UpdateHour20ToOff));
        }

        private void SubscribeUIActors()
        {
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_secondsActor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute1Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute2Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute3Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute4Actor));

            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute05Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute10Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute15Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute20Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute25Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute30Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute35Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute40Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute45Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute50Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_minute55Actor));

            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour1Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour2Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour3Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour4Actor));

            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour05Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour10Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour15Actor));
            _publishingTickerActor.Tell(new SubscribeToTickerMessage(_hour20Actor));
        }

        #endregion
    }
}