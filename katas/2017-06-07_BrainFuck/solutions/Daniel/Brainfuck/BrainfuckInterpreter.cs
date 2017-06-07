using System;
using System.Collections.Generic;
using System.Text;

namespace Brainfuck
{
    public sealed class BrainfuckInterpreter
    {
        private readonly Dictionary<int, int> memory = new Dictionary<int, int> { { 0, 0 } };

        private string inputSequence;
        private int memoryPosition = 0;
        private int inputSequencePosition = 0;
        private int bracketCount = 0;

        public void Process(string input)
        {
            inputSequence = input;

            while (inputSequencePosition < inputSequence.Length)
            {
                char instruction = inputSequence[inputSequencePosition++];

                switch (instruction)
                {
                    case '>':
                        MoveMemoryPositionForward();
                        break;

                    case '<':
                        MoveMemoryPositionBackward();
                        break;

                    case '+':
                        IncrementCurrentMemoryCell();
                        break;

                    case '-':
                        DecrementCurrentMemoryCell();
                        break;

                    case '.':
                        WriteCurrentMemoryValueToConsole();
                        break;

                    case ',':
                        ReadCurrentMemoryValueFromConsole();
                        break;

                    case '[':
                        SeekToClosingBracketIfNeeded();
                        break;

                    case ']':
                        SeekBeforeOpeningBracketIfNeeded();
                        break;
                }
            }
        }

        private void MoveMemoryPositionForward()
        {
            memoryPosition++;
            ExpandMemoryIfNeeded();
        }

        private void ExpandMemoryIfNeeded()
        {
            if (!memory.ContainsKey(memoryPosition))
            {
                memory.Add(memoryPosition, 0);
            }
        }

        private void MoveMemoryPositionBackward()
        {
            memoryPosition--;
        }

        private void IncrementCurrentMemoryCell()
        {
            memory[memoryPosition] = memory[memoryPosition] + 1;
        }

        private void DecrementCurrentMemoryCell()
        {
            memory[memoryPosition] = memory[memoryPosition] - 1;
        }

        private void WriteCurrentMemoryValueToConsole()
        {
            Console.Write((char)memory[memoryPosition]);
        }

        private void ReadCurrentMemoryValueFromConsole()
        {
            memory[memoryPosition] = Console.Read();
        }

        private void SeekToClosingBracketIfNeeded()
        {
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
        }

        private void SeekBeforeOpeningBracketIfNeeded()
        {
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
        }
    }
}