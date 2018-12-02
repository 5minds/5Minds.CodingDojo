namespace BerlinClockWpfApp.ActorModel.Messages
{
    public class ModuloPresentation
    {
        #region Constructors and Destructors

        public ModuloPresentation(int basis, int value)
        {
            Rest = value % basis;
            IntegerPart = value - Rest;
        }

        #endregion

        #region Public Properties

        public int IntegerPart { get; private set; }

        public int Rest { get; private set; }

        #endregion
    }
}