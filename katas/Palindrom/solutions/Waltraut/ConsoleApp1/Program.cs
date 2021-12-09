using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // this function is free of special rules, it just does its job
            Boolean IsPalindrom(String Source)
            {
                if (String.IsNullOrEmpty(Source)) return true;

                // initialization
                var i = 0;
                var j = Source.Length - 1;
                // be aware that there might be an even number of characters
                // it is obvious that we only need to check up to the middle of the string
                var threshold = System.Math.Ceiling((decimal)j / 2);

                while (i < threshold && Source[i].Equals(Source[j - i])) i++;

                return i == threshold;
            }

            // not the best solution I guess, it heavily creates new string instances (appr. n/2 times, where n is length or start string)
            Boolean IsPalindromRecursive(String Source)
            {
                if (String.IsNullOrEmpty(Source)) return true;

                // initialization
                var j = Source.Length - 1;

                if (j < 1) return true;

                return (Source[0] == Source[j]) && IsPalindromRecursive(Source[1..j]);
            }

            String ApplySpecialRules(String Source)
            {
                // assume a null string is an empty string, ignore case (just make it uppercase) and remove non alphabetical characters
                return Regex.Replace(Source?.ToUpper() ?? String.Empty, "[^A-Z]", String.Empty);
            }

            var tests = new List<String> {
                "Abba", // hint: ignore case
                "Lagerregal",  // no new hint
                "Reliefpfeiler",  // hint: for a string with odd number of characters, the character in the middle must not appear twice - how could it be :) ?
                "Rentner", // no new hint
                "Dienstmannamtsneid", // no new hint
                "Tarne nie deinen Rat!", // hint: ignore non alphabetical characters (e.g. blank, ! etc.)
                "Eine güldne, gute Tugend: Lüge nie!", // hint: assert that language/region specific characters are taken into account
                "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!", //
                "a", // one character only
                "", // empty
                null, // nothing
                "abca", // negative test
                "abcca"}; // negative test

            Console.WriteLine("procedural checks...");
            tests.ForEach(item => Console.WriteLine($"Is '{item ?? "null value"}' an palindrom? {IsPalindrom(ApplySpecialRules(item))}"));

            Console.WriteLine("recursive checks...");
            tests.ForEach(item => Console.WriteLine($"Is '{item ?? "null value"}' an palindrom? {IsPalindromRecursive(ApplySpecialRules(item))}"));

            Console.ReadLine();
        }
    }
}
