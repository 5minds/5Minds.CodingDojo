using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {

                string numberAsString = i.ToString();

                // "FizzBuzz" soll auch zurückgegeben werden, wenn die Zahl eine 3 und eine 5 enthält, z.B. 35 oder 53.
                // Bei einem Loop von 1 - 100 gibt es nur die 35 und 53
                if (i == 53 || i == 35)
                {
                    Console.WriteLine(i + "-> FizzBuzz");
                    continue;
                }
                // Für Vielfache von 3 und 5 gib "FizzBuzz" zurück.
                else if (i % 15 == 0) 
                {
                    Console.WriteLine(i + "-> FizzBuzz");
                    continue;
                }
                // „Fizz“ soll auch zurückgegeben werden, wenn die Zahl eine 3 als Ziffer enthält, z.B. 13.
                else if (i % 3 == 0 || numberAsString.Contains("3")) 
                {
                    Console.WriteLine(i + "-> Fizz");
                    continue;
                }
                // „Buzz“ soll auch zurückgegeben werden, wenn die Zahl eine 5 als Ziffer enthält, z.B. 52.
                else if (i % 5 == 0 || numberAsString.Contains("5")) 
                {
                    Console.WriteLine(i + "-> Buzz");
                    continue;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            
        }
    }
}
