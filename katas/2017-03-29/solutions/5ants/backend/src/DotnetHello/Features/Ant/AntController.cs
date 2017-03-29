namespace DotnetHello.Features.Ant
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/ant")]
    public class AntController : Controller
    {
        [HttpGet("init/{length}/{startPos}/{direction}")]
        public IActionResult Init(int length, string startPos, string direction)
        {
            var result = Guid.NewGuid();

            return this.Ok(result);
        }

        public IActionResult Next(Guid board) {
            var result = new Board();

            return this.Ok(result);
        }
    }
}