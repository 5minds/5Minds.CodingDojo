using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerlinClockView.Models
{
    public class BerlinClockTime
    {
        public int Seconds { get; set; }
        public int FiveHours { get; set; }
        public int SingleHours { get; set; }
        public int FiveMinutes { get; set; }
        public int SingleMinutes { get; set; }

        public BerlinClockTime()
        {

        }
    }
}
