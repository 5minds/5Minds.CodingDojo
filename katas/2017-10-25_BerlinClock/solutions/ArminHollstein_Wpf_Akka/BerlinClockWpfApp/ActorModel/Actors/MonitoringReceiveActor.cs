using System;
using Akka.Actor;
using Akka.Monitoring;

namespace BerlinClockWpfApp.ActorModel.Actors
{
    public class MonitoringReceiveActor : ReceiveActor
    {
        protected void ReceiveAndMonitor<T>(Func<T, bool> handler)
        {
            if (Properties.Settings.Default.Monitoring)
            {
                Context.IncrementMessagesReceived(1, 1);
            }
            
            Receive(handler);
        }

        protected void ReceiveAndMonitor<T>(Action<T> handler, Predicate<T> shouldHandle = null)
        {
            if (Properties.Settings.Default.Monitoring)
            {
                Context.IncrementMessagesReceived(1, 1);
            }

            Receive(handler, shouldHandle);
        }

        protected override void PreStart()
        {
            if (Properties.Settings.Default.Monitoring)
            {
                Context.IncrementActorCreated(1, 1);
            }

            base.PreStart();
        }

        protected override void PostStop()
        {
            if (Properties.Settings.Default.Monitoring)
            {
                Context.IncrementActorStopped(1, 1);
            }

            base.PostStop();
        }
    }
}