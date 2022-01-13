using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AntConsole
{
    public class AntSimulator
    {
        private const string FIELD_BLACK = "s";
        private const string FIELD_WHITE = "w";

        private Dictionary<Direction, string> directionStrings = new Dictionary<Direction, string>
        { { Direction.North, "n"},
          { Direction.East, "o" },
          { Direction.South, "s" },
          { Direction.West, "w" } };

        public enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        };

        private bool[,] board;

        /// <summary>
        /// Simulates an ant traversing a board of invidivual fields according the rules of Langton's Ant
        /// The simulation keeps running until the provided number of steps is reached or the ant moves out of bounds
        /// of the board. The result of the simulation is written to a text file with one row per step
        /// Each row contains the complete state of the board at the time of the current step
        /// </summary>
        /// <param name="width">Both width and height of the board</param>
        /// <param name="startX">Horizontal starting position of the ant</param>
        /// <param name="startY">Vertical starting position of the ant</param>
        /// <param name="startDir">Starting direction for the ant</param>
        /// <param name="steps">Number of the steps the simualtion performs</param>
        /// <returns>Filename for the text file with the simulation's contents</returns>
        public string Simulate(int width, int startX, int startY, int startDir, int steps)
        {
            int curX = startX;
            int curY = startY;

            int height = width;

            Direction newDir = (Direction)startDir;

            board = new bool[width, height];

            var output = new StringBuilder();

            for (int i = 0; i < steps; i++)
            {
                output.AppendLine(PrintBoard(width, curX, curY, newDir));

                // Calculate new facing (turn clockwise on white/false fields, turn counterclockwise on black/true fields)
                newDir = (board[curX, curY] ? newDir + 3 : newDir + 1);

                // Clamp direction value
                newDir = (Direction)((int)newDir % 4);

                // Flip the color of the current space
                board[curX, curY] ^= true;

                // Move to new space depending on direction
                switch (newDir)
                {
                    case Direction.North:
                        curY--;
                        break;
                    case Direction.East:
                        curX++;
                        break;
                    case Direction.South:
                        curY++;
                        break;
                    case Direction.West:
                        curX--;
                        break;
                    default:
                        break;
                }

                // Check if we moved out of bounds and stop if we did
                if (curX < 0 || curY < 0 || curX > width - 1 || curY > height - 1)
                {
                    break;
                }
            }

            string filename = "ant" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".txt";
            File.WriteAllText(filename, output.ToString());

            return filename;
        }

        /// <summary>
        /// Converts the current board state to the format required by the kata
        /// The entire board is converted to a single row with each field comma-separated
        /// Empty fields are labeled either "s" (schwarz/black) or "w" (weiß/white) depending on their current state
        /// The field with the ant has the ant's current direction prefixed to the field state 
        /// (for example "ns" if the ant is facing north while on a black field)
        /// </summary>
        /// <param name="width">Both width and height of the board</param>
        /// <param name="antX">Current horizontal position of the ant on the board</param>
        /// <param name="antY">Current vertical position of the ant on the board</param>
        /// <param name="antDir">Direction the ant is currently facing</param>
        private string PrintBoard(int width, int antX, int antY, Direction antDir)
        {
            int height = width;
            var sbRow = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string field = board[x, y] ? FIELD_BLACK : FIELD_WHITE;
                    if (x == antX && y == antY)
                    {
                        field = directionStrings[antDir] + field;
                    }

                    sbRow.Append(field);


                    if (antX != width - 1 || y != height - 1)
                    {
                        sbRow.Append(",");
                    }
                }
            }

            return sbRow.ToString();
        }
    }
}
