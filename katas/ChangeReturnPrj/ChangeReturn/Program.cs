using System;

namespace ChangeReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            CChangeReturn oChangeReturn = new CChangeReturn();


            while (true)
            {
                Console.WriteLine("---------");
                decimal nTotalCost;
                decimal nTotalPaid;
                Console.WriteLine("Total Cost");
                while (!decimal.TryParse(Console.ReadLine(), out nTotalCost))
                {
                    Console.WriteLine("Please enter a number");
                }
                Console.WriteLine("Total Paid");
                while (!decimal.TryParse(Console.ReadLine(), out nTotalPaid))
                {
                    Console.WriteLine("Please enter a number");
                }

                //Process input
                Console.WriteLine("Total Cost " + nTotalCost.ToString());
                Console.WriteLine("Total Paid " + nTotalPaid.ToString());
                Console.WriteLine(String.Join(" ", oChangeReturn.fCalcChangeReturn(nTotalCost, nTotalPaid).ToArray()));
            }
        }
    }
}
