using NextBiggerNumber.FirstImplementation;
using System;

namespace NextBiggerNumber.ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a number: ");
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out int inputAsInt))
                {
                    Console.WriteLine("Error! Number could not be parsed.");
                    continue;
                }
                if(inputAsInt < 0)
                {
                    Console.WriteLine("Error! Number not a natural number.");
                    continue;
                }
                var nextBigger = new NextBiggerNumberFirstImplementation();
                Console.WriteLine($"Next bigger number is: {nextBigger.NextBigger(inputAsInt)}");
            }
        }
    }
}
