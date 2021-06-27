using System.Linq;
using PangramChecker.StringFunctions.Extensions;

namespace PangramChecker.StringFunctions
{
    /// <summary>
    /// This class checks strings about pangrams.
    /// </summary>
    public class Pangram : IPangram
    {
        private string _stringSequence = string.Empty;
        private int[] _resultArray = new int[Constants.AlphaLettersForCheck.Length];

        /// <summary>
        /// Initializes a new instance of the <see cref="Pangram"/> class.
        /// </summary>
        /// <param name="stringSequence">String sequence to check for pangram.</param>
        public Pangram(string stringSequence)
        {
            _stringSequence = stringSequence;
            this.CheckStringSequenceForPangram();
            this.ParseResultArray();
        }

        /// <summary>
        /// Gets the check result.
        /// </summary>
        public string Result { get; private set; }

        private void CheckStringSequenceForPangram()
        {
            var lowerStringSequence = _stringSequence.ToLower();

            int counter = 0;
            foreach (var c in Constants.AlphaLettersForCheck)
            {
                _resultArray[counter] = lowerStringSequence.Count(letter => letter == c);
                counter++;
            }
        }

        private void ParseResultArray()
        {
            var lettersCount = _resultArray.Where(x => x > 0).ToList();

            if (lettersCount.Count() == 26)
            {
                var lettersMultiCount = _resultArray.Where(x => x > 1).ToList();
                if (lettersMultiCount.Count > 0)
                {
                    Result = Constants.IsPangramWithMorelettersMessage;
                }
                else
                {
                    Result = Constants.IsExactlyPangramMessage;
                }
            }

            if (lettersCount.Count() < 26)
            {
                Result = Constants.IsNoPangramMessage;
            }
        }
    }
}