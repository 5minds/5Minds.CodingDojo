using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace awx2
{
    class Utils {

        public static long nextBigger(long number) {

            // Console.WriteLine("------------------");
            // Console.WriteLine("numberString: "+number);

            // nur natuerliche Zahlen einbeziehen; Zahlen zwischen 0 und 11 koennen aus ihren Zahlen keine naechst groessere Zahl bilden
            if( number < 12 ) {
                // Console.WriteLine("nummber < 12");
                return -1;
            }
            
            // Zahl in eine Zeichenkette formatieren
            string numberString = Convert.ToString(number);            
            // Zeichenkette in ein char-Array zerlegen
            char[] charArray = numberString.ToArray();
            // Reihenfolge der Zeichenkette für die Berechnung "umkehren"
            Array.Reverse(charArray);
            numberString = new string(charArray);
            // Console.WriteLine("numberString: "+numberString);
            
            // Die letzte Nummer aus der Nummernfolge waehrend der Schleife
            long lastNumber = -1;
            // Nummer aus der Nummernfolge die kleiner ist als ihr Vorgaenger
            long magicNumber = -1;
            // Vorderer Teil der Nummernfolge for der MagicNumber
            String firstPart = "";
            // Hinterer Teil der Nummernfolge nach der MagicNumber
            String lastPart = "";

            // Schleife zur Aufteilung der Nummernfolge und zur Identifizierung der MagicNumber
            foreach( char charArrayNumber in charArray ) {
                long thisNumber = Convert.ToInt64(""+charArrayNumber);

                if ( magicNumber != -1 ) {
                    firstPart += thisNumber;
                } else if( lastNumber != -1 && thisNumber < lastNumber ) {
                    // Console.WriteLine("magicNumber: " + thisNumber);
                    magicNumber = thisNumber;
                } else {
                    lastPart += thisNumber;
                }

                lastNumber = thisNumber;
            }

            // Nummernfolgen ohne eine MagicNumber koennen aus ihren Zahlen keine naechst groessere Zahl bilden
            if(magicNumber == -1) {
                // Console.WriteLine("noNextBiggerNumber");
                return -1;
            }

            // Gibt die nächst groessere Zahl aus dem hintern Teil der Nummernfolge zurück
            long nextBiggerLongChar = getNextBiggerFromString( magicNumber, lastPart);
            // Console.WriteLine("nextBiggerLongChar: " + nextBiggerLongChar);

            // Fügt die naechst groessere Zahl an den vorderen Teil der Nummernfolge
            firstPart = nextBiggerLongChar + firstPart;
            // Console.WriteLine("firstPart: " + firstPart);

            // Fügt die naechst groessere Zahl an den vorderen Teil der Nummernfolge
            lastPart = doMagic(magicNumber, nextBiggerLongChar, lastPart);
            // Console.WriteLine("lastPart: " + lastPart);

            // Fügt die naechst groessere Zahl an den vorderen Teil der Nummernfolge
            String nextBiggerNumberString = lastPart + firstPart ;

            // Reihenfolge der Zeichenkette nach der Berechnung wieder "umkehren"
            char[] nextBiggerNumberArray = nextBiggerNumberString.ToArray();
            Array.Reverse(nextBiggerNumberArray);
            nextBiggerNumberString = new string(nextBiggerNumberArray);
            // Console.WriteLine("nextBiggerNumberString: " + nextBiggerNumberString);

            return Convert.ToInt64(nextBiggerNumberString);
        }

        private static long getNextBiggerFromString( long refNumber, String numberString) {
            
            // Findet die naechst groessere Zahl aus dem NummernString
            char[] charArray = numberString.ToArray();
            foreach (char numberChar in charArray) {
                long thisNumber = Convert.ToInt64(""+numberChar);
                if( thisNumber > refNumber ) {                   
                   return thisNumber;
                }
            }

            return -1;
        }

         private static String doMagic(long magicNmber, long nextBiggerLongChar, string lastPart) {   

            // Entfernt die naechst groessere Zahl aus dem hintern Teil der Nummernfolge
            lastPart = new Regex(Regex.Escape(""+nextBiggerLongChar)).Replace(lastPart, "", 1);
            // Fügt die MagicNumber an (Nummer aus der Nummernfolge die kleiner war als ihr Vorgaenger)
            lastPart += magicNmber;

            // Sortiert die Zahlen absteigend (absteigend wegen der "umgekehrten" Berechnung)
            char[] charArray = lastPart.ToArray();
            Array.Sort(charArray); 
            Array.Reverse(charArray); 

            return new string(charArray);
        }

    }
}