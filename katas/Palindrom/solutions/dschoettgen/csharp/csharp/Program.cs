using csharp.Classes;
using System;
using System.IO;
using System.Linq;

namespace csharp
{
    class Program
    {
        const string defaultPalindromeSourceFile = @"Resources\Palindrome.txt";

        /// <summary>
        /// This little programm reads strings line by line from a given file and check if the line a palindrome and show the result as console output
        /// </summary>
        /// <param name="args">string ':F path/to/file'</param>
        static void Main(string[] args)
        {
            try
            {
                string sourceFile = sourceFile = args.FirstOrDefault() == ":F" ? args[1] : defaultPalindromeSourceFile;

                if (File.Exists(sourceFile))
                {
                    Palindrome palindrome = new Palindrome();

                    foreach (string line in File.ReadLines(sourceFile))
                    {
                        Console.WriteLine(string.Format("{0} : {1}",line, palindrome.IsPalindrome(line)));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("The file {0} could not be found.", sourceFile));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred during execution: " + e.Message);
            }
        }
    }
}
