using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Recruiting.SyrtsouD.Holidays.API.Criterias;
using Recruiting.SyrtsouD.Holidays.API.Entities;
using Recruiting.SyrtsouD.Holidays.API.Factories;
using Recruiting.SyrtsouD.Holidays.API.Resolvers;

namespace Recruiting.SyrtsouD.Holidays.API.Clients
{
	public class CalendarificClient : ICalendarificClient
	{
		private readonly HttpClient _httpClient = new HttpClient();
		private readonly ICalendarificConfigurationsResolver _configurationsResolver;
		private readonly IHolidayFactory _holidayFactory;

		public CalendarificClient(ICalendarificConfigurationsResolver configurationsResolver, IHolidayFactory holidayFactory)
		{
			_configurationsResolver = configurationsResolver;
			_holidayFactory = holidayFactory;
		}

		public IReadOnlyCollection<IHoliday> GetHolidays(IHolidayCriteria criteria)
		{
			var result = Array.Empty<IHoliday>();

			try
			{
				var baseUrl = _configurationsResolver.ResolveBaseUri();

				var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
				queryString["api_key"] = _configurationsResolver.ResolveApiKey();
				queryString["country"] = criteria.CountryCode;
				queryString["year"] = criteria.Year.ToString();
				queryString["type"] = "national";
				
				var targetUri = new Uri(baseUrl, $"holidays?{queryString}");

				var response = _httpClient.GetAsync(targetUri).Result;

				if (response.IsSuccessStatusCode)
				{
					var responseString = response.Content.ReadAsStringAsync().Result;

					var holidays = JsonConvert.DeserializeObject<CalendarificHolidaysFullResponse>(responseString);

					result = holidays?.response?.holidays?.Select(holiday => _holidayFactory.Create(holiday)).ToArray() ??
					         Array.Empty<IHoliday>();
				}
			}
			catch
			{
				// not addressing logging in this specific solution => we can discuss this during our interview.
			}

			return result;
		}

		public class CalendarificHolidaysFullResponse
		{
			public CalendarificHolidaysResponse response { get; set; }
		}

		public class CalendarificHolidaysResponse
		{
			public CalendarificHolidayResponse[] holidays { get; set; }
		}

		public class CalendarificHolidayResponse
		{
			public string name { get; set; }

			public string description { get; set; }

			public CalendarificDate date { get; set; }
		}

		public class CalendarificDate
		{
			public string iso { get; set; }

			public CalendarificDateTime datetime { get; set; }
		}

		public class CalendarificDateTime
		{
			public int day { get; set; }

			public int month { get; set; }

			public int year { get; set; }
		}
	}
}