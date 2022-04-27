import java.util.*;

public class Main {

    /**
     * calculates the change money for a given cost when a customer gives a
     * certain amount of money
     *
     * @param cost total cost;
     * @param paid total paid;
     */
    private static List<Double> calculateChange(double cost, double paid) {

        //In Cent umrechnen
        int costcent = (int) (cost * 100);
        int paidcent = (int) (paid * 100);

        List<Double> changeList = new ArrayList<>();

        TreeMap<Integer, Integer> valueToAmount = new TreeMap<Integer,Integer>();

        //Zahlung muss mindestens gedeckt sein -> ansonsten throw ArithmeticException
        if(paidcent - costcent > 0) {

            int change = paidcent - costcent;
            System.out.println(change);
            int digits = countDigits(change,0);

            int divider = 0;

            //Weniger als 5 stellen -> anderer modulus nötig (unter 100 euro schein)
            if(digits < 5) {
                divider = (int) Math.pow(10, digits -1);
            } else {

                divider = (int) Math.pow(10, 4);
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
                        valueToAmount.put(10000, value);
                        break;
                    //50er, 20er, 10er
                    case 4:
                        //Wiederholt sich zu oft -> ändern
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.put(5000, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.put(2000, amount);

                            }
                            valueToAmount.put(1000, value);
                        }
                        break;
                    // 5er
                    case 3:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.put(500, amount);
                        }
                        valueToAmount.put(50, value * 2);
                        break;
                    //50cent, 20cent, 10cent
                    case 2:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            //Spezialfall, weil es keine 2 und 1 Euro Stücke gibt
                            if(valueToAmount.containsKey(50)) {
                                amount = amount + valueToAmount.get(50);
                            }

                            valueToAmount.put(50, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.put(20, amount);
                            }
                            valueToAmount.put(10, value);
                        }
                        break;
                    //5cent, 2cent, 1cent
                    case 1:
                        if(value % 5 >= 0) {
                            amount = value / 5;
                            value = value % 5;
                            valueToAmount.put(5, amount);

                            if(value % 2 >= 0) {
                                amount = value / 2;
                                value = value % 2;
                                valueToAmount.put(2, amount);
                            }
                            valueToAmount.put(1, value);
                        }
                        break;

                }

                digits--;
                divider = (int) Math.pow(10, digits -1);

            }

            //Von HashMap zu Liste

            Iterator<Integer> it = valueToAmount.descendingMap().keySet().iterator();

            //Wäre auch einfacher gegangen, aber ich wollte nur die vorhandenen, nicht die 0er
            //List<Value> list = new ArrayList<Value>(map.values());
            //Noch als centangabe
            while(it.hasNext()) {
                int money = it.next();

                int anzahl = valueToAmount.get(money);
                if(anzahl > 0) {

                    for(int i=0; i < anzahl; i++) {
                        changeList.add((double) money / 100 );
                    }

                }

            }



        }

        return changeList;
    }

    private static int countDigits (int number, int counter) {

        return (number == 0) ? counter : countDigits(number / 10, counter = counter + 1);

    }

    public static void main(String[] args) throws Exception {
        // In C wahrschein cin cout um die Werte einzugeben
        System.out.println(calculateChange(2.50, 2.60));

    }


}