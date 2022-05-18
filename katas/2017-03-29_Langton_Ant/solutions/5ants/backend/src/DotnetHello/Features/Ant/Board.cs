namespace DotnetHello.Features.Ant
{
    using System;
    using System.Collections.Generic;

    public class Board
    {
        public Board(int length, int posX, int posY, string direction)
        {
            initBoard(length, posX, posY, direction);
        }
        public string[,] board { get; private set; }

        public int PosX {get; set;}
        public int PosY {get; set;}

        public string Direction {get; set;}

        public Guid Id { get; } = Guid.NewGuid();

        public void Next() {
            this.board[this.PosX, this.PosY] = this.board[this.PosX, this.PosY][1].ToString();
            
            var newDirection = this.NewDirection(this.Direction, this.board[this.PosX, this.PosY]);

            switch (newDirection) {
                case "n":
                    PosY--;    
                break;
                case "o":
                    PosX++;
                break;
                case "s":
                    PosY++;
                break;
                case "w":
                    PosX--;
                break;
            }

            this.board[this.PosX, this.PosY] = this.board[this.PosX, this.PosY]=="s"?$"{newDirection}w":$"{newDirection}s";
            this.Direction = newDirection;
        }

    private readonly Dictionary<string, string> whiteDictionary = new Dictionary<string, string> {
        { "n", "o" },
        { "o", "s"},
        {"s", "w"},
        {"w", "n"}
    };

        private readonly Dictionary<string, string> blackDictionary = new Dictionary<string, string> {
            { "n", "w" },
            { "w", "s"},
            {"s", "o"},
            {"o", "n"}
        };

        private string NewDirection(string oldDirection, string color) {
            if (color == "s") {
                return blackDictionary[oldDirection];
            } 

            return whiteDictionary[oldDirection];
        }

        private void initBoard(int length, int posX, int posY, string direction)
        {
            PosX = posX;
            PosY = posY;
            Direction = direction;
            board = new string[length, length];

            for (var x = 0; x < length; x++) {
                for (var y = 0; y < length; y++) {
                    if (x == posX && y == posY) {
                        board[x,y] = $"{direction}s";
                    } else {
                        board[x,y] = "w";
                    }
                }
            }
        }
    }
}