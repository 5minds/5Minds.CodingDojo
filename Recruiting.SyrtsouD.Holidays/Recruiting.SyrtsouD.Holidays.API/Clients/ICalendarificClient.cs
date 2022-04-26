using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Clients
{
	public interface ICalendarificClient
	{
		IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria);
	}
}
