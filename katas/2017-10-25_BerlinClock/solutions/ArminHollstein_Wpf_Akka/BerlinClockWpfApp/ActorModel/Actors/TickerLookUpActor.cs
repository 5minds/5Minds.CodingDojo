namespace BerlinClockWpfApp.ActorModel.Actors
{
    using System;

    using Akka.Actor;

    using BerlinClockWpfApp.ActorModel.Messages;
    using BerlinClockWpfApp.Services;

    public class TickerLookUpActor : MonitoringReceiveActor
    {
        #region Fields

        private readonly ITickerService _tickerService;

        #endregion

        #region Constructors and Destructors

        public TickerLookUpActor(ITickerService tickerService)
        {
            _tickerService = tickerService;
            ReceiveAndMonitor<RefreshTickerMessage>(message => LookupTicker());
        }

        #endregion

        #region Methods

        private void LookupTicker()
        {
            DateTime tick = _tickerService.GetNewTick();

            Sender.Tell(new UpdateTickerMessage(tick));
        }

        #endregion
    }
}