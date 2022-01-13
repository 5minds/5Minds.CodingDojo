namespace BerlinClockWpfApp.ActorModel.Messages
{
    using System;

    public class TickerMessage
    {
        #region Constants

        private const int basis = 5;

        #endregion

        #region Constructors and Destructors

        public TickerMessage(DateTime tick)
        {
            Tick = tick;
            Hours = new ModuloPresentation(basis, tick.Hour);

            Minutes = new ModuloPresentation(basis, tick.Minute);

            SecondToggle = tick.Second % 2;
        }

        #endregion

        #region Public Properties

        public ModuloPresentation Hours { get; private set; }

        public ModuloPresentation Minutes { get; private set; }

        public int SecondToggle { get; private set; }

        public DateTime Tick { get; private set; }

        #endregion
    }
}