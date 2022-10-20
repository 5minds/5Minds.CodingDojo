using System;

namespace Infrastructure
{
    public static class Helper
    {
        public static Random Rng { get; } = new Random((int)(DateTime.Now - new DateTime(1994, 7, 8)).TotalMilliseconds);
    }
}
