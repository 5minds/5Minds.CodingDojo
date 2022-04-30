namespace Recruiting.SyrtsouD.Holidays.API.Entities
{
	public interface IHoliday
	{
		string Name { get; }

		string Description { get; }

		int Day { get; }

		int Month { get; }
	}
}
