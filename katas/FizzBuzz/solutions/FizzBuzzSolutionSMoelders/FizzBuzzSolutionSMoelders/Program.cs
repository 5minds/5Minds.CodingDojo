using FizzBuzzSolutionSMoelders.Classes;
using System;

namespace FizzBuzzSolutionSMoelders
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardFizzBuzzClass solveThisFizzBuzz = new StandardFizzBuzzClass();
            MaintainableFizzBuzzClass solveThisMaintainableFizzBuzzClass = new MaintainableFizzBuzzClass();
            //solveThisFizzBuzz.ShorthandFizzBuzzSolver(1, 101);
            //solveThisFizzBuzz.StandardFizzBuzzSolver(1, 101);
            solveThisMaintainableFizzBuzzClass.MaintainableSolver(1, 101);

            Console.ReadLine();
        }
    }
}
