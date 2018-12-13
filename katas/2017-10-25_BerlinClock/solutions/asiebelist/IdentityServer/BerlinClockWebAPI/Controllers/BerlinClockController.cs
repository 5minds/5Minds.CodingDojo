using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerlinClockWebAPI.Models;
using System.Security.Claims;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace BerlinClockWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BerlinClockController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [Route("GetTime")] 
        public ActionResult Get()
        {
            var caller = User as ClaimsPrincipal;
            BerlinClockTime berlinClockTime = new BerlinClockTime();
            return Json(berlinClockTime);
        }
    }
}
