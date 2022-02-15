namespace Recruiting.SyrtsouD.Holidays.API.Entities
{
	public class Holiday : IHoliday
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public int Day { get; set; }

		public int Month { get; set; }
	}
}