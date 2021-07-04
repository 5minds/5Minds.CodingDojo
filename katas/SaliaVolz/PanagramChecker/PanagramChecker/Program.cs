using System;

namespace PanagramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            if(args.Length > 0)
            {
                input = args[0];
            }
            else 
            {
                Console.WriteLine("Please enter a string!");
                input = Console.ReadLine();
            }

            bool pangram = PanagramChecker.IsPangram(input);
            bool duplicate = PanagramChecker.IsDuplicate(input);

            if(pangram && duplicate){
                Console.WriteLine($"\"{input}\" contains all alphabet letters more than once.");
            }
            else if(pangram){
                Console.WriteLine($"\"{input}\" contains all alphabet letters exactly once.");
            }
            else{
                Console.WriteLine($"\"{input}\" does not contain all alphabet letters at least once.");
            }
        }
    }
}
