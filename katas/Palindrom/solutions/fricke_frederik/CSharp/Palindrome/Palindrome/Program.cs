// See https://aka.ms/new-console-template for more information
namespace Palindrome;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Type in a Word to check for palindrome:");
        string checkPalindrome = Console.ReadLine() ?? throw new InvalidOperationException();
        Palindrome palindrome = new Palindrome();
        if (palindrome.IsPalindrome(checkPalindrome)) Console.WriteLine("This is a palindrome!");
        else Console.WriteLine("This is not a palindrome");

        Console.ReadLine();
    }
}