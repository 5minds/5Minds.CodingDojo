using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Entities;
using Recruiting.SyrtsouD.Holidays.API.Responses;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public interface IHolidayResponseFactory
	{
		HolidayResponse Create(IReadOnlyCollection<IHoliday> holidays);
	}
}