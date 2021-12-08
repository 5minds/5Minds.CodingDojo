using FizzBuzz;
using System;

namespace FizzBuzzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzAnalyser = new FizzBuzzAnalyser();
            Console.WriteLine(fizzBuzzAnalyser.AnalyseRangeFromToAndReturnString());
        }
    }
}
