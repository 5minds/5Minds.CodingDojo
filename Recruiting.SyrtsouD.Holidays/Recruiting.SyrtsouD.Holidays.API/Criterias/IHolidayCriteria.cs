namespace Recruiting.SyrtsouD.Holidays.API.Criterias
{
	public interface IHolidayCriteria
	{
		string CountryCode { get; }

		int Year { get; }
	}
}
