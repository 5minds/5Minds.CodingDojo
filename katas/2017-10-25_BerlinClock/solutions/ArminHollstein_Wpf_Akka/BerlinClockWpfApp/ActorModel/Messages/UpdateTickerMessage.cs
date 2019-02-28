namespace BerlinClockWpfApp.ActorModel.Messages
{
    using System;

    public class UpdateTickerMessage
    {
        #region Constructors and Destructors

        public UpdateTickerMessage(DateTime tick)
        {
            Tick = tick;
        }

        #endregion

        #region Public Properties

        public DateTime Tick { get; private set; }

        #endregion
    }
}