using Infrastructure.Module;
using System;
using System.Linq;

namespace Binärsuche
{
    public class DivideAndConquer : BaseModule
    {
        public DivideAndConquer(string moduleName) : base(moduleName)
        {
        }

        protected override void Process()
        {
            var searchArea = DivideAndConquerHelper.GetSearchAreaAlphabet();
            DisplaySearchArea(searchArea);

            var selectedChar = ' ';
            while (selectedChar == ' ')
            {
                Console.WriteLine("Enter the alphabetical letter you want to search for");

                var input = Console.ReadKey();
                if (searchArea.Contains(char.ToUpper(input.KeyChar)))
                {
                    selectedChar = char.ToUpper(input.KeyChar);
                    continue;
                }

                Console.WriteLine("Error: Invalid input detected! Choose and press a character from >> {0}", DivideAndConquerHelper.Alphabet);
            }

            if (Search(searchArea, selectedChar, false))
            {
                DisplaySearchFound(selectedChar);
            }
            else
            {
                DisplaySearchNotFound(selectedChar);
            }
        }

        public static bool Search(char[] searchArea, char searchChar, bool ordered = true)
        {
            if (!ordered)
            {
                searchArea = searchArea.OrderBy(x => x).ToArray();
            }

            DisplaySearchArea(searchArea);

            if (searchArea.Length == 1)
            {
                return searchArea[0] == searchChar;
            }

            var found = false;
            var middle = (int)Math.Floor(searchArea.Length / 2d);
            if (searchArea[middle] == searchChar)
            {
                return true;
            }
            else
            {
                if (searchChar > searchArea[middle])
                {
                    if (searchArea.Length <= 2)
                        return false;

                    found = Search(searchArea[(middle + 1)..], searchChar);
                }
                else
                {
                    found = Search(searchArea[0..middle], searchChar);
                }
            }

            return found;
        }

        private static void DisplaySearchArea(char[] searchArea)
        {
            Console.WriteLine("\nSearch area:");
            Console.WriteLine(string.Join(" ", searchArea));
        }

        private static void DisplaySearchFound(char searchChar)
        {
            Console.WriteLine("\nSuccess: Found character! >> {0}", searchChar);
        }

        private static void DisplaySearchNotFound(char searchChar)
        {
            Console.WriteLine("\nError: Selected character could not be found! >> {0}", searchChar);
        }
    }
}
