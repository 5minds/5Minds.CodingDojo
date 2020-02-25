
public class Palindrome {
	
public static void main(String[] args) {
		
		System.out.println("1." + isPalindrome("Abba"));
		System.out.println("2." + isPalindrome("Lagerregal"));
		System.out.println("3." + isPalindrome("Reliefpfeiler"));
		System.out.println("4." + isPalindrome("Rentner"));
		System.out.println("5." + isPalindrome("Dienstmannamtsneid"));
		System.out.println("6." + isPalindrome("Tarne nie deinen Rat!"));
		System.out.println("7." + isPalindrome("Eine güldne, gute Tugend: Lüge nie!"));
		System.out.println("8." + isPalindrome("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
		System.out.println("9." + isPalindrome("Abda"));
	}
	
	public static boolean isPalindrome(String word) {
		
		String replaceString = word.replaceAll("[ .,:;!?]", "");
		
		word = replaceString.toUpperCase(); 
		
		if(word.length() == 0 || word.length() == 1)
			return true;
		if(word.charAt(0) == word.charAt(word.length()-1))
			return isPalindrome(word.substring(1, word.length()-1));
		
		return false;
		
	}

}
