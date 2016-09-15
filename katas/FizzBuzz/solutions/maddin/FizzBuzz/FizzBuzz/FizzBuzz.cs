namespace FizzBuzz
{
    using System;

    /// <summary>
    /// The FizzBuzz class.
    /// </summary>
    public class FizzBuzz
    {
        /// <summary>
        /// The data
        /// </summary>
        private static readonly object[] Data = { 0, "Fizz", "Buzz", "FizzBuzz" };

        /// <summary>
        /// Runs the extended fizz buzz.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void RunExtended(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Data[0] = i;

                int res = 0;

                res += i % 3 == 0 ? 1 : 0;
                res += i % 5 == 0 ? 2 : 0;

                Console.WriteLine($"{i}\t -> \t{Data[res]}");
            }
        }

        /// <summary>
        /// Runs the simple fizz buzzs.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void Run(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                int res = 0;
                res += this.IsFizzNum(i);

                if (res == 2)
                {
                    Console.Write("Fizz");
                }

                res += this.IsBuzzNum(i);

                if (res > 2)
                {
                    Console.Write("Buzz");
                }

                if (res == 0)
                {
                    Console.Write(i);
                }

                Console.Write(", ");
            }
        }

        /// <summary>
        /// Determines whether the specified number is fizz.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is fizz; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFizz(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 3 == 0;
        }

        /// <summary>
        /// Determines whether the specified number is fizz.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is fizz; otherwise, <c>false</c>.
        /// </returns>
        public int IsFizzNum(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            return number % 3 == 0 ? 2 : 0;
        }

        /// <summary>
        /// Determines whether the specified number is buzz.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is buzz; otherwise, <c>false</c>.
        /// </returns>
        public bool IsBuzz(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 5 == 0;
        }

        /// <summary>
        /// Determines whether the specified number is buzz.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is buzz; otherwise, <c>false</c>.
        /// </returns>
        public int IsBuzzNum(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            return number % 5 == 0 ? 4 : 0;
        }
    }
}
