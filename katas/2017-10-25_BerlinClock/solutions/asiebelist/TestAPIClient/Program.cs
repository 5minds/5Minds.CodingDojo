using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestAPIClient.Models;

namespace TestAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Client Started!");

            Task.Delay(1000);

            CallApiAsync(GetClientToken()).Wait();

        }
        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "berlinclock",
                "0Z46VDWJZlwPhQQYyd4PCOdoZXoy9ko6");

            return client.RequestClientCredentialsAsync("clockapi.read_only").Result;
        }


        static async Task CallApiAsync(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            string timeData = "";
            using (Stream responseStream = await client.GetStreamAsync("http://localhost:50002/api/BerlinClock/GetTime"))
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                timeData += reader.ReadToEnd();
            }

            Console.Write(timeData);

            BerlinClockTime berlinClockTime = JsonConvert.DeserializeObject<BerlinClockTime>(timeData);

            Console.WriteLine(String.Format("Sekunden: {0}", berlinClockTime.Seconds));
            Console.WriteLine(String.Format("5 Stunden: {0}", berlinClockTime.FiveHours));
            Console.WriteLine(String.Format("Stunden: {0}", berlinClockTime.SingleHours));
            Console.WriteLine(String.Format("5 Minuten: {0}", berlinClockTime.FiveMinutes));
            Console.WriteLine(String.Format("Minuten: {0}", berlinClockTime.SingleMinutes));
            Console.ReadLine();
        }
    }
}
