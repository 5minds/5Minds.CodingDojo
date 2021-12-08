using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Fakultät(0) = {Fakultät(0)}");
            Console.WriteLine($"Fakultät(1) = {Fakultät(1)}");
            Console.WriteLine($"Fakultät(4) = {Fakultät(4)}");
            Console.WriteLine($"Fakultät(14) = {Fakultät(14)}");
            Console.WriteLine($"Fakultät(-4) = {Fakultät(-4)}");

            Console.ReadLine();

            return;

            Int32 Fakultät(Int32 n)
            {
                if (n < 0) return 0;

                if (n == 0) return 1;
                return n * Fakultät(n - 1);
            }
        }
    }
}
