namespace BerlinClockWpfApp.ActorModel.Messages
{
    using Akka.Actor;

    public class SubscribeToTickerMessage
    {
        #region Constructors and Destructors

        public SubscribeToTickerMessage(IActorRef subscribingActor)
        {
            Subscriber = subscribingActor;
        }

        #endregion

        #region Public Properties

        public IActorRef Subscriber { get; private set; }

        #endregion
    }
}