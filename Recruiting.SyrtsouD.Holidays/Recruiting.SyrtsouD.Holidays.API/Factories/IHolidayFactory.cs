using Recruiting.SyrtsouD.Holidays.API.Clients;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public interface IHolidayFactory
	{
		IHoliday Create(CalendarificClient.CalendarificHolidayResponse holiday);
	}
}