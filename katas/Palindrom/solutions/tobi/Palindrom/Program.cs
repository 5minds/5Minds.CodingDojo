namespace Palindrom
{
    public class Program
    {
        static void Main(string[] args)
        {
            var checker = new PalindromChecker();
            checker.IsPalindrom("Abba");
            checker.IsPalindromeRecursive("Abba");
        }
    }
}