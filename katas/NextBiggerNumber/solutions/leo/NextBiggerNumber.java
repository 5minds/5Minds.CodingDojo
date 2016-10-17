/*
nextBigger(12) == 21

nextBigger(512) == 521

nextBigger(2017) == 2071

nextBigger(459853) == 483559

nextBigger(9) == -1

 */
public class NextBiggerNumber {

    private static String swap(String wort, int ersteStelle, int zweiteStelle) {

	char[] c = wort.toCharArray();
	char temp = c[ersteStelle];
	c[ersteStelle] = c[zweiteStelle];
	c[zweiteStelle] = temp;
	return new String(c);
    }

    private static int nextBigger(int zahl) {
	String zahl_s = zahl+"";
	int index = zahl_s.length();
	for (int i = zahl_s.length()-1; i >= 0; i--) {
	    for (int j = zahl_s.length()-1 ; j > i; j--) {
		String candidate = swap(zahl_s, i, j);
		candidate = candidate.substring(0,i+1) + makeSmall(candidate.substring(i+1));
		if (Integer.parseInt(candidate) > zahl) {
		    return Integer.parseInt(candidate);
		}
	    }
	}
	return -1;
    }

    private static String makeSmall(String zahl) {
	char[] test = zahl.toCharArray();
	java.util.Arrays.sort(test);
	return new String(test);
    }
    
    private static void check(int actual, int expected) throws Exception{
	if (expected != actual) {
	    throw new Exception(actual + " ist nicht das erwartete " + expected);
	} else {
	    System.out.println("Erfolg bei " + actual);
	}

    }
    public static void main(String[] args) throws Exception{
	check(nextBigger(12), 21);
	check(nextBigger(512), 521);
	check(nextBigger(2017), 2071);
	check(nextBigger(459853), 483559);

	check(nextBigger(9), -1);
	check(nextBigger(111), -1);
	check(nextBigger(531), -1);
    }

}
