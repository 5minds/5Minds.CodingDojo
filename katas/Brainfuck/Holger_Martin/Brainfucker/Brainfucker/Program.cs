using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfucker
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var code = File.ReadAllText(@"C:\temp\hello.fuck");
            var code2 = File.ReadAllText(@"C:\temp\helloLoop.fuck");

            BrainfuckInterpreter interpreter = new BrainfuckInterpreter();
            //BrainfuckInterpreter2 interpreter = new BrainfuckInterpreter2();
            interpreter.Interprete(code);

            Console.ReadLine();
        }
    }
}
