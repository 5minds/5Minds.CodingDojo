using Akka.Actor;
using Akka.DI.Core;
using Autofac;
using BerlinClockWpfApp.ActorModel.Actors;
using BerlinClockWpfApp.ActorModel.Actors.UI;
using BerlinClockWpfApp.ActorModel.Messages;
using BerlinClockWpfApp.Services;
using System;
using Xunit;

namespace BerlinClockWpfAppTest
{
    public class ActorIntegrationTest:TestBase
    {
        [Theory]
        [InlineData(10, 4, M01On, M02On, M03On, M04On, M05Off, M10Off, M15Off, M20Off, M25Off, M30Off, M35Off, M40Off, M45Off, M50Off, M55Off, H01Off, H02Off, H03Off, H04Off, H05On, H10On, H15Off, H20Off)]
        [InlineData(15, 23, M01On, M02On, M03On, M04Off, M05On, M10On, M15On, M20On, M25Off, M30Off, M35Off, M40Off, M45Off, M50Off, M55Off, H01Off, H02Off, H03Off, H04Off, H05On, H10On, H15On, H20Off)]
        public void Test(
     int hours,
     int minutes,
     bool is1Minute,
     bool is2Minute,
     bool is3Minute,
     bool is4Minute,
     bool is05Minute,
     bool is10Minute,
     bool is15Minute,
     bool is20Minute,
     bool is25Minute,
     bool is30Minute,
     bool is35Minute,
     bool is40Minute,
     bool is45Minute,
     bool is50Minute,
     bool is55Minute,
     bool is01Hour,
     bool is02Hour,
     bool is03Hour,
     bool is04Hour,
     bool is05Hour,
     bool is10Hour,
     bool is15Hour,
     bool is20Hour)
        {
            DateTime tick = new DateTime(2018, 12, 2, hours, minutes, 0);
            //Arrange
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new TestTickerService(tick)).As<ITickerService>();
            containerBuilder.RegisterType<TickerLookUpActor>().AsSelf();
            var container = containerBuilder.Build();

            Sys.UseAutofac(container, out IDependencyResolver resolver);

            var publishingTickerActor = ActorOfAsTestActorRef<PublishingTickerActor>(Props.Create(() => new PublishingTickerActor(false)));

            var minutes1Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(1, (Action)Toggle1MinuteOn, (Action)Toggle1MinuteOff)));
            var minutes2Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(2, (Action)Toggle2MinuteOn, (Action)Toggle2MinuteOff)));
            var minutes3Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(3, (Action)Toggle3MinuteOn, (Action)Toggle3MinuteOff)));
            var minutes4Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(4, (Action)Toggle4MinuteOn, (Action)Toggle4MinuteOff)));

            var minutes05Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(5, (Action)Toggle05MinuteOn, (Action)Toggle05MinuteOff)));
            var minutes10Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(10, (Action)Toggle10MinuteOn, (Action)Toggle10MinuteOff)));
            var minutes15Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(15, (Action)Toggle15MinuteOn, (Action)Toggle15MinuteOff)));
            var minutes20Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(20, (Action)Toggle20MinuteOn, (Action)Toggle20MinuteOff)));
            var minutes25Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(25, (Action)Toggle25MinuteOn, (Action)Toggle25MinuteOff)));
            var minutes30Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(30, (Action)Toggle30MinuteOn, (Action)Toggle30MinuteOff)));
            var minutes35Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(35, (Action)Toggle35MinuteOn, (Action)Toggle35MinuteOff)));
            var minutes40Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(40, (Action)Toggle40MinuteOn, (Action)Toggle40MinuteOff)));
            var minutes45Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(45, (Action)Toggle45MinuteOn, (Action)Toggle45MinuteOff)));
            var minutes50Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(50, (Action)Toggle50MinuteOn, (Action)Toggle50MinuteOff)));
            var minutes55Actor = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(55, (Action)Toggle55MinuteOn, (Action)Toggle55MinuteOff)));

            var hours01Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(1, (Action)Toggle01HourOn, (Action)Toggle01HourOff)));
            var hours02Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(2, (Action)Toggle02HourOn, (Action)Toggle02HourOff)));
            var hours03Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(3, (Action)Toggle03HourOn, (Action)Toggle03HourOff)));
            var hours04Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(4, (Action)Toggle04HourOn, (Action)Toggle04HourOff)));
            var hours05Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(5, (Action)Toggle05HourOn, (Action)Toggle05HourOff)));
            var hours10Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(10, (Action)Toggle10HourOn, (Action)Toggle10HourOff)));
            var hours15Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(15, (Action)Toggle15HourOn, (Action)Toggle15HourOff)));
            var hours20Actor = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(20, (Action)Toggle20HourOn, (Action)Toggle20HourOff)));

            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes1Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes2Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes3Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes4Actor));

            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes05Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes10Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes15Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes20Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes25Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes30Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes35Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes40Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes45Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes50Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(minutes55Actor));

            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours01Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours02Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours03Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours04Actor));

            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours05Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours10Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours15Actor));
            publishingTickerActor.Tell(new SubscribeToTickerMessage(hours20Actor));

            //Act
            publishingTickerActor.Tell(new RefreshTickerMessage());

            ExpectNoMsg(5000);

            //Assert
            Assert.True(toggle1Minute == is1Minute);
            Assert.True(toggle2Minute == is2Minute);
            Assert.True(toggle3Minute == is3Minute);
            Assert.True(toggle4Minute == is4Minute);
            Assert.True(toggle05Minute == is05Minute);
            Assert.True(toggle10Minute == is10Minute);
            Assert.True(toggle15Minute == is15Minute);
            Assert.True(toggle20Minute == is20Minute);
            Assert.True(toggle25Minute == is25Minute);
            Assert.True(toggle30Minute == is30Minute);
            Assert.True(toggle35Minute == is35Minute);
            Assert.True(toggle40Minute == is40Minute);
            Assert.True(toggle45Minute == is45Minute);
            Assert.True(toggle50Minute == is50Minute);
            Assert.True(toggle55Minute == is55Minute);
            Assert.True(toggle01Hour == is01Hour);
            Assert.True(toggle02Hour == is02Hour);
            Assert.True(toggle03Hour == is03Hour);
            Assert.True(toggle04Hour == is04Hour);
            Assert.True(toggle05Hour == is05Hour);
            Assert.True(toggle10Hour == is10Hour);
            Assert.True(toggle15Hour == is15Hour);
            Assert.True(toggle20Hour == is20Hour);
        }
    }
}
