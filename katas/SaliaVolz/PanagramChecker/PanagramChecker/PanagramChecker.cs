using System;

namespace PanagramChecker
{
    public class PanagramChecker
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static bool IsPangram(string input){
            foreach (char letter in alphabet.ToCharArray())
            {
                if(!input.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDuplicate(string input){
            char lastLetter = ' ';
            foreach(char letter in StringToSortedArray(input)){
                if(lastLetter.Equals(letter)){
                    return true;
                }
                lastLetter = letter;
            }
            return false;
        }
        
        private static char[] StringToSortedArray(string input){
            input.ToLower();
            input.Replace(" ", "");
            char[] inoutArray = input.ToLower().ToCharArray();
            Array.Sort(inoutArray);
            return inoutArray;
        }

    }
}
