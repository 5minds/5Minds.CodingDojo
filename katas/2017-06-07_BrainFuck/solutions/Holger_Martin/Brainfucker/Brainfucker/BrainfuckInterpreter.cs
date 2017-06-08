using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfucker
{
    public class BrainfuckInterpreter
    {
        private List<byte> buffer = new List<byte>() { 0 };
        private List<StringBuilder> sequences = new List<StringBuilder>();

        private int position = 0;

        private int openBracketCounter;

        public void Interprete(string code)
        {
            bool capture = false;

            foreach (var command in code)
            {
                switch (command)
                {
                    case '>':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        this.position++;

                        if (this.position >= this.buffer.Count)
                        {
                            this.buffer.Add(0);
                        }

                        break;
                    case '<':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        this.position--;
                        break;
                    case '+':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        this.buffer[this.position] += 1;
                        break;
                    case '-':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        this.buffer[this.position] -= 1;
                        break;
                    case '.':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        Console.Write((char)this.buffer[this.position]);
                        break;
                    case ',':

                        if (capture)
                        {
                            this.sequences[this.openBracketCounter - 1].Append(command);
                            break;
                        }

                        var key = Console.ReadKey().KeyChar;
                        this.buffer[this.position] = (byte)key;
                        break;

                    case '[':

                        if (capture)
                        {
                            this.sequences[this.sequences.Count - 1].Append(command);
                            break;
                        }

                        capture = true;
                        this.openBracketCounter++;
                        this.sequences.Add(new StringBuilder());
                        break;
                    case ']':

                        while (this.buffer[this.position] > 0)
                        {
                            this.Interprete(this.sequences[this.sequences.Count - 1].ToString());
                        }

                        this.openBracketCounter--;
                        this.sequences.RemoveAt(this.openBracketCounter);
                        capture = this.openBracketCounter > 0;

                        break;
                }
            }
        }
    }
}
