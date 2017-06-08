using System;

namespace brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            //interpret(">>+++++++++++++++++++++++++++++++++++++++++++.");
            interpret("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.+++.");
        }

        static int seekLoopEnd(string sourceCode, int programPointer)
        {
            var found = false;
            var increment = 0;
            while(!found)
            {
                if(sourceCode[programPointer] == ']')
                {
                    found = true;
                }
                else
                {
                    programPointer++;
                    increment++;
                }
            }

            return increment;
        }

        static int seekLoopStart(string sourceCode, int programPointer)
        {
            var found = false;
            var decrement = 0;
            while(!found)
            {
                if(sourceCode[programPointer] == '[')
                {
                    found = true;
                }
                else
                {
                    programPointer--;
                    decrement++;
                }
            }

            return decrement;
        }

        static void interpret(string sourceCode)
        {
            var valuePointer = 0;
            var programPointer = 0;
            var values = new int[100];
            
            while(programPointer <= sourceCode.Length-1)
            {
                switch (sourceCode[programPointer])
                {
                    case '>':
                    {
                        valuePointer++;
                        programPointer++;
                        break;
                    }
                    case '<':
                    {
                        valuePointer--;
                        programPointer++;
                        break;                       
                    }
                    case '+':
                    {
                        values[valuePointer]++;
                        programPointer++;
                        break;
                    }
                    case '-':
                    {
                        values[valuePointer]--;
                        programPointer++;
                        break;
                    }
                    case '.':
                    {
                        Console.Write($"{Convert.ToChar(values[valuePointer])}");
                        programPointer++;     
                        break;                   
                    }
                    case '[':
                    {
                        if(values[valuePointer] != 0)
                        {
                            programPointer++;
                        }
                        else
                        {
                            programPointer += seekLoopEnd(sourceCode, programPointer)+ 1;

                        }
                        break;
                    }
                    case ']':
                    {
                        if(values[valuePointer] == 0)
                        {
                            programPointer++;
                        }
                        else
                        {
                            programPointer -= seekLoopStart(sourceCode, programPointer);

                        }
                        break;   
                    }
                }
            }
        }
    }
}
