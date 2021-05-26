using System;
using ArabicRomanKata.Converter;
using ArabicRomanKata.Enum;
using ArabicRomanKata.Helper;

namespace ArabicRomanKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            if (args.Length == 1 && args[0].CheckValueIsValid())
            {
                var conversionDirection = args[0].GetConversionDirection();

                switch (conversionDirection)
                {
                    case ConversionDirection.ToArabic:
                        Console.WriteLine(args[0].ConvertRomanToArabic());
                        break;
                    case ConversionDirection.ToRoman:
                        int.TryParse(args[0], out var arabicValue);
                        Console.WriteLine(arabicValue.ConvertArabicToRoman());
                        break;
                    case ConversionDirection.Unknown:
                        Console.WriteLine("No valid conversion direction.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                Console.WriteLine("An error occurred during processing. Please specify a maximum of one parameter and valid Arabic or Roman numerals.");
            }

            Console.WriteLine("Press any Key for exit.");
            Console.ReadKey();
        }


    }
}
