namespace BerlinClockWpfApp.ActorModel.Actors.UI
{
    using System;

    public class MinutesActor : BaseActor
    {
        #region Constructors and Destructors

        public MinutesActor(int minuteUISlot, Action toggleOn, Action toggleOff)
            : base(basis: 5, hourUISlot: 0, minuteUISlot: minuteUISlot)
        {
            ReceiveAndMonitor<Messages.TickerMessage>(
                message =>
                {
                    if (IsMinuteRow(message.Minutes) || Is5MinuteRow(message.Minutes))
                    {
                        toggleOn();
                    }
                    else
                    {
                        toggleOff();
                    }
                });
        }

        #endregion
    }
}