using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean IsPalindrom(String Source)
            {
                var i = 0;
                var j = Source.Length - 1;
                var threshold = System.Math.Ceiling((decimal)j / 2);

                while (i < threshold && Source[i].Equals(Source[j - i])) i++;

                return i == threshold;
            }

            String ApplySpecialRules(String Source)
            {
                return Regex.Replace(Source?.ToUpper() ?? String.Empty, "[^A-Z]", String.Empty);
            }

            var tests = new List<String> {
                "Abba", --- ignore case
                "Lagerregal",
                "Reliefpfeiler",
                "Rentner",
                "Dienstmannamtsneid",
                "Tarne nie deinen Rat!",
                "Eine güldne, gute Tugend: Lüge nie!",
                "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!",
                "a",
                "",
                null,
                "abca"};

            tests.ForEach(item => Console.WriteLine($"Is '{item ?? "null value"}' an palindrom? {IsPalindrom(ApplySpecialRules(item))}"));
            
            Console.ReadLine();
        
        }
    }
}
