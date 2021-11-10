using Palindrom.FirstImplementation;
using System;

namespace Palindrom.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a string that will be checked for being a Palindrom: ");
                string input = Console.ReadLine();
                var palindrom = new PalindromFirstImplementation();
                Console.WriteLine($"Was a palindrom: {palindrom.IsPalindrom(input)}");
            }
        }
    }
}
