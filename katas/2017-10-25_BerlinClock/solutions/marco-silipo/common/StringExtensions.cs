using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class StringExtensions
    {
        public static string RandomizeCasing(this string str)
        {
            var random = new Random();
            var chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = random.Next() % 2 == 0
                    ? char.ToUpper(chars[i])
                    : char.ToLower(chars[i]);
            }

            return new string(chars);
        }
        public static string ShuffleChars(this string str)
        {
            var random = new Random();
            var listIn = str.ToList();
            var stackOut = new Stack<char>(str.Length);
            while (listIn.Any())
            {
                var c = listIn[random.Next(0, listIn.Count)];
                listIn.Remove(c);
                stackOut.Push(c);
            }
            return new string(stackOut.ToArray());
        }
    }
}
