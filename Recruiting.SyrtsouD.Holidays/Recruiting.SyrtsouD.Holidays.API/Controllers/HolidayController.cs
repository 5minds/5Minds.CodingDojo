using Microsoft.AspNetCore.Mvc;
using Recruiting.SyrtsouD.Holidays.API.Requests;
using Recruiting.SyrtsouD.Holidays.API.Responses;

namespace Recruiting.SyrtsouD.Holidays.API.Controllers
{
	[Route("api/holiday")]
	[ApiController]
	public class HolidayController : ControllerBase
	{
		[HttpGet]
		public ActionResult<HolidayResponse> Get([FromQuery]HolidaysRequest request)
		{
			return new ActionResult<HolidayResponse>(new HolidayResponse
			{
				Holidays = new[]
				{
					new HolidayEntry
					{
						Name = "Christmas",
						Description =
							"Christmas is an annual festival commemorating the birth of Jesus Christ, observed primarily on December 25 as a religious and cultural celebration among billions of people around the world.",
						DateFormatted = "25.12"
					},
					new HolidayEntry
					{
						Name = "New Year",
						Description =
							"New Year is the time or day currently at which a new calendar year begins and the calendar's year count increments by one.",
						DateFormatted = "01.01"
					}
				}
			});
		}
	}
}
