using System;
using System.Diagnostics;

namespace Palindrome
{
	class Program
	{
		static void Main(string[] args)
		{
			RunTests();
			Console.WriteLine("Tests erfolgreich durchgelaufen!");
			Console.ReadLine();
		}

		static void RunTests()
		{
			Debug.Assert(TestPalindrome("Abba"));
			Debug.Assert(TestPalindrome("Reliefpfeiler"));
			Debug.Assert(TestPalindrome("Rentner"));
			Debug.Assert(!TestPalindrome("Fumpp"));
			Debug.Assert(TestPalindrome("Dienstmannamtsneid"));
			Debug.Assert(TestPalindrome("Tarne nie deinen Rat!"));
			Debug.Assert(TestPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
			Debug.Assert(TestPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
		}

		static bool TestPalindrome(string testString)
		{
			string purgedString = PurgeString(testString);
			bool palindrome = true;

			for (int i = 0; i < (purgedString.Length / 2) + 1; i++)
			{
				char a = purgedString[i];
				char b = purgedString[purgedString.Length - i - 1];
				if (!a.Equals(b))
				{
					palindrome = false;
				}
			}
			return palindrome;
		}

		static string PurgeString(string input)
		{
			string output = input.ToLower();
			output = output.Replace(" ", "");
			output = output.Replace(":", "");
			output = output.Replace(".", "");
			output = output.Replace(",", "");
			output = output.Replace("!", "");
			output = output.Replace("?", "");
			return output;
		}
	}
}
