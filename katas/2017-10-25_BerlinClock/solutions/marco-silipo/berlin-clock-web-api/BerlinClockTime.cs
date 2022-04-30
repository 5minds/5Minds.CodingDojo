using System;

namespace BerlinClock.WebApi
{
    public struct BerlinClockTime
    {
        /// <summary>
        /// <list type="bullet">
        /// <item>0: 0 hours.</item>
        /// <item>1: 5 hours.</item>
        /// <item>2: 10 hours.</item>
        /// <item>3: 15 hours.</item>
        /// <item>4: 20 hours.</item>
        /// </list>
        ///
        /// Anything else is invalid.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value provided is larger then four or less then zero.
        /// </exception>
        public int HourFive
        {
            get => _hourFive;
            set
            {
                if (value is < 0 or > 4)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value has to be between 0 and 4");
                _hourFive = value;
            }
        }

        private int _hourFive;

        /// <summary>
        /// <list type="bullet">
        /// <item>0: 0 hours.</item>
        /// <item>1: 1 hours.</item>
        /// <item>2: 2 hours.</item>
        /// <item>3: 3 hours.</item>
        /// <item>4: 4 hours.</item>
        /// </list>
        ///
        /// Anything else is invalid.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value provided is larger then four or less then zero.
        /// </exception>
        public int HourOne
        {
            get => _hourOne;
            set
            {
                if (value is < 0 or > 4)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value has to be between 0 and 4");
                _hourOne = value;
            }
        }

        private int _hourOne;

        /// <summary>
        /// <list type="bullet">
        /// <item> 0:  0 minutes.</item>
        /// <item> 1:  5 minutes.</item>
        /// <item> 2: 10 minutes.</item>
        /// <item> 3: 15 minutes.</item>
        /// <item> 4: 20 minutes.</item>
        /// <item> 5: 25 minutes.</item>
        /// <item> 6: 30 minutes.</item>
        /// <item> 7: 35 minutes.</item>
        /// <item> 8: 40 minutes.</item>
        /// <item> 9: 45 minutes.</item>
        /// <item>10: 50 minutes.</item>
        /// <item>11: 55 minutes.</item>
        /// </list>
        ///
        /// Anything else is invalid.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value provided is larger then eleven or less then zero.
        /// </exception>
        public int MinuteFive
        {
            get => _minuteFive;
            set
            {
                if (value is < 0 or > 11)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value has to be between 0 and 11");
                _minuteFive = value;
            }
        }

        private int _minuteFive;

        /// <summary>
        /// <list type="bullet">
        /// <item>0: 0 minutes.</item>
        /// <item>1: 1 minutes.</item>
        /// <item>2: 2 minutes.</item>
        /// <item>3: 3 minutes.</item>
        /// <item>4: 4 minutes.</item>
        /// </list>
        ///
        /// Anything else is invalid.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value provided is larger then four or less then zero.
        /// </exception>
        public int MinuteOne
        {
            get => _minuteOne;
            set
            {
                if (value is < 0 or > 4)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value has to be between 0 and 4");
                _minuteOne = value;
            }
        }

        public static BerlinClockTime Now
        {
            get
            {
                var today = DateTime.Today;
                var now = DateTime.Now;
                var span = now - today;
                return new BerlinClockTime
                {
                    HourFive = span.Hours / 5,
                    HourOne = span.Hours % 5,
                    MinuteFive = span.Minutes / 5,
                    MinuteOne = span.Minutes % 5,
                };
            }
        }

        private int _minuteOne;
    }
}