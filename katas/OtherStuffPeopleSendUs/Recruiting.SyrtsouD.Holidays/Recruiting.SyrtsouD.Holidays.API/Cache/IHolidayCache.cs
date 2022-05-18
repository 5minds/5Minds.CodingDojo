using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Cache
{
	public interface IHolidayCache
	{
		bool TryGet(IHolidayCriteria criteria, out IReadOnlyCollection<IHoliday> holidays);

		void AddOrUpdate(IHolidayCriteria criteria, IReadOnlyCollection<IHoliday> holidays);
	}
}
