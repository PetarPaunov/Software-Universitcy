using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newInput = new List<int>();

            double avarge = input.Sum() / (double)input.Count();

            if (input.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > avarge)
                {
                    newInput.Add(input[i]);
                }
            }

            if (newInput.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (input.Count < 5)
            {
                Console.WriteLine("Less than 5 numbers");
            }
            else
            {
                var result = newInput.OrderByDescending(x => x).Where(x => x > avarge).Take(5).ToArray();

                Console.WriteLine(string.Join(" ", result));
            }
            

        }
    }
}
