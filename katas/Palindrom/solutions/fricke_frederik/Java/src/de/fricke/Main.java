package de.fricke;

import java.io.IOException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws IOException {
	    System.out.println("Type in a word or sentence to check for palindrome: ");
        Scanner scanner = new Scanner(System.in);
        String palinToCheck = scanner.nextLine();
        Palindrome palindrome = new Palindrome();
        System.out.println(palindrome.IsPalindrome(palinToCheck)
                ? "This is a palindrome!"
                : "This is not a palindrome!");

        scanner.nextLine();
    }
}
