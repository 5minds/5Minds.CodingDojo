namespace BerlinClockWpfApp.ActorModel
{
    using Akka.Actor;
    using Akka.DI.Core;

    using Autofac;

    using BerlinClockWpfApp.ActorModel.Actors;
    using BerlinClockWpfApp.Services;

    public static class ActorSystemReference
    {
        #region Constructors and Destructors

        static ActorSystemReference()
        {
            ActorSystem = ActorSystem.Create("BerlinClockActorSystem");

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<TickerService>().As<ITickerService>();
            containerBuilder.RegisterType<TickerLookUpActor>().AsSelf();
            var container = containerBuilder.Build();
            IDependencyResolver resolver = null;
            ActorSystem.UseAutofac(container, out resolver);
        }

        #endregion

        #region Public Properties

        public static ActorSystem ActorSystem { get; private set; }

        #endregion
    }
}