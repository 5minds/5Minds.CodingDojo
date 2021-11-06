using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BerlinClock.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BerlinClockTimeController : ControllerBase
    {
        public BerlinClockTimeController()
        {
        }

        [HttpGet(Name = "GetBerlinClockTime")]
        public BerlinClockTime Get()
        {
            return BerlinClockTime.Now;
        }
    }
}