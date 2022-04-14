using System;
using System.Linq;
using System.Collections.Generic;
namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> conteinde = new Dictionary<char, int>();

            foreach (var cha in input)
            {
                if (cha == ' ')
                {
                    continue;
                }
                if (!conteinde.ContainsKey(cha))
                {
                    conteinde.Add(cha, 1);
                }
                else
                {
                    conteinde[cha]++;
                }
            }

            foreach (var item in conteinde)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
            
        }
    }
}
