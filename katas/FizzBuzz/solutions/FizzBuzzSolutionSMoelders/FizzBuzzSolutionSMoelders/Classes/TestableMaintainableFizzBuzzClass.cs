using System;

namespace FizzBuzzSolutionSMoelders.Classes
{
    public class TestableMaintainableFizzBuzzClass
    {

        // Change array to rename answer
        public object[] MaintainableAnswer = { "Five", "Minds", "FiveMinds" };
        // Change first number of the solver !!Warning!! Changing these values requires an update to Unit Test: TestMethod1(), TestMethod2(), TestMethod3().
        public int PartOneSolution = 3;
        // Change second number of the solver !!Warning!! Changing these values requires an update to Unit Test: TestMethod1(), TestMethod2(), TestMethod3().
        public int PartTwoSolution = 5;
        // Needed for Tests
        public int[] TestCase = { 0, 0, 0 };

        public int[] TestableMaintainableSolver(int startNumber, int endNumber)
        {
            Console.WriteLine($"This is the {MaintainableAnswer[2]} Solution starting from {startNumber} up to {endNumber}.\n");
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (i % PartOneSolution == 0 && i % PartTwoSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[2]}");
                    TestCase[0] += 1;
                }
                else if (i % PartOneSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[0]}");
                    TestCase[1] += 1;
                }
                else if (i % PartTwoSolution == 0)
                {
                    Console.WriteLine($"{i}\t equals \t {MaintainableAnswer[1]}");
                    TestCase[2] += 1;
                }
                else
                {
                    Console.WriteLine($"{i}\t equals \t {i}");
                }
            }

            return TestCase;
        }
    }
}
