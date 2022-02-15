using System.Collections.Generic;
using System.Linq;
using Recruiting.SyrtsouD.Holidays.API.Entities;
using Recruiting.SyrtsouD.Holidays.API.Responses;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public class HolidayResponseFactory : IHolidayResponseFactory
	{
		public HolidayResponse Create(IReadOnlyCollection<IHoliday> holidays)
		{
			return new HolidayResponse
			{
				Holidays = holidays.Select(Create).ToArray()
			};
		}

		protected internal virtual HolidayEntry Create(IHoliday holiday)
		{
			return new HolidayEntry
			{
				Name = holiday.Name,
				Description = holiday.Description,
				DateFormatted = $"{holiday.Day:00}.{holiday.Month:00}"
			};
		}
	}
}