namespace PangramChecker.StringFunctions.Extensions
{
    /// <summary>
    /// Definitons.
    /// </summary>
    public class Constants
    {
        /// <summary>
        ///  Gets the alpha letters for check.
        /// </summary>
        public static string AlphaLettersForCheck
        { get => "abcdefghijklmnopqrstuvwxyz"; }

        /// <summary>
        ///  Gets the message for this case, when its true pangram.
        /// </summary>
        public static string IsExactlyPangramMessage
        { get => "contains all alphabet letters exactly once"; }

        /// <summary>
        ///  Gets the message for this case, when its not a pangram. But is more than one letter inside.
        /// </summary>
        public static string IsPangramWithMorelettersMessage
        { get => "contains all alphabet letters more than once"; }

        /// <summary>
        ///  Gets the message for this case, when its not a pangram.
        /// </summary>
        public static string IsNoPangramMessage
        { get => "does not contain all alphabet letters at least once"; }
    }
}