using System;

namespace palindrome {
    class Program {
        static string Usage() {
            return "Checks if a word or sentence is a palindrome.\n\n" + 
            "Usage: palindrome <text>";
        }

        static bool IsPalindrome(string text) {
            
            text = text.ToLower();

            // extended version
            // remove special characters to compare sentences 
            text = text.Replace(" ", "");
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace(":", "");
            text = text.Replace(";", "");
            text = text.Replace("!", "");
            text = text.Replace("?", "");
            text = text.Replace("\n", "");
            text = text.Replace("\r", "");

            int last_idx = text.Length-1;
            for (int i=0; i < text.Length; i++) {
                if (text[i] != text[last_idx-i]) {
                    // nope -> break early
                    return false;
                }
            }

            // It"s a palindrome, yay!
            return true; 
        }

        static void Main(string[] args) { 
            if (args.Length < 1) {
                Console.WriteLine(Usage());
                return;
            }

            string text = args[0];
            if (IsPalindrome(text)) {
                Console.WriteLine("\n\nYep! A palindrome!\n");
            } else {
                Console.WriteLine("\n\nNope! Try again!\n");
            }
        }
    }
}
