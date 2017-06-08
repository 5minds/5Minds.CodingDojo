namespace Brainfuck
{
    class Program
    {
        private const string HelloWorld = 
            @"++++++++++
             [
              >+++++++>++++++++++>+++>+<<<<-
             ]
             >++.
             >+.
             +++++++.
             .
             +++.
             >++.
             <<+++++++++++++++.
             >.
             +++.
             ------.
             --------.
             >+.
             >.
             +++.";

        static void Main(string[] args)
        {
            var interpreter = new BrainfuckInterpreter();

            interpreter.Process(HelloWorld);
        }
    }
}
