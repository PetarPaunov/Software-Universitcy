using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> pattern = new Stack<char>();
            bool isBaleced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    pattern.Push(input[i]);
                }
                else
                {
                    if (pattern.Count == 0)
                    {
                        isBaleced = false;
                        break;
                    }
                    if (input[i] == ')' && pattern.Peek() == '(')
                    {
                        pattern.Pop();
                    }
                    else if (input[i] == ']' && pattern.Peek() == '[')
                    {
                        pattern.Pop();
                    }
                    else if (input[i] == '}' && pattern.Peek() == '{')
                    {
                        pattern.Pop();
                    }
                    else
                    {
                        isBaleced = false;
                    }
                }

            }
            if (isBaleced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
