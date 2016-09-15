using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            fizzBuzz.RunExtended(1, 15);
            Console.ReadLine();
        }
    }
}
