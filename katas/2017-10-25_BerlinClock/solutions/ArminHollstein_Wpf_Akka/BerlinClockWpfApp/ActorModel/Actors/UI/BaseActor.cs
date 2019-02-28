namespace BerlinClockWpfApp.ActorModel.Actors.UI
{
    using Akka.Actor;

    using BerlinClockWpfApp.ActorModel.Messages;

    public class BaseActor : MonitoringReceiveActor
    {
        #region Fields

        private readonly int _hourUISlot;

        private readonly int _minuteUISlot;

        #endregion

        #region Constructors and Destructors

        public BaseActor(int basis, int hourUISlot, int minuteUISlot)
        {
            _hourUISlot = hourUISlot;
            _minuteUISlot = minuteUISlot;
            Basis = basis;
        }

        #endregion

        #region Public Properties

        public int Basis { get; }

        #endregion

        #region Public Methods and Operators

        public bool Is5HourRow(ModuloPresentation Hour)
        {
            return (Hour.IntegerPart >= _hourUISlot && _hourUISlot >= Basis);
        }

        public bool Is5MinuteRow(ModuloPresentation Minute)
        {
            return (Minute.IntegerPart >= _minuteUISlot && _minuteUISlot >= Basis);
        }

        public bool IsHourRow(ModuloPresentation Hour)
        {
            return (Hour.Rest >= _hourUISlot && _hourUISlot < Basis);
        }

        public bool IsMinuteRow(ModuloPresentation Minute)
        {
            return (Minute.Rest >= _minuteUISlot && _minuteUISlot < Basis);
        }

        #endregion
    }
}