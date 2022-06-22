using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startNum = input[0];
            int endNum = input[1];

            List<int> numbers = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = number => number % 2 == 0;

            string command = Console.ReadLine();

            if (command == "even")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => even(x))));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => !even(x))));
            }
            
        }
    }
}
