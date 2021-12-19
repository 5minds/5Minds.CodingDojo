using System.Linq;

namespace Palindrome
{
    public class Palindrome
    {
        public bool IsStringPalindrome(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return false;
            if (inputString.Length <= 1)
                return false;

            var cleanedInputString = CleanInputString(inputString);

            if (cleanedInputString.Length <= 1)
                return false;

            return Enumerable.Range(0, cleanedInputString.Length / 2)
                .Select(index => {
                    var charA = cleanedInputString[index];
                    var charB = cleanedInputString[cleanedInputString.Length - index - 1];

                    return charA.Equals(charB);
                }).All(result => result);
        }

        private string CleanInputString(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return null;

            var allCharacters = inputString.ToLower().ToCharArray();

            var validCharacters = allCharacters.Where(char.IsLetterOrDigit).ToArray();

            return new string(validCharacters);
        }

    }
}
