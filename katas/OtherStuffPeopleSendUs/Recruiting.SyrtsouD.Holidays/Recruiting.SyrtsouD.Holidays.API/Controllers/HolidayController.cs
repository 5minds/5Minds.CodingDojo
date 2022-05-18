using Microsoft.AspNetCore.Mvc;
using Recruiting.SyrtsouD.Holidays.API.Factories;
using Recruiting.SyrtsouD.Holidays.API.Requests;
using Recruiting.SyrtsouD.Holidays.API.Responses;
using Recruiting.SyrtsouD.Holidays.API.Services;

namespace Recruiting.SyrtsouD.Holidays.API.Controllers
{
	[Route("api/holiday")]
	[ApiController]
	public class HolidayController : ControllerBase
	{
		private readonly IHolidayService _service;
		private readonly IHolidayCriteriaFactory _criteriaFactory;
		private readonly IHolidayResponseFactory _responseFactory;

		public HolidayController(IHolidayService service, IHolidayCriteriaFactory criteriaFactory, IHolidayResponseFactory responseFactory)
		{
			_service = service;
			_criteriaFactory = criteriaFactory;
			_responseFactory = responseFactory;
		}

		[HttpGet]
		public ActionResult<HolidayResponse> Get([FromQuery]HolidaysRequest request)
		{
			var criteria = _criteriaFactory.Create(request);
			var holidays = _service.GetHolidays(criteria);
			var response = _responseFactory.Create(holidays);

			return new ActionResult<HolidayResponse>(response);
		}
	}
}
