using System;
using System.IO;
using System.Linq;

namespace csharp
{
    class Program
    {
        const string defaultPalindromeSourceFile = @"Resources\Palindrome.txt";

        static void Main(string[] args)
        {
            try
            {

                string sourceFile = string.Empty;

               


                  
                    sourceFile = args.FirstOrDefault() == ":F" ? args[1] : defaultPalindromeSourceFile   ;
                

                if (File.Exists(sourceFile))
                {
                    foreach (string line in File.ReadLines(sourceFile))
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Die Datei {0} konnte nicht gefunden werden.", sourceFile));
                }

                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Bei der Ausführung ist ein Fehler aufgetreten: " + e.Message);
            }
        }
    }
}
