using System;

namespace Recruiting.SyrtsouD.Holidays.API.Resolvers
{
	public class CalendarificConfigurationsResolver : ICalendarificConfigurationsResolver
	{
		public string ResolveApiKey()
		{
			return "0d72917fdf5362a4e525a25731642543794ac4d7";
		}

		public Uri ResolveBaseUri()
		{
			return new Uri("https://calendarific.com/api/v2/", UriKind.Absolute);
		}
	}
}