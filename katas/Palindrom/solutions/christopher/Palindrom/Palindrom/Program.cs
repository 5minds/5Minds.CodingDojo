using System;

namespace PalindromNamespace {
    public class Palindrom {
        static void Main(string[] args) {
            Palindrom p = new Palindrom();
            p.PerformMethods();
        }

        public Palindrom() {
        }

        public void PerformMethods() {
            String[] textToTest = new String[] { "Abba", "Lagerregal", "Reliefpfeiler", "Rentner", "Dienstmannamtsneid", "Tarne nie deinen Rat!", "Eine güldne, gute Tugend: Lüge nie!", "Ein agiler Hit reizt sie. Geist ? !Biertrunk nur treibt sie. Geist ziert ihre Liga nie!" };
            foreach (String s in textToTest) {
                Console.WriteLine(s);
                Console.WriteLine(PalindromRecursionWithSymbols(s.ToCharArray(), 0, s.Length - 1));
                String tmp = RemoveSymbols(s.ToLower());
                Console.WriteLine(PalindromNoRecursion(tmp));
                Console.WriteLine(PalindromRecursion(tmp, 0));
            }
        }

        public String RemoveSymbols(String text) {
            String tmp = "";
            foreach (char c in text) {
                if (Char.IsLetter(c)) {
                    tmp += c;
                }
            }
            return tmp;
        }
        public bool PalindromRecursionWithSymbols(char[] text, int p, int q) {
            if (p < q) {
                if (char.IsLetter(text[p]) && char.IsLetter(text[q])) {
                    return char.ToLower(text[p]) == char.ToLower(text[q]) && PalindromRecursionWithSymbols(text, p + 1, q - 1);
                } else {
                    if (char.IsLetter(text[p])) {
                        return PalindromRecursionWithSymbols(text, p, q - 1);
                    } else {
                        return PalindromRecursionWithSymbols(text, p + 1, q);
                    }
                }
            }
            return true;
        }

        public bool PalindromRecursion(String text, int p) {
            if (p < text.Length - p) {
                return text.Substring(p, 1) == text.Substring(text.Length - p - 1, 1) && PalindromRecursion(text, p + 1);
            }
            return true;
        }

        public bool PalindromNoRecursion(String text) {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            if (text == new String(array)) {
                return true;
            }
            return false;
        }
    }
}
