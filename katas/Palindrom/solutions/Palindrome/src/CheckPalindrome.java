public class CheckPalindrome {

	public static void main(String[] args) {
		runTests();
		System.out.println("Tests erfolgreich durchgelaufen!");
	}
	
	static boolean isPalindrome(String str)
	{
		str = str.toLowerCase().replaceAll("[^a-z0-9]", "");
		String strReverse = new StringBuilder(str).reverse().toString();
		return str.equals(strReverse);
	}
	
	static void runTests()
	{
		assert(isPalindrome("Abba"));
		assert(isPalindrome("Reliefpfeiler"));
		assert(isPalindrome("Rentner"));
		assert(!isPalindrome("Fumpp"));
		assert(isPalindrome("Dienstmannamtsneid"));
		assert(isPalindrome("Tarne nie deinen Rat!"));
		assert(isPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
		assert(isPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
	}
}
