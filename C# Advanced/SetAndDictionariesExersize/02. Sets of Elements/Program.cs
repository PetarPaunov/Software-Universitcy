using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int firstSetNums = input[0];
            int secondSetNums = input[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetNums; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < secondSetNums; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            List<int> numbers = firstSet.Intersect(secondSet).ToList();

            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}
