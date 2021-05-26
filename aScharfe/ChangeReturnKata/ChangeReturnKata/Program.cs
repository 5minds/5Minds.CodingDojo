using System;
using System.Collections.Generic;
using ChangeReturnKata.Calculator;

namespace ChangeReturnKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 2 && ValidateParameter(args))
            {
                decimal.TryParse(args[0], out var cost);
                decimal.TryParse(args[1], out var paid);
                if (paid > cost)
                {
                    var calculator = new ChangeReturnCalculator(cost, paid);
                    var changeResult = calculator.GetChangeReturn();

                    Console.WriteLine($"Total cost:\t {calculator.Costs}");
                    Console.WriteLine($"Total paid:\t {calculator.Paid}");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine($"Total Change: \t {calculator.ChangeReturn} ");
                    Console.WriteLine(Environment.NewLine);

                    if (changeResult.HundredEuro > 0) Console.WriteLine($"Hundred Euro: \t {changeResult.HundredEuro}");
                    if (changeResult.FiftyEuro > 0) Console.WriteLine($"Fifty Euro: \t {changeResult.FiftyEuro}");
                    if (changeResult.TwentyEuro > 0) Console.WriteLine($"Twenty Euro: \t {changeResult.TwentyEuro}");
                    if (changeResult.TenEuro > 0) Console.WriteLine($"Ten Euro: \t {changeResult.TenEuro}");
                    if (changeResult.FiveEuro > 0) Console.WriteLine($"Five Euro: \t {changeResult.FiveEuro}");
                    if (changeResult.FiftyCent > 0) Console.WriteLine($"Fifty Cent: \t {changeResult.FiftyCent}");
                    if (changeResult.TwentyCent > 0) Console.WriteLine($"Twenty Cent: \t {changeResult.TwentyCent}");
                    if (changeResult.TenCent > 0) Console.WriteLine($"Ten Cent: \t {changeResult.TenCent}");
                    if (changeResult.FiveCent > 0) Console.WriteLine($"Five Cent: \t {changeResult.FiveCent}");
                    if (changeResult.TwoCent > 0) Console.WriteLine($"Two Cent: \t {changeResult.TwoCent}");
                    if (changeResult.OneCent > 0) Console.WriteLine($"One Cent: \t {changeResult.OneCent}");
                }
                else
                {
                    Console.WriteLine($"The purchase amount must not be greater than the given amount.\n{cost} > {paid}!");
                }
            }
            else
            {
                Console.WriteLine("At least two parameters must be specified. Parameter one contains the purchase amount and parameter two contains the given money in decimal format.");
            }
        }

        private static bool ValidateParameter(IReadOnlyList<string> args)
        {
            if (args.Count != 2)
                return false;
            return decimal.TryParse(args[0], out _) && decimal.TryParse(args[1], out _);
        }
    }
}
