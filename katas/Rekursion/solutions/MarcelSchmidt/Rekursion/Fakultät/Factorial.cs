using Infrastructure.Module;
using System;

namespace Fakultät
{
    public class Factorial : BaseModule
    {
        public Factorial(string moduleName) : base(moduleName)
        {
        }

        protected override void Process()
        {
            Console.WriteLine("Enter your number to calculate the factorial");
            var numberInput = Console.ReadLine();

            var isValidNumber = int.TryParse(numberInput, out int number);
            if (!isValidNumber || number < 0)
            {
                Console.WriteLine("Error: Invalid input detected! Enter a single non-negative integer number.");
                Process();
                return;
            }

            var result = CalculateFactorial(number);
            Console.WriteLine("The factorial of {0} is {1}", number, result);
        }

        public static int CalculateFactorial(int number)
        {
            if (number <= 1)
                return 1;

            return number * CalculateFactorial(number - 1);
        }
    }
}

