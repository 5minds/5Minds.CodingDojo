using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace clockApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BerlinClockController : ControllerBase
    {
        private readonly ILogger<BerlinClockController> _logger;

        public BerlinClockController(ILogger<BerlinClockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public BerlinClock Get()
        {
            var currentTime = DateTime.Now;
            return new BerlinClock
            {
                HoursBaseFive = currentTime.Hour / 5,
                HoursBaseRemainder = currentTime.Hour % 5,
                MinutesBaseFive = currentTime.Minute / 5,
                MinutesBaseRemainder = currentTime.Minute % 5,
            };
        }
    }
}
