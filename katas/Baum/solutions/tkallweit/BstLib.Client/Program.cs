namespace BstLib.Client
{
    using System;
    

    class Program
    {
       static void Main(string[] args)
        {
            int[] values = new int[] { 30, 15, 60, 7, 20, 14, 79, 11, 12 };
            Tree root = new Tree(values);
            
            var result = root.Sort();
            foreach (var element in result)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine($"{root.Find(55)}");
        }
    }
}
