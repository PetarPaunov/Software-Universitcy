using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> sortedChemicals = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] chemicals = Console.ReadLine().Split(" ");

                for (int j = 0; j < chemicals.Length; j++)
                {
                    sortedChemicals.Add(chemicals[j]);
                }
            }

            foreach (var chmical in sortedChemicals)
            {
                Console.Write(chmical + " ");
            }
        }
    }
}
