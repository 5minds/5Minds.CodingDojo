namespace FizzBuzz;
static class Program
{
    static void Main()
    {
        Console.WriteLine("FizzBuzz!!!!\n");
        FizzBuzz fizzBuzz = new FizzBuzz();
        
        for (int i = 1; i <= 100; i++)
        {
            if (i == 100) Console.WriteLine(fizzBuzz.IsFizzBuzz(i));
            else
            {
                Console.Write(fizzBuzz.IsFizzBuzz(i) + ", ");
                if (i % 5 == 0) Console.WriteLine();
            }
        }

        Console.ReadLine();
    }
}
