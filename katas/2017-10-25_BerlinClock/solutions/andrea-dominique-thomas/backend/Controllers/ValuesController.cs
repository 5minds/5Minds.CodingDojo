using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BerlinUhr.RestService.Controllers
{
    [Route("api/[controller]")]
    public class BerlinTimeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<bool> Get()
        {
            DateTime current_time = DateTime.Now;
            
            return new bool[]
            { 
                current_time.Second % 2 == 1,
                current_time.Hour >= 5,
                current_time.Hour >= 10,
                current_time.Hour >= 15,
                current_time.Hour >= 20,
                (current_time.Hour % 5) > 0,
                (current_time.Hour % 5) > 1,
                (current_time.Hour % 5) > 2,
                (current_time.Hour % 5) > 3,
                current_time.Minute >= 5,
                current_time.Minute >= 10,
                current_time.Minute >= 15,
                current_time.Minute >= 20,
                current_time.Minute >= 25,
                current_time.Minute >= 30,
                current_time.Minute >= 35,
                current_time.Minute >= 40,
                current_time.Minute >= 45,
                current_time.Minute >= 50,
                current_time.Minute >= 55,
                (current_time.Minute % 5) > 0,
                (current_time.Minute % 5) > 1,
                (current_time.Minute % 5) > 2,
                (current_time.Minute % 5) > 3,
            };
        }
    }
}