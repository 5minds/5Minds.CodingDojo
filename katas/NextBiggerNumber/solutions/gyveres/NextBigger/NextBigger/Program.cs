using System;

namespace NextBigger
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("==== Next bigger number with the same digits ====");
      Console.Write("Enter a number: ");
      var inputNumber = Console.ReadLine();

      if (!long.TryParse(inputNumber, out long givenNumber))
      {
        Console.WriteLine("The input was not in a correct format.");
        Console.ReadKey();
      }

      var nextBiggerNumber = new NextBiggerNumber();

      var result = nextBiggerNumber.FindNextBiggerNumber(givenNumber);

      Console.WriteLine($" nextBigger({givenNumber}) == {result}");
      Console.ReadKey();
    }
  }
}
