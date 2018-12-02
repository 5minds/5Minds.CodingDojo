namespace BerlinClockWpfApp.ActorModel.Actors.UI
{
    using System;

    using Akka.Actor;

    public class SecondsActor : ReceiveActor
    {
        #region Constructors and Destructors

        public SecondsActor(Action toggleOn, Action toggleOff)
        {
            Receive<Messages.TickerMessage>(
                message =>
                {
                    if (message.SecondToggle == 0)
                    {
                        toggleOn?.Invoke();
                    }
                    else
                    {
                        toggleOff?.Invoke();
                    }
                });
        }

        #endregion
    }
}