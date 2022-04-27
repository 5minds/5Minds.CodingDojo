using System;

namespace ChangeReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cost;
            decimal paid;

            if(args.Length > 1)
            {
                cost = Convert.ToDecimal(args[0]);
                paid = Convert.ToDecimal(args[1]);

            }
            else 
            {
                Console.WriteLine("What is the total cost?");
                cost = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("What was paid?");
                paid = Convert.ToDecimal(Console.ReadLine());
            }
            
            Console.WriteLine($"The total cost amount is: {cost}");
            Console.WriteLine($"The paid amount is: {paid}");
            Console.Write("The paid amount is: ");
            foreach (decimal change in ChangeReturn.CalculateChange(cost, paid))
            {   
                Console.Write($"{change} ");
            }
            Console.WriteLine("");
        }
    }
}
