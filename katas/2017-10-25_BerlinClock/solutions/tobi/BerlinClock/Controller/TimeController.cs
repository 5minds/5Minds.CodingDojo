using BerlinClock.Model;
using BerlinClock.Services;
using Microsoft.AspNetCore.Mvc;

namespace BerlinClock.Controller
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly IClockService _clockService;

        public TimeController(IClockService clockService)
        {
            _clockService = clockService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SegmentModel), 200)]
        public SegmentModel GetSegmentedTime()
        {
            return _clockService.GetTimeSegments(DateTime.Now);
        }
    }
}
