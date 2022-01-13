namespace BerlinClockWpfApp.Services
{
    using System;

    public interface ITickerService
    {
        #region Public Methods and Operators

        DateTime GetNewTick();

        #endregion
    }
}