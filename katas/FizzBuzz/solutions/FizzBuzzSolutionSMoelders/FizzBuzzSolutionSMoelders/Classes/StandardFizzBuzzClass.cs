using System;

namespace FizzBuzzSolutionSMoelders
{
    public class StandardFizzBuzzClass
    {
        private static readonly object[] Answer = { 0, "Fizz", "Buzz", "FizzBuzz" };

        public void ShorthandFizzBuzzSolver(int startNumber, int endNumber)
        {
            Console.WriteLine($"This is the FizzBuzz Solution starting from {startNumber} up to {endNumber}.\n");
            for (int i = startNumber; i <= endNumber; i++)
            {
                // Setting 'Index 0' to the number that is currently getting solved.
                Answer[0] = i;

                // Initializing 'result' inside loop - to ensure it's initialized and also to reset the value to 0 on every loop.
                int result = 0;

                // Adding the value of '1' to 'result' should 'i % 3 == 0' return true, else add the value of '0'. 
                result += i % 3 == 0 ? 1 : 0;

                // Adding the value of '2' to 'result' should 'i % 5 == 0' return true, else add the value of '0'. 
                result += i % 5 == 0 ? 2 : 0;

                // Printing the result to the console. Based on our Object Array we can expect the results to print:
                // When result equals 0: current number that is getting solved
                // When result equals 1: Fizz
                // When result equals 2: Buzz
                // When result equals 3: FizzBuzz
                Console.WriteLine($"{i}\t equals \t {Answer[result]}");
            }
        }

        public void StandardFizzBuzzSolver(int startNumber, int endNumber)
        {
            Console.WriteLine($"This is the FizzBuzz Solution starting from {startNumber} up to {endNumber}.\n");
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine($"{i}\t equals \t FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine($"{i}\t equals \t Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine($"{i}\t equals \t Buzz");
                }
                else
                {
                    Console.WriteLine($"{i}\t equals \t {i}");
                }
            }
        }

        public bool FizzCheck(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 3 == 0;
        }

        public bool BuzzCheck(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 5 == 0;
        }

        public bool FizzBuzzCheck(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 15 == 0;
        }
    }
}
