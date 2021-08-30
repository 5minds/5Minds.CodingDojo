using System;

namespace PangramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PangramStringChecker.CheckPangram(args[0]));
        }
       
    }
}
