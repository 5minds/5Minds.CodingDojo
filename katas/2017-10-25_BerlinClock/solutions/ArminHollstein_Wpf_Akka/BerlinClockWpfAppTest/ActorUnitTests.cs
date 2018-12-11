using System;
using Akka.Actor;
using BerlinClockWpfApp.ActorModel.Actors;
using BerlinClockWpfApp.ActorModel.Actors.UI;
using BerlinClockWpfApp.ActorModel.Messages;
using Xunit;
namespace BerlinClockWpfAppTest
{
    public class ActorUnitTests : TestBase
    {
        [Fact]
        public void TickerLookUpActorShouldReturnNow()
        {
            var now = DateTime.Now;
            var subject = Sys.ActorOf(Props.Create(() => new TickerLookUpActor(new TestTickerService(now))));

            subject.Tell(new RefreshTickerMessage());

            var result = ExpectMsg<UpdateTickerMessage>().Tick;

            Assert.True(result == now);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void SecondsActorShouldToggle(int second)
        {
            //Arrange
            DateTime tick = new DateTime(2018, 11, 30, 22, 40, second);
            toggle = null;

            var subject = Sys.ActorOf(Props.Create(() => new SecondsActor((Action)ToggleOn, (Action)ToggleOff)));

            //Act
            subject.Tell(new TickerMessage(tick));

            this.ExpectNoMsg();

            //Assert
            if (second % 2 == 1)
            {
                Assert.False(toggle);
            }
            else
            {
                Assert.True(toggle);
            }

        }

        [Theory]
        [ClassData(typeof(TestDataForMinutesActor))]
        public void MinutesActorShouldToggle(int minuteUISlot, int minutes)
        {
            //Arrange
            DateTime tick = new DateTime(2018, 11, 30, 22, minutes, 0);
            toggle = null;

            // var subject = Sys.ActorOf(Props.Create(() => new MinutesActor(minuteUISlot, (Action)ToggleOn, (Action)ToggleOff)));
            var subject = ActorOfAsTestActorRef<MinutesActor>(Props.Create(() => new MinutesActor(minuteUISlot, (Action)ToggleOn, (Action)ToggleOff)));
            var tickerMessage = new TickerMessage(tick);

            //Act
            subject.Tell(tickerMessage);

            this.ExpectNoMsg(1);

            //Assert
            if (subject.UnderlyingActor.IsMinuteRow(tickerMessage.Minutes) || subject.UnderlyingActor.Is5MinuteRow(tickerMessage.Minutes))
            {
                Assert.True(toggle);
            }
            else
            {
                Assert.False(toggle);
            }

        }

        [Theory]
        [ClassData(typeof(TestDataForHoursActor))]
        public void HoursActorShouldToggle(int hourUISlot, int hours)
        {
            //Arrange
            DateTime tick = new DateTime(2018, 11, 30, hours, 0, 0);
            toggle = null;

            // var subject = Sys.ActorOf(Props.Create(() => new MinutesActor(minuteUISlot, (Action)ToggleOn, (Action)ToggleOff)));
            var subject = ActorOfAsTestActorRef<HoursActor>(Props.Create(() => new HoursActor(hourUISlot, (Action)ToggleOn, (Action)ToggleOff)));
            var tickerMessage = new TickerMessage(tick);

            //Act
            subject.Tell(tickerMessage);

            this.ExpectNoMsg(1);

            //Assert
            if (subject.UnderlyingActor.IsHourRow(tickerMessage.Hours) || subject.UnderlyingActor.Is5HourRow(tickerMessage.Hours))
            {
                Assert.True(toggle);
            }
            else
            {
                Assert.False(toggle);
            }

        }
    }
}