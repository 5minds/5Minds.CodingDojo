using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Palindrome
{
	class Program
	{
		static void Main(string[] args)
		{
			RunTests();
			Console.WriteLine("Tests erfolgreich durchgelaufen!");
			Console.ReadKey();
		}

		static void RunTests()
		{
			Debug.Assert(isPalindrome("Abba"));
			Debug.Assert(isPalindrome("Reliefpfeiler"));
			Debug.Assert(isPalindrome("Rentner"));
			Debug.Assert(!isPalindrome("Fumpp"));
			Debug.Assert(isPalindrome("Dienstmannamtsneid"));
			Debug.Assert(isPalindrome("Tarne nie deinen Rat!"));
			Debug.Assert(isPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
			Debug.Assert(isPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
		}
		static bool isPalindrome(string str)
		{
			str = Regex.Replace(str.ToLower(), "[^a-z0-9]", "");
			char[] c = str.ToCharArray();
			Array.Reverse(c);
			return str.Equals(new string(c));
		}
	}
}
