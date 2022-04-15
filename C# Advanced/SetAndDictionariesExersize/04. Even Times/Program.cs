using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> evenNums = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string numbers = Console.ReadLine();

                if (!evenNums.ContainsKey(numbers))
                {
                    evenNums.Add(numbers, 0);
                }
                
                evenNums[numbers]++;           
            }

            Console.WriteLine(evenNums.First(x => x.Value % 2 == 0).Key);
        }
    }
}
