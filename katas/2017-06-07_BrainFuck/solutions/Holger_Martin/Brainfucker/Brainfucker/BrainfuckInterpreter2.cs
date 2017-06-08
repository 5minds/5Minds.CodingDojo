using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfucker
{
    public class BrainfuckInterpreter2
    {
        private List<byte> buffer = new List<byte>() { 0 };
        private List<StringBuilder> sequences = new List<StringBuilder>();

        private int position = 0;

        private int openBracketCounter;

        public void Interprete(string code)
        {
            bool capture = false;

            for (int index = 0; index < code.Length; index++)
            {
                var command = code[index];

                switch (command)
                {
                    case '>':

                        this.position++;

                        if (this.position >= this.buffer.Count)
                        {
                            this.buffer.Add(0);
                        }

                        break;
                    case '<':

                        this.position--;
                        break;
                    case '+':

                        this.buffer[this.position] += 1;
                        break;
                    case '-':

                        this.buffer[this.position] -= 1;
                        break;
                    case '.':

                        Console.Write((char)this.buffer[this.position]);
                        break;
                    case ',':

                        var key = Console.ReadKey().KeyChar;
                        this.buffer[this.position] = (byte)key;
                        break;

                    case '[':

                        //this.openBracketCounter++;
                        //this.sequences.Add(new StringBuilder());

                        var sequence = Capture(code, index+1);

                        while (this.buffer[this.position] > 0)
                        {
                            this.Interprete(sequence);
                        }

                        break;
                    //case ']':
                    //    while (this.buffer[this.position] > 0)
                    //    {
                    //        this.Interprete(this.sequences[this.sequences.Count - 1].ToString());
                    //    }

                    //    this.openBracketCounter--;
                    //    this.sequences.RemoveAt(this.openBracketCounter);

                    //    break;
                }
            }
        }

        private string Capture(string code, int start)
        {
            StringBuilder sequence = new StringBuilder();
            int openBracketCount = 1;

            for (int i = start; i < code.Length; i++)
            {
                if (code[i] == '[')
                {
                    openBracketCount++;
                }

                if (code[i] == ']')
                {
                    openBracketCount--;
                    if (openBracketCount == 0)
                    {
                        return sequence.ToString();
                    }
                }

                sequence.Append(i);
            }

            throw new InvalidOperationException("No en");
        }
    }
}
