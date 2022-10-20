using System.Collections.Generic;

namespace Infrastructure
{
    public static class StackExtensions
    {
        public static void AddRange<T>(this Stack<T> stack, IEnumerable<T> range)
        {
            if (range is null)
                return;

            foreach (var item in range)
            {
                stack.Push(item);
            }
        }
    }

    public static class ArrayExtensions
    {
        public static void Shuffle<T>(this T[] array)
        {
            var n = array.Length;
            while (n > 1)
            {
                var k = Helper.Rng.Next(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
