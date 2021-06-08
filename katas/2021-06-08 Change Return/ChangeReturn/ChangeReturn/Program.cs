using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChangeReturn
{
    class Program
    { 
     /**
     * calculates the change money for a given cost when a customer gives a
     * certain amount of money
     *
     * @param cost total cost;
     * @param paid total paid;
     */
    private static ArrayList calculateChange(double cost, double paid) {

        //In Cent umrechnen
        int costcent = (int) (cost * 100);
        int paidcent = (int) (paid * 100);

        ArrayList changeList = new ArrayList();

        SortedDictionary<int, int> valueToAmount = new SortedDictionary<int, int>();

        /*//Gibt es wohl nicht in dotnet? Also müsste man Hashtable nutzen und sortieren // sorted Dic. gefunden
        TreeMap<Integer, Integer> valueToAmount = new TreeMap<Integer,Integer>();*/

        //Zahlung muss mindestens gedeckt sein -> ansonsten throw ArithmeticException
        if(paidcent - costcent > 0) {

            int change = paidcent - costcent;
            
            int digits = countDigits(change,0);

            int divider = 0;

            //Weniger als 5 stellen -> anderer modulus nötig (unter 100 euro schein)
            if(digits < 5) {
                divider = (int) Math.Pow(10, digits -1);
            } else {

                divider = (int) Math.Pow(10, 4);
                digits = 5;
            }


            int value = 0;
            int amount = 0;

            //Alle Stellen durchgehen und bewerten
            while(digits != 0) {

                //alles ab 10.000 ist ein Wert für die 100er Scheine
                value = change / divider;
                change = change % divider;

                switch(digits) {

                    //100er Scheine
                    case 5:
                        valueToAmount.Add(10000, value);
                        break;
                    //50er, 20er, 10er
                    case 4:
                        //Wiederholt sich zu oft -> ändern
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.Add(5000, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.Add(2000, amount);

                            }
                            valueToAmount.Add(1000, value);
                        }
                        break;
                    // 5er
                    case 3:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.Add(500, amount);
                        }
                        valueToAmount.Add(50, value * 2);
                        break;
                    //50cent, 20cent, 10cent
                    case 2:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            //Spezialfall, weil es keine 2 und 1 Euro Stücke gibt
                            if(valueToAmount.ContainsKey(50))
                            {
                                int variable;
                                valueToAmount.TryGetValue(50, out variable );
                                amount = amount + variable;
                            }

                            //Abhilfe, weil in dotnet der Key nicht überschrieben wird
                            valueToAmount.Remove(50);
                            
                            valueToAmount.Add(50, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.Add(20, amount);
                            }
                            valueToAmount.Add(10, value);
                        }
                        break;
                    //5cent, 2cent, 1cent
                    case 1:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.Add(5, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.Add(2, amount);
                            }
                            valueToAmount.Add(1, value);
                        }
                        break;

                }

                digits--;
                divider = (int) Math.Pow(10, digits -1);

            }

            //Von HashMap zu Liste
            
            //Iterator<Integer> it = valueToAmount.descendingMap().keySet().iterator(); 
            //statt Iterator, Enumerator zum iterieren über das Dictionary ODER foreach
            
            //Wäre auch einfacher gegangen, aber ich wollte nur die vorhandenen, nicht die 0er
            //List<Value> list = new ArrayList<Value>(map.values());
            //Noch als centangabe

            foreach (var v in valueToAmount.Reverse())
            {

                int money = v.Key;
                int anzahl;
                valueToAmount.TryGetValue(money, out anzahl );

                if(anzahl > 0) {

                    for(int i=0; i < anzahl; i++) {
                        changeList.Add((double) money / 100 );
                    }

                }
                
            }
            
        }
        
        Console.Write("Bezahlt = " + paid + "\n");
        Console.Write("Kosten = " + cost +"\n");
        Console.Write("Rückgeld = " + ((double) (paidcent - costcent) / 100) +"\n");
        
        return changeList;
    }

     /**
      * counts the Digits of a Number.
      * -> tailrecursion
      * 
      * @param number is the number
      * @param counter counts the digits
      */
    private static int countDigits (int number, int counter) {

        return (number == 0) ? counter : countDigits(number / 10, counter = counter + 1);

    }

        static void Main(string[] args)
        {
            
            ArrayList list = calculateChange(46.30, 50);

            foreach (var v in list)
            {
                Console.Write("+" + v + "\n");
            }
        }
    }
}
