namespace DotnetHello.Features.Home
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/hello")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {

            Dictionary<string, string> result = new Dictionary<string, string>() {
                {"greeting", "hello"},
                {"name", "world"}
            };

            return this.Ok(result);
        }
    }
}