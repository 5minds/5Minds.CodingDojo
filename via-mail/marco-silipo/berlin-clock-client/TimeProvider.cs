using System;
using System.Net.Http;
using System.Threading.Tasks;
using BerlinClock.WebApi;

namespace BerlinClock.Client
{
    public class TimeProvider
    {
        private DateTime _lastReceived = DateTime.MinValue;
        private BerlinClockTime _berlinClockTime = new();

        public async Task<BerlinClockTime> GetBerlinClockTimeAsync(string baseUrl, HttpClient httpClient)
        {
            var now = DateTime.Now;
            if (_lastReceived.Minute != now.Minute && _lastReceived.Hour != now.Hour)
            {
                var apiClient = new WebApi.Client(baseUrl, httpClient);
                _berlinClockTime = await apiClient.GetBerlinClockTimeAsync();
                _lastReceived = now;
            }
            return _berlinClockTime;
        }
    }
}