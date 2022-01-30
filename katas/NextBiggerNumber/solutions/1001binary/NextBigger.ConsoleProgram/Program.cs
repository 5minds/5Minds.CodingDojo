using _5Minds.Services;
using System;

namespace NextBigger.ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl+C to exit the program.");
            Console.WriteLine();
            Console.WriteLine("=== Find the next bigger number ===");

            while (true)
            {
                Console.Write("Please enter a number: ");
                string input = Console.ReadLine();

                long num;

                if (!long.TryParse(input, out num))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number format is required");
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }

                Console.WriteLine("The next bigger number of {0} is {1}", num, DigitService.GetNextBigger(num));
                Console.WriteLine();
            }
        }
    }
}
