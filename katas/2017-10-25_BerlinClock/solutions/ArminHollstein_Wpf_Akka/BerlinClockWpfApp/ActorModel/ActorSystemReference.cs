using Akka.Monitoring.PerformanceCounters;

namespace BerlinClockWpfApp.ActorModel
{
    using Akka;
    using Akka.Monitoring;
    using Akka.Monitoring.StatsD;
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

            if (Properties.Settings.Default.Monitoring)
            {
                ActorMonitoringExtension.RegisterMonitor(ActorSystem, new ActorPerformanceCountersMonitor());
            }

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