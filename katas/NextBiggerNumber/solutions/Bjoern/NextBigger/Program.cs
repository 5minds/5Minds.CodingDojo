using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBigger
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime anfang = DateTime.Now;
			Int64 number = Convert.ToInt64(args[0]);
			Console.WriteLine(nextBigger(number));


			DateTime ende = DateTime.Now;
			TimeSpan differenz = ende.Subtract(anfang);
			Console.WriteLine("Dauer: " + differenz.TotalSeconds + " Sekunden");
			Console.ReadLine();

			Console.WriteLine("Tests...");
			Debug.Assert(nextBigger(12) == 21);
			Debug.Assert(nextBigger(513) == 531);
			Debug.Assert(nextBigger(2017) == 2071);
			Debug.Assert(nextBigger(459853) == 483559);
			Console.WriteLine("Test fertig!");
			Console.ReadLine();
		}

		static Int64 nextBigger(Int64 number)
		{
			Int64 currentNumber = number;
			double digitCount = Math.Floor(Math.Log10(number) + 1);
			do
			{
				currentNumber++;
				string charRepo = Convert.ToString(number);
				string currentNumberAsString = Convert.ToString(currentNumber);
				bool match = true;
				foreach (char character in currentNumberAsString)
				{
					if (!isPartOf(character, ref charRepo))
					{
						match = false;
						break;
					}
				}
				if (match)
				{
					return currentNumber;
				}
			}
			while (Math.Floor(Math.Log10(currentNumber) + 1).Equals(digitCount)) ;
			return -1;
		}

		static bool isPartOf(char character, ref string repo)
		{
			if (repo.Contains(character))
			{
				repo = repo.Remove(repo.IndexOf(character), 1);
				return true;
			}
			return false;
		}
	}
}
