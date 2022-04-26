using System;

namespace Recruiting.SyrtsouD.Holidays.API.Resolvers
{
	public interface ICalendarificConfigurationsResolver
	{
		string ResolveApiKey();

		Uri ResolveBaseUri();
	}
}
