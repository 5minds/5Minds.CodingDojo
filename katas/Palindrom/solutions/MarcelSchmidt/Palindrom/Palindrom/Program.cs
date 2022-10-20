using System;
using System.Linq;

namespace Palindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("'Palindrom'");
            Process();
        }

        private static void Process()
        {
            Console.WriteLine("Would you like to ignore case sensitivity for the palindrome checks? (y)es / (n)o");

            var keyPressed = Console.ReadKey();

            Console.WriteLine();

            var ignoreCaseSensitivity = false;
            if (keyPressed.Key == ConsoleKey.Y)
            {
                ignoreCaseSensitivity = true;
            }
            else if (keyPressed.Key != ConsoleKey.N)
            {
                Console.WriteLine("Error: Invalid input detected!");
                Process();
                return;
            }

            var testInput = PalindromeExamples.PalindromesCaseInsensitive
                .Concat(PalindromeExamples.PalindromesCaseSensitive)
                .Concat(PalindromeExamples.NoPalindromes)
                .Concat(PalindromeExamples.PalindromeSentencesCaseInsensitive)
                .Concat(PalindromeExamples.PalindromeSentencesCaseSensitive)
                .Concat(PalindromeExamples.NoPalindromeSentences);

            foreach (var input in testInput)
            {
                var result = Palindrome.IsPalindrome(input, ignoreCaseSensitivity) ? "IS" : "Is NOT";

                Console.WriteLine("{0} >> {1} a palindrome", input, result);
            }
        }

    }
}
