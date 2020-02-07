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
                boardSize = int.Parse(args[0]);
                startX = int.Parse(args[1]);
                startY = int.Parse(args[2]);
                startDir = int.Parse(args[3]);
                steps = int.Parse(args[4]);
            }

            var sim = new AntSimulator();
            var filename = sim.Simulate(boardSize, startX, startY, startDir, steps);

            Console.WriteLine(string.Format("Result of simulation saved in file '{0}'", filename));
        }
    }
}
