using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] diffNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Enumerable.Range(1, n).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in diffNumbers)
            {
                predicates.Add(x => x % number == 0);
            }

            foreach (var currentNumber in numbers)
            {
                bool isDevisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(currentNumber))
                    {
                        isDevisible = false;
                        break;
                    }
                }
                if (isDevisible)
                {
                    Console.Write(currentNumber + " ");
                }
            }
        }
    }
}
