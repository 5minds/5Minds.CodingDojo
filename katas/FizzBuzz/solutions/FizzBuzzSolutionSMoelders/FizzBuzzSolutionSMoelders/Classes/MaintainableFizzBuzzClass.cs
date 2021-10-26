using System;

namespace FizzBuzzSolutionSMoelders.Classes
{
    public class MaintainableFizzBuzzClass
    {
        // Change array to rename answer
        public object[] MaintainableAnswer = { "Five", "Minds", "FiveMinds" };
        // Change first number of the solver
        public int PartOneSolution = 3;
        // Change second number of the solver
        public int PartTwoSolution = 5;

        public void MaintainableSolver(int startNumber, int endNumber)
        {

            Console.WriteLine($"This is the {MaintainableAnswer[2]} Solution starting from {startNumber} up to {endNumber}.\n");
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % PartOneSolution == 0 && i % PartTwoSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[2]}");
                }
                else if (i % PartOneSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[0]}");
                }
                else if (i % PartTwoSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[1]}");
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

            return number % PartOneSolution == 0;
        }

        public bool BuzzCheck(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % PartTwoSolution == 0;
        }

        public bool FizzBuzzCheck(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % PartOneSolution * PartTwoSolution == 0;
        }
    }
}
