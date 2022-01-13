using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeschenkeMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetRoutefromString : ControllerBase
    {
    
        private readonly ILogger<GetRoutefromString> _logger;

        public GetRoutefromString(ILogger<GetRoutefromString> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string route)
        {
            RouteDefinition currentRoute = new RouteDefinition(route);
            return currentRoute.getAsJSON();
            
        }
    }
}
