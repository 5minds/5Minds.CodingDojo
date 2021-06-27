using System;
using PangramChecker.StringFunctions;

namespace PangramChecker.UI
{
    /// <summary>
    /// Einstiegspunkt zur Pangram Pruefung.
    /// </summary>
    internal static class Program
    {
        private static string _stringSequence = string.Empty;

        private static void Main(string[] args)
        {
            CheckArgs(args);
            IPangram pangram = new Pangram(_stringSequence);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"input<{_stringSequence}> {pangram.Result}");
        }

        private static void CheckArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please, set a string to check: ");
                _stringSequence = Console.ReadLine();
            }
            else
            {
                ParseArgs(args);
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.Length == 1)
            {
                _stringSequence = args[0];
            }

            if (args.Length > 1)
            {
                foreach (var word in args)
                {
                    _stringSequence += word + " ";
                }
            }
        }
    }
}