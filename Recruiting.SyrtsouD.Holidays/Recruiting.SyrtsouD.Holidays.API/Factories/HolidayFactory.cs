using Recruiting.SyrtsouD.Holidays.API.Clients;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public class HolidayFactory : IHolidayFactory
	{
		public IHoliday Create(CalendarificClient.CalendarificHolidayResponse holiday)
		{
			return new Holiday
			{
				Name = holiday.name,
				Description = holiday.description,
				Month = holiday.date.datetime.month,
				Day = holiday.date.datetime.day
			};
		}
	}
}