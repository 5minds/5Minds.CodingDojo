using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Clients;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Services
{
	public class HolidayService : IHolidayService
	{
		private readonly ICalendarificClient _calendarificClient;

		public HolidayService(ICalendarificClient calendarificClient)
		{
			_calendarificClient = calendarificClient;
		}

		public IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria)
		{
			var result = _calendarificClient.GetHolidays(criteria);

			return result;
		}
	}
}