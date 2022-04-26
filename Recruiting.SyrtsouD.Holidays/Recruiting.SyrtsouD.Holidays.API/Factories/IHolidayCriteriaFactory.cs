using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Requests;

namespace Recruiting.SyrtsouD.Holidays.API.Factories
{
	public interface IHolidayCriteriaFactory
	{
		IHolidayCriteria Create(HolidaysRequest request);
	}
}
