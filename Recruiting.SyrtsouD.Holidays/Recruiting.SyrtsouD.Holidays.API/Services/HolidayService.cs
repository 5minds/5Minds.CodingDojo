using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Cache;
using Recruiting.SyrtsouD.Holidays.API.Clients;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Services
{
	public class HolidayService : IHolidayService
	{
		private readonly ICalendarificClient _calendarificClient;
		private readonly IHolidayCache _cache;
		private static readonly object _sync = new object();

		public HolidayService(ICalendarificClient calendarificClient, IHolidayCache cache)
		{
			_calendarificClient = calendarificClient;
			_cache = cache;
		}

		public IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria)
		{
			if (!_cache.TryGet(criteria, out var result))
			{
				lock (_sync)
				{
					if (!_cache.TryGet(criteria, out result))
					{
						result = _calendarificClient.GetHolidays(criteria);

						_cache.AddOrUpdate(criteria, result);
					}
				}
			}

			return result;
		}
	}
}