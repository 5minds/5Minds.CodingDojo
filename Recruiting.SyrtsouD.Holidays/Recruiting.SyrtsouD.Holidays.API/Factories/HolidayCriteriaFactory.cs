using System;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Requests;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public class HolidayCriteriaFactory : IHolidayCriteriaFactory
	{
		public IHolidayCriteria Create(HolidaysRequest request)
		{
			return new HolidayCriteria
			{
				CountryCode = request.CountryCode,
				Year = request.Year ?? DateTime.UtcNow.Year
			};
		}
	}
}