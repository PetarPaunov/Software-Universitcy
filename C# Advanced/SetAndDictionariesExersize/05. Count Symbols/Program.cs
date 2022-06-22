using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> ocurances = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!ocurances.ContainsKey(text[i]))
                {
                    ocurances.Add(text[i], 0);
                }

                ocurances[text[i]]++;
            }

            foreach (var sybol in ocurances.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sybol.Key}: {sybol.Value} time/s");
            }
        }
    }
}
