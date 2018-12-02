namespace BerlinClockWpfApp.ActorModel.Messages
{
    using Akka.Actor;

    public class UnsubscribeFromTickerMessage
    {
        #region Constructors and Destructors

        public UnsubscribeFromTickerMessage(IActorRef unsubscribingActor)
        {
            Subscriber = unsubscribingActor;
        }

        #endregion

        #region Public Properties

        public IActorRef Subscriber { get; private set; }

        #endregion
    }
}