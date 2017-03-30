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
            var posX = length/2;
            var posY = length/2;

            var result = BoardStore.CreateBoard(length, posX, posY, direction);

            return this.Ok(result);
        }

        [HttpGet("next/{boardId}")]
        public IActionResult Next(Guid boardId) {

            var board = BoardStore.Boards[boardId];
            board.Next();
            
            return this.Ok(board);
        }
    }
}