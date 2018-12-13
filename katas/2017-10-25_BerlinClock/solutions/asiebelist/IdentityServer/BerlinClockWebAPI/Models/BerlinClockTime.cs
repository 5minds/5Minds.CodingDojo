using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerlinClockWebAPI.Models
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
            Seconds = (DateTime.Now.Second % 2 == 0) ? 1 : 0;
            FiveHours = DateTime.Now.Hour / 5;
            SingleHours = DateTime.Now.Hour % 5;
            FiveMinutes = DateTime.Now.Minute / 5;
            SingleMinutes = DateTime.Now.Minute % 5;
        }
    }
}
