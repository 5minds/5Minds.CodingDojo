using Infrastructure;

namespace Binärsuche
{
    public class DivideAndConquerHelper
    {
        public static string Alphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static char[] GetSearchAreaAlphabet()
        {
            var searchArea = Alphabet.ToCharArray();
            searchArea.Shuffle();
            return searchArea;
        }
    }
}
