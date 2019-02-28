using System;
using System.Collections;
using System.Collections.Generic;
using Akka.TestKit.Xunit;
using BerlinClockWpfApp.Services;

namespace BerlinClockWpfAppTest
{
    public class TestBase : TestKit
    {
        protected const bool M01On = true;
        protected const bool M01Off = false;
        protected const bool M02On = true;
        protected const bool M02Off = false;
        protected const bool M03On = true;
        protected const bool M03Off = false;
        protected const bool M04On = true;
        protected const bool M04Off = false;
        protected const bool M05On = true;
        protected const bool M05Off = false;
        protected const bool M10On = true;
        protected const bool M10Off = false;
        protected const bool M15On = true;
        protected const bool M15Off = false;
        protected const bool M20On = true;
        protected const bool M20Off = false;
        protected const bool M25On = true;
        protected const bool M25Off = false;
        protected const bool M30On = true;
        protected const bool M30Off = false;
        protected const bool M35On = true;
        protected const bool M35Off = false;
        protected const bool M40On = true;
        protected const bool M40Off = false;
        protected const bool M45On = true;
        protected const bool M45Off = false;
        protected const bool M50On = true;
        protected const bool M50Off = false;
        protected const bool M55On = true;
        protected const bool M55Off = false;
        protected const bool H01On = true;
        protected const bool H01Off = false;
        protected const bool H02On = true;
        protected const bool H02Off = false;
        protected const bool H03On = true;
        protected const bool H03Off = false;
        protected const bool H04On = true;
        protected const bool H04Off = false;
        protected const bool H05On = true;
        protected const bool H05Off = false;
        protected const bool H10On = true;
        protected const bool H10Off = false;
        protected const bool H15On = true;
        protected const bool H15Off = false;
        protected const bool H20On = true;
        protected const bool H20Off = false;

        protected class TestTickerService : ITickerService
        {
            private readonly DateTime _testTick;

            public TestTickerService(DateTime testTick)
            {
                this._testTick = testTick;
            }
            public DateTime GetNewTick()
            {
                return _testTick;
            }
        }

        protected class TestDataForMinutesActor : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>();
            public TestDataForMinutesActor() => Init();

            private void Init()
            {
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        _data.Add(new object[] { i, j });
                    }
                }
                for (int i = 5; i < 60; i += 5)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        _data.Add(new object[] { i, j });
                    }
                }
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        protected class TestDataForHoursActor : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>();
            public TestDataForHoursActor() => Init();

            private void Init()
            {
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        _data.Add(new object[] { i, j });
                    }
                }
                for (int i = 5; i < 24; i += 5)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        _data.Add(new object[] { i, j });
                    }
                }
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        static protected bool? toggle = null;
        static protected bool? toggle1Minute = null;
        static protected bool? toggle2Minute = null;
        static protected bool? toggle3Minute = null;
        static protected bool? toggle4Minute = null;
        static protected bool? toggle05Minute = null;
        static protected bool? toggle10Minute = null;
        static protected bool? toggle15Minute = null;
        static protected bool? toggle20Minute = null;
        static protected bool? toggle25Minute = null;
        static protected bool? toggle30Minute = null;
        static protected bool? toggle35Minute = null;
        static protected bool? toggle40Minute = null;
        static protected bool? toggle45Minute = null;
        static protected bool? toggle50Minute = null;
        static protected bool? toggle55Minute = null;
        static protected bool? toggle01Hour = null;
        static protected bool? toggle02Hour = null;
        static protected bool? toggle03Hour = null;
        static protected bool? toggle04Hour = null;
        static protected bool? toggle05Hour = null;
        static protected bool? toggle10Hour = null;
        static protected bool? toggle15Hour = null;
        static protected bool? toggle20Hour = null;

        protected void ToggleOn()
        {
            toggle = true;
        }
        protected void ToggleOff()
        {
            toggle = false;
        }

        protected void Toggle1MinuteOn()
        {
            toggle1Minute = true;
        }
        protected void Toggle1MinuteOff()
        {
            toggle1Minute = false;
        }

        protected void Toggle2MinuteOn()
        {
            toggle2Minute = true;
        }
        protected void Toggle2MinuteOff()
        {
            toggle2Minute = false;
        }

        protected void Toggle3MinuteOn()
        {
            toggle3Minute = true;
        }
        protected void Toggle3MinuteOff()
        {
            toggle3Minute = false;
        }

        protected void Toggle4MinuteOn()
        {
            toggle4Minute = true;
        }
        protected void Toggle4MinuteOff()
        {
            toggle4Minute = false;
        }

        protected void Toggle05MinuteOn()
        {
            toggle05Minute = true;
        }
        protected void Toggle05MinuteOff()
        {
            toggle05Minute = false;
        }

        protected void Toggle10MinuteOn()
        {
            toggle10Minute = true;
        }
        protected void Toggle10MinuteOff()
        {
            toggle10Minute = false;
        }

        protected void Toggle15MinuteOn()
        {
            toggle15Minute = true;
        }
        protected void Toggle15MinuteOff()
        {
            toggle15Minute = false;
        }

        protected void Toggle20MinuteOn()
        {
            toggle20Minute = true;
        }
        protected void Toggle20MinuteOff()
        {
            toggle20Minute = false;
        }

        protected void Toggle25MinuteOn()
        {
            toggle25Minute = true;
        }
        protected void Toggle25MinuteOff()
        {
            toggle25Minute = false;
        }

        protected void Toggle30MinuteOn()
        {
            toggle30Minute = true;
        }
        protected void Toggle30MinuteOff()
        {
            toggle30Minute = false;
        }

        protected void Toggle35MinuteOn()
        {
            toggle35Minute = true;
        }
        protected void Toggle35MinuteOff()
        {
            toggle35Minute = false;
        }

        protected void Toggle40MinuteOn()
        {
            toggle40Minute = true;
        }
        protected void Toggle40MinuteOff()
        {
            toggle40Minute = false;
        }

        protected void Toggle45MinuteOn()
        {
            toggle45Minute = true;
        }
        protected void Toggle45MinuteOff()
        {
            toggle45Minute = false;
        }

        protected void Toggle50MinuteOn()
        {
            toggle50Minute = true;
        }
        protected void Toggle50MinuteOff()
        {
            toggle50Minute = false;
        }

        protected void Toggle55MinuteOn()
        {
            toggle55Minute = true;
        }
        protected void Toggle55MinuteOff()
        {
            toggle55Minute = false;
        }

        protected void Toggle01HourOn()
        {
            toggle01Hour = true;
        }
        protected void Toggle01HourOff()
        {
            toggle01Hour = false;
        }

        protected void Toggle02HourOn()
        {
            toggle02Hour = true;
        }
        protected void Toggle02HourOff()
        {
            toggle02Hour = false;
        }

        protected void Toggle03HourOn()
        {
            toggle03Hour = true;
        }
        protected void Toggle03HourOff()
        {
            toggle03Hour = false;
        }

        protected void Toggle04HourOn()
        {
            toggle04Hour = true;
        }
        protected void Toggle04HourOff()
        {
            toggle04Hour = false;
        }

        protected void Toggle05HourOn()
        {
            toggle05Hour = true;
        }
        protected void Toggle05HourOff()
        {
            toggle05Hour = false;
        }

        protected void Toggle10HourOn()
        {
            toggle10Hour = true;
        }
        protected void Toggle10HourOff()
        {
            toggle10Hour = false;
        }

        protected void Toggle15HourOn()
        {
            toggle15Hour = true;
        }
        protected void Toggle15HourOff()
        {
            toggle15Hour = false;
        }

        protected void Toggle20HourOn()
        {
            toggle20Hour = true;
        }
        protected void Toggle20HourOff()
        {
            toggle20Hour = false;
        }
    }
}