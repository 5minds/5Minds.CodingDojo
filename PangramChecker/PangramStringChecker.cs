using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PangramChecker
{
    public static class PangramStringChecker
    {
        public static string CheckPangram(string input)
        {
            var result = string.Empty;
            var letterCounts = new Dictionary<char, int>();
            Regex rgx = new Regex("[^a-zA-Z]");
           
            foreach (var letter in rgx.Replace(input.ToLower(), ""))
            {
         
                if (letterCounts.ContainsKey(letter))
                {
                    letterCounts[letter]++;
                }
                else
                {
                    letterCounts.Add(letter, 1);
                }
       
            }

            if (letterCounts.Where(x => x.Value == 1).Count() == 26 )
            {
                result = input + " contains all alphabet letters exactly once.";
            }
            else if (letterCounts.Count() < 26)
            {
                result = input + " does not contains all alphabet letters at least once.";
            }
            else
            {
                result = input + " contains all alphabet letters more than once.";
            }

            return result;
        }
    }
}
