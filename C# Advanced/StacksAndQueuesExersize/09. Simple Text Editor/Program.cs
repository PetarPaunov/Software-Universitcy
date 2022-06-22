using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> undo = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ")
                    .ToArray();
                if (info[0] == "1")
                {
                    undo.Push(sb.ToString());
                    string text = info[1];
                    sb.Append(text);
                }
                else if (info[0] == "2")
                {
                    undo.Push(sb.ToString());
                    int count = int.Parse(info[1]);
                    while (count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        count--;
                    }
                }
                else if (info[0] == "3")
                {
                    
                    int element = int.Parse(info[1]);
                    Console.WriteLine(sb[element - 1]);
                }
                else if (info[0] == "4")
                {
                    sb.Clear();
                    sb.Append(undo.Pop());
                }
            }
        }
    }
}
