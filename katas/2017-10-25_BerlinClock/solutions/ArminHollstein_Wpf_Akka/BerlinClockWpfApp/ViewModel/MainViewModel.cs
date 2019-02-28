using Akka.Actor;
using BerlinClockWpfApp.ActorModel;
using BerlinClockWpfApp.ActorModel.Actors;
using BerlinClockWpfApp.ActorModel.Messages;
using BerlinClockWpfApp.ViewModel.Rows;

namespace BerlinClockWpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Constructors and Destructors

        public MainViewModel()
        {
            _publishingTickerActor =
                ActorSystemReference.ActorSystem.ActorOf(Props.Create(() => new PublishingTickerActor(true)));

            CreateRows();
        }

        #endregion

        #region Public Properties

        public int Timelapse
        {
            get => _timeLapse;
            set
            {
                _timeLapse = value;

                _publishingTickerActor.Tell(new RefreshTickerMessage(_timeLapse));

                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void CreateRows()
        {
            SecondsRow = new SecondsRow(_publishingTickerActor);

            Hours5Row = new HoursInIncrementsOfFiveRow(_publishingTickerActor);

            Hours1Row = new HoursInIncrementsOfOneRow(_publishingTickerActor);

            Minutes5Row = new MinutesInIncrementsOfFiveRow(_publishingTickerActor);

            Minutes1Row = new MinutesInIncrementsOfOneRow(_publishingTickerActor);
        }

        public SecondsRow SecondsRow { get; private set; }
        public HoursInIncrementsOfFiveRow Hours5Row { get; private set; }
        public HoursInIncrementsOfOneRow Hours1Row { get; private set; }
        public MinutesInIncrementsOfFiveRow Minutes5Row { get; private set; }
        public MinutesInIncrementsOfOneRow Minutes1Row { get; private set; }

        #endregion

        #region Fields

        private readonly IActorRef _publishingTickerActor;

        private int _timeLapse;

        #endregion
    }
}