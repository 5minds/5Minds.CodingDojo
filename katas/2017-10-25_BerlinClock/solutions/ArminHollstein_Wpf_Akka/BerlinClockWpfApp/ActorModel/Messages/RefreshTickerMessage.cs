namespace BerlinClockWpfApp.ActorModel.Messages
{
    public class RefreshTickerMessage
    {
        #region Constructors and Destructors

        public RefreshTickerMessage(int? timeLapse = null)
        {
            TimeLapse = timeLapse;
        }

        #endregion

        #region Public Properties

        public int? TimeLapse { get; }

        #endregion
    }
}