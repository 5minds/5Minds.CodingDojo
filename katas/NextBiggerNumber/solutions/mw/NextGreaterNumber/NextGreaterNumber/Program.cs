using System;

namespace NextGreaterNumber
{
    class Program
    {
        public static void Main()
        {
            var nextGreater = new NextGreaterNumber();
            Console.WriteLine(nextGreater.FindNextGreaterNumber(513));
        }
    }
}