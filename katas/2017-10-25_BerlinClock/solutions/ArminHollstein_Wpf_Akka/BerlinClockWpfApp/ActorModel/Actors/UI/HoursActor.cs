namespace BerlinClockWpfApp.ActorModel.Actors.UI
{
    using System;

    public class HoursActor : BaseActor
    {
        #region Constructors and Destructors

        public HoursActor(int hourUISlot, Action toggleOn, Action toggleOff)
            : base(basis: 5, hourUISlot: hourUISlot, minuteUISlot: 0)
        {
            Receive<Messages.TickerMessage>(
                message =>
                {
                    if (IsHourRow(message.Hours) || Is5HourRow(message.Hours))
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