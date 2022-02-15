using System.Collections.Generic;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;

namespace Recruiting.SyrtsouD.Holidays.API.Services
{
	public class HolidayService : IHolidayService
	{
		public IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria)
		{
			return new IHoliday[]
			{
				new Holiday
				{
					Name = "Christmas",
					Description =
						"Christmas is an annual festival commemorating the birth of Jesus Christ, observed primarily on December 25 as a religious and cultural celebration among billions of people around the world.",
					Day = 25,
					Month = 12
				},
				new Holiday
				{
					Name = "New Year",
					Description =
						"New Year is the time or day currently at which a new calendar year begins and the calendar's year count increments by one.",
					Day = 1,
					Month = 1
				}
			};
		}
	}
}