using System;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> requiredName = new List<string>();
            Predicate<string> namesLentgh = name => name.Length <= n;

            foreach (var name in names)
            {
                if (namesLentgh(name))
                {
                    requiredName.Add(name);
                }
            }

            foreach (var name in requiredName)
            {
                Console.WriteLine(name);
            }
            
        }
    }
}
