using System;
using System.Collections.Generic;

namespace Recruiting.SyrtsouD.Holidays.API.Responses
{
	public class HolidayResponse
	{
		public IReadOnlyCollection<HolidayEntry> Holidays { get; set; } = Array.Empty<HolidayEntry>();
	}
}