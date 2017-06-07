using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck
{
    public sealed class BrainfuckInterpreter
    {
        private readonly Dictionary<int, int> memory = new Dictionary<int, int> { { 0, 0 } };

        private int memoryPosition = 0;
        private int inputSequencePosition = 0;

        public void Process(string inputSequence)
        {
            int bracketCount = 0;

            while (inputSequencePosition < inputSequence.Length)
            {
                char instruction = inputSequence[inputSequencePosition++];

                switch (instruction)
                {
                    case '>':
                        memoryPosition++;
                        if (!memory.ContainsKey(memoryPosition))
                            memory.Add(memoryPosition, 0);
                        break;

                    case '<':
                        memoryPosition--;
                        break;

                    case '+':
                        memory[memoryPosition] = memory[memoryPosition] + 1;
                        break;

                    case '-':
                        memory[memoryPosition] = memory[memoryPosition] - 1;
                        break;

                    case '.':
                        Console.Write(Encoding.ASCII.GetString(new[] { (byte)memory[memoryPosition] }));
                        break;

                    case ',':
                        memory[memoryPosition] = Console.Read();
                        break;

                    case '[':
                        if (memory[memoryPosition] == 0)
                        {
                            bracketCount = 0;
                            do
                            {
                                int c = inputSequence[inputSequencePosition++];
                                if (c == '[')
                                    bracketCount++;
                                else if (c == ']' && bracketCount == 0)
                                    break;
                                else if (c == ']')
                                    bracketCount--;
                            }
                            while (true);
                        }
                        break;

                    case ']':
                        if (memory[memoryPosition] != 0)
                        {
                            inputSequencePosition--;
                            bracketCount = 0;
                            do
                            {
                                int c = inputSequence[--inputSequencePosition];
                                if (c == ']')
                                    bracketCount++;
                                else if (c == '[' && bracketCount == 0)
                                    break;
                                else if (c == '[')
                                    bracketCount--;
                            }
                            while (true);
                        }
                        break;
                }
            }
        }
    }
}