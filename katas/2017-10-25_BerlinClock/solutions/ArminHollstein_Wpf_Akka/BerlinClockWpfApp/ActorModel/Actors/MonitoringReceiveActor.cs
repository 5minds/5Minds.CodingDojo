using System;
using Akka.Actor;
using Akka.Monitoring;

namespace BerlinClockWpfApp.ActorModel.Actors
{
    public class MonitoringReceiveActor : ReceiveActor
    {
        protected void ReceiveAndMonitor<T>(Func<T, bool> handler)
        {
            Context.IncrementMessagesReceived(1, 1);
            Context.IncrementCounter( typeof(T).ToString());
            Receive(handler);
        }

        protected void ReceiveAndMonitor<T>(Action<T> handler, Predicate<T> shouldHandle = null)
        {
            Context.IncrementMessagesReceived(1, 1);
            Receive(handler, shouldHandle);
        }

        protected override void PreStart()
        {
            Context.IncrementActorCreated(1, 1);
            base.PreStart();
        }

        protected override void PostStop()
        {
            Context.IncrementActorStopped(1, 1);
            base.PostStop();
        }
    }
}