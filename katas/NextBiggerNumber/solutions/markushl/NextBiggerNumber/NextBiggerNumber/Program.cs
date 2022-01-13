namespace NextBiggerNumber
{
    using System;
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments. You can pass a number as first argument.
        /// When no parameter is passed, a number will be requested via the console.
        /// </param>
        static void Main(string[] args)
        {
            Int64 nNumber = 0;
            string sNumber = string.Empty;

            if (args.Length == 0)
            {
                // here we are getting the number via console input
                Console.WriteLine("Program for determining the next largest number with the same digits.");
                Console.Write("Please enter a natural number: ");
                sNumber = Console.ReadLine();
            }
            else
            {
                // get number from command line
                sNumber = args[0];
            }

            if (!Int64.TryParse(sNumber, out nNumber))
            {
                Console.WriteLine($"Invalid number was entered!");
            }
            else
            {
                Console.WriteLine($"The next largest number of {nNumber} is {Numbers.GetNextBiggerNumber(nNumber)}.");
            }

        }
    }
}
