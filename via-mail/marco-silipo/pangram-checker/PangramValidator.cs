using System.Collections.Generic;
using System.Linq;

namespace PangramChecker
{
    public class PangramValidator
    {
        // ReSharper disable once StringLiteralTypo
        const string Alphabet = "abcdefghijklmnopqrstuvwxyz";


        private Dictionary<char, int> GetPangramCounts(string potentialPangram)
        {
            var counts = Alphabet.ToDictionary((c) => c, (_) => 0);
            foreach (var c in potentialPangram.Where(char.IsLetter).Select(char.ToLower))
            {
                counts[c]++;
            }

            return counts;
        }
        public bool IsPangram(string potentialPangram)
        {
            var counts = GetPangramCounts(potentialPangram);

            return counts.All((kvp) => kvp.Value > 0);
        }
        
        public EPangramType GetPangramType(string potentialPangram)
        {
            var counts = GetPangramCounts(potentialPangram);

            return counts.Any((kvp) => kvp.Value == 0)
                ? EPangramType.Invalid
                : counts.Any((kvp) => kvp.Value > 1)
                ? EPangramType.Imperfect
                : EPangramType.Perfect;
        }
    }
}