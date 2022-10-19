using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Services
{
	public interface IHolidayService
	{
		IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria);
	}
}
