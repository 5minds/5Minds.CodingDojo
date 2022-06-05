using System.Collections.Generic;

namespace Palindrom
{
    public static class PalindromeExamples
    {
        public static List<string> PalindromesCaseInsensitive { get; } = new List<string>
        {
            "Abba",
            "Lagerregal",
            "Reliefpfeiler",
            "Rentner",
            "Dienstmannamtsneid",
        };

        public static List<string> PalindromesCaseSensitive { get; } = new List<string>
        {
            "abba",
            "lagerregal",
            "reliefpfeiler",
            "rentner",
            "dienstmannamtsneid",
        };

        public static List<string> NoPalindromes { get; } = new List<string>
        {
            "Aufgabe",
            "Palindromsätze",
            "Satzzeichen",
            "vernachlässigen",
            "Zeichenkette",
        };

        public static List<string> PalindromeSentencesCaseInsensitive { get; } = new List<string>
        {
            "Tarne nie deinen Rat!",
            "Eine güldne, gute Tugend: Lüge nie!",
            "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"
        };

        public static List<string> PalindromeSentencesCaseSensitive { get; } = new List<string>
        {
            "tarne nie deinen rat!",
            "eine güldne, gute tugend: lüge nie!",
            "ein agiler hit reizt sie. geist?! biertrunk nur treibt sie. geist ziert ihre liga nie!"
        };

        public static List<string> NoPalindromeSentences { get; } = new List<string>
        {
            "lorem ipsum dolor sit amet consectetur adipisicing elit.",
            "Künstliche neuronale Netze haben, ebenso wie künstliche Neuronen, ein biologisches Vorbild.",
            "An engine or motor is a machine designed to convert one or more forms of energy into mechanical energy."
        };
    }
}
