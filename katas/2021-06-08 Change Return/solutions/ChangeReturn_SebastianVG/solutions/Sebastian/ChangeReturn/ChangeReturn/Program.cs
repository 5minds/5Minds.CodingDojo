using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ChangeReturn
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "This application calculates the change money for a given cost when a customer gives a certain amount of money." + Environment.NewLine +
                "Inputs must be decimal numbers with no more than 2 decimal places." + Environment.NewLine +
                "Do not use thousands separators." + Environment.NewLine +
                "',' and '.' are both interpreted as a decimal separator." + Environment.NewLine
                );

            var totalCost = GetValidInput("total cost");
            var totalPaid = GetValidInput("total paid");
            var changeAmount = totalPaid - totalCost;

            if (changeAmount < 0)
            {
                Console.WriteLine("Your payment is {0} Euro short. You won't get any change.", Math.Abs(changeAmount));
            }
            else
            {
                var changeMoney = ChangeCalculator.ReturnChange(changeAmount);

                Console.WriteLine("Total cost: {0}", totalCost);
                Console.WriteLine("Total paid: {0}", totalPaid);
                Console.WriteLine("Change money: {0}", changeMoney);
                //Console.WriteLine("Change total: {0}", changeMoney.Total);
            }

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }

        private static decimal GetValidInput(string inputName)
        {
            var input = string.Empty;
            var inputValid = false;

            while (!inputValid)
            {
                input = GetInput(inputName);
                inputValid = ValidateInput(input);
            }

            var result = ConvertInput(input);

            return result;
        }

        public static decimal ConvertInput(string input)
        {
            string separator = input.Contains('.') ? "." : ",";

            var cc = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            var ci = new CultureInfo(cc)
            {
                NumberFormat = { NumberDecimalSeparator = separator }
            };

            var result = Convert.ToDecimal(input, ci);

            return result;
        }

        private static string GetInput(string inputName)
        {
            Console.WriteLine("Please enter the {0}:", inputName);
            var input = Console.ReadLine();

            return input;
        }

        public static bool ValidateInput(string input)
        {
            var inputValid = Regex.IsMatch(input, "^\\d+([,.]{0,1}\\d{1,2})?$");

            if (!inputValid)
            {
                Console.WriteLine("Your input was invalid. Please enter a decimal number without thousands separators and no more than two decimal places.");
            }

            return inputValid;
        }

    }
}
