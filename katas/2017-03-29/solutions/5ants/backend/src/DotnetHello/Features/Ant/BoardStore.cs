namespace DotnetHello.Features.Ant
{
    using System;
    using System.Collections.Generic;

    public class BoardStore
    {
       public static IDictionary<Guid, Board> Boards { get; } = new Dictionary<Guid, Board>();

       public static Guid CreateBoard(int length, int posX, int posY, string direction)
       {
            var board = new Board(length, posX, posX, direction);
            Boards.Add(board.Id, board);

            return board.Id;
       }
    }
}