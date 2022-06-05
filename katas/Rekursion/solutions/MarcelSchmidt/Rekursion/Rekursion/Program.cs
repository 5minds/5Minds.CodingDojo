using Binärsuche;
using Fakultät;
using System;
using TürmeVonHanoi;

namespace Rekursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var moduleFactorial = new Factorial("1 - Fakultät");
            var moduleDivideAndConquer = new DivideAndConquer("2 - Binärsuche");
            var moduleTowerOfHanoi = new TowerOfHanoi("3 - Türme von Hanoi");

            var run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Welcome to 'Rekursion'. Please select a module:");
                Console.WriteLine("F: '{0}'", moduleFactorial.ModuleName);
                Console.WriteLine("B: '{0}'", moduleDivideAndConquer.ModuleName);
                Console.WriteLine("T: '{0}'", moduleTowerOfHanoi.ModuleName);
                Console.WriteLine("Q: Quit program");

                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                    case ConsoleKey.F:
                        {
                            moduleFactorial.Run();
                            break;
                        }
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                    case ConsoleKey.B:
                        {
                            moduleDivideAndConquer.Run();
                            break;
                        }
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                    case ConsoleKey.T:
                        {
                            moduleTowerOfHanoi.Run();
                            break;
                        }
                    case ConsoleKey.Q:
                        {
                            run = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
