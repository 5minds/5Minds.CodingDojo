using Akka.Monitoring;

namespace BerlinClockWpfApp.ActorModel.Actors
{
    using System;
    using System.Collections.Generic;

    using Akka.Actor;
    using Akka.DI.Core;

    using BerlinClockWpfApp.ActorModel.Messages;

    public class PublishingTickerActor : MonitoringReceiveActor
    {
        #region Fields

        private readonly bool _autostart;

        private readonly HashSet<IActorRef> _subscribers;

        private readonly IActorRef _tickerLookupChild;

        private DateTime _tick;

        private ICancelable _tickRefreshing;

        private int _timeLapse;

        #endregion

        #region Constructors and Destructors

        public PublishingTickerActor(bool autostart = true)
        {
            _subscribers = new HashSet<IActorRef>();
            _tickerLookupChild = Context.ActorOf(Context.DI().Props<TickerLookUpActor>());
            this._autostart = autostart;
            _timeLapse = 0;
            
            
            ReceiveAndMonitor<SubscribeToTickerMessage>(message => _subscribers.Add(message.Subscriber));

            ReceiveAndMonitor<UnsubscribeFromTickerMessage>(message => _subscribers.Remove(message.Subscriber));

            ReceiveAndMonitor<RefreshTickerMessage>(
                message =>
                {
                    if (message.TimeLapse.HasValue)
                    {
                        _timeLapse = message.TimeLapse.Value;
                        _tickRefreshing.Cancel(true);
                        SchedulePublishingTickerActor();
                    }
                    else
                    {
                        _tickerLookupChild.Tell(message);
                    }
                });

            ReceiveAndMonitor<UpdateTickerMessage>(
                message =>
                {
                    _tick = message.Tick;

                    TickerMessage tickerMessage = new TickerMessage(_tick);

                    foreach (IActorRef subscriber in _subscribers)
                    {
                        subscriber.Tell(tickerMessage);
                    }
                }
            );
        }

        #endregion

        #region Methods

        protected override void PostStop()
        {
            _tickRefreshing?.Cancel(false);
            base.PostStop();
        }

        protected override void PreStart()
        {
            if (_autostart)
            {
                base.PreStart();
                SchedulePublishingTickerActor();
            }
        }

        private void SchedulePublishingTickerActor()
        {
            _tickRefreshing = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(
                initialDelay: TimeSpan.FromSeconds(1),
                interval: TimeSpan.FromMilliseconds(1000 - _timeLapse),
                receiver: Self,
                message: new RefreshTickerMessage(),
                sender: Self);
        }

        #endregion
    }
}