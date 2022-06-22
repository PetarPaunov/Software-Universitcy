using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            int maxElement = int.MinValue;
            int minElement = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine().Split(" ")
                    .Select(int.Parse).ToArray();

                if (queries[0] == 1)
                {
                    numbers.Push(queries[1]);

                }
                else if (queries[0] == 2)
                {
                    if (numbers.Count == 0)
                    {
                        continue;
                    }
                    numbers.Pop();
                }
                else if (queries[0] == 3)
                {
                    if (numbers.Count == 0)
                    {
                        continue;

                    }
                    else
                    {
                        foreach (var elemtsn in numbers)
                        {
                            if (maxElement < elemtsn)
                            {
                                maxElement = elemtsn;
                            }
                        }
                        Console.WriteLine(maxElement);
                    }
                }
                else if (queries[0] == 4)
                {
                    if (numbers.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (var element in numbers)
                        {
                            if (minElement > element)
                            {
                                minElement = element;
                            }
                        }
                        Console.WriteLine(minElement);
                    }

                }

            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
