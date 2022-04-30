using System;

namespace AntConsole
{
    class Program
    {
        private const int DEFAULT_BOARD_SIZE = 11;
        private const int DEFAULT_START_X = 5;
        private const int DEFAULT_START_Y = 5;
        private const int DEFAULT_START_DIR = 0;
        private const int DEFAULT_STEPS = 50;

        static void Main(string[] args)
        {
            int boardSize = DEFAULT_BOARD_SIZE;
            int startX = DEFAULT_START_X;
            int startY = DEFAULT_START_Y;
            int startDir = DEFAULT_START_DIR;
            int steps = DEFAULT_STEPS;

            if (args.Length == 5)
            {
                try
                {
                    boardSize = int.Parse(args[0]);
                    startX = int.Parse(args[1]);
                    startY = int.Parse(args[2]);
                    startDir = int.Parse(args[3]);
                    steps = int.Parse(args[4]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input data, program expects the following arguments:");
                    Console.WriteLine("AntConsole.exe boardSize startX startY startDir steps");
                    Console.WriteLine("boardSize (int): Size of board width/height");
                    Console.WriteLine("startX (int): Horizontal starting position of ant (zero-based)");
                    Console.WriteLine("startY (int): Vertical starting position of ant (zero-based)");
                    Console.WriteLine("startDir (int): Starting direction of ant (0, 1, 2 or 3 for north, east, south or west)");
                    Console.WriteLine("steps (int): Number of steps the simulation should peform");
                    Console.WriteLine("Example:");
                    Console.WriteLine("AntConsole.exe 11 5 5 0 50");
                    Environment.Exit(-1);
                }

                if (startX < 0 || startX > boardSize || startY < 0 || startY > boardSize)
                {
                    Console.WriteLine(string.Format("Start position '{0},{1}' can't be smaller than 0 or larger than board size '{3}'", startX, startY, boardSize));
                }
            }

            var sim = new AntSimulator();
            var filename = sim.Simulate(boardSize, startX, startY, startDir, steps);

            Console.WriteLine(string.Format("Result of simulation saved in file '{0}'", filename));
        }
    }
}
