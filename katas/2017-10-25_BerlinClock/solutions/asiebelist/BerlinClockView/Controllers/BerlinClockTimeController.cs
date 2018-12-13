using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BerlinClockView.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace BerlinClockView.Controllers
{
    [Route("[controller]")]
    public class BerlinClockTimeController : Controller
    {
        private IMemoryCache _cache;
        
        public BerlinClockTimeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        [Route("~/")]
        public async Task<IActionResult> Index()
        {
            string token = GetToken(false);

           

            var APIclient = new HttpClient();
            APIclient.SetBearerToken(token);

            string path = "http://localhost:50002/api/BerlinClock/GetTime";
            HttpResponseMessage response = await APIclient.GetAsync(path);
            BerlinClockTime model = new BerlinClockTime();
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<BerlinClockTime>();
            }
            
            return View(model);
        }

        [HttpGet]
        [Route("TimeUpdateAsync")]
        public async Task<JsonResult> TimeUpdateAsync()
        {
            string token = GetToken(false);

            string path = "http://localhost:50002/api/BerlinClock/GetTime";
            HttpResponseMessage response = await GetHttpResponseAsync(path, token);
            BerlinClockTime model = new BerlinClockTime();
            int timeout = 5;

            //Sollte ein Token nicht mehr gültig sein, soll ein neuer angefordert werden
            while (!response.IsSuccessStatusCode && timeout>0)
            {
                token = GetToken(true);
                timeout--;
                response = await GetHttpResponseAsync(path, token);
            }
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<BerlinClockTime>();
            }

            return Json(model);
        }

        private String GetToken(bool newToken)
        {
            string token;
            if (newToken || !_cache.TryGetValue(CacheKeys.Token, out token))
            {
                var Tokenclient = new TokenClient(
               "http://localhost:5000/connect/token",
               "berlinclock",
               "0Z46VDWJZlwPhQQYyd4PCOdoZXoy9ko6");


                var cacheEntryOptions = new MemoryCacheEntryOptions();

                token = Tokenclient.RequestClientCredentialsAsync("clockapi.read_only").Result.AccessToken;
                _cache.Set(CacheKeys.Token, token, cacheEntryOptions);

            }
            return token;
        }

        private async Task<HttpResponseMessage> GetHttpResponseAsync(string path, string token)
        {
     
            var APIclient = new HttpClient();
            APIclient.SetBearerToken(token);
            HttpResponseMessage httpResponse;

            httpResponse = await APIclient.GetAsync(path);

            return httpResponse;
        }
    }

}