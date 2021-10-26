using System;

namespace GiggleMaps
{
    public class Visualizer
    {
        public static void OutputGrid(int[,] grid, int width, int height, int currentX, int currentY)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var previousColor = Console.ForegroundColor;

                    // Colorize bounds
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    // Colorize path
                    if (grid[x, y] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    // Colorize santa
                    if (x == currentX && y == currentY)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // Colorize start
                    if (x == width / 2 && y == height / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    // Draw grid
                    Console.Write(grid[x, y]);
                    Console.ForegroundColor = previousColor;
                }
                Console.Write("\n");
            }
        }
    }
}
