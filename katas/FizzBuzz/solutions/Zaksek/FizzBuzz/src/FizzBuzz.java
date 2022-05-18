public class FizzBuzz
{
    public static void main(String[] args)
    {
        String ausgabe = "";
        for (int i = 1; i <= 100; i++)
        {
            if (i % (3 * 5) == 0)
            {
                ausgabe += "FizzBuzz \n";
            }
            else if (Integer.toString(i).contains("3") && Integer.toString(i).contains("5"))
            {
                ausgabe += "FizzBuzz \n";
            }
            else if (i % 3 == 0)
            {
                ausgabe += "Fizz \n";
            }
            else if (i % 5 == 0)
            {
                ausgabe += "Buzz \n";
            }
            else if (Integer.toString(i).contains("3"))
            {
                ausgabe += "Fizz \n";
            }
            else if (Integer.toString(i).contains("5"))
            {
                ausgabe += "Buzz \n";
            }
            else
            {
               ausgabe += Integer.toString(i) + "\n";
            }
        }

        System.out.println(ausgabe + "");
    }
}
