using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int elementsToEnqueue = input[0];
            int elementsToDequeue = input[1];
            int elementsToChekIfContanis = input[2];

            Queue<int> elements = new Queue<int>();

            int[] numbersInput = Console.ReadLine().Split(" ")
                .Select(int.Parse).ToArray();

            int minValue = int.MaxValue;

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                elements.Enqueue(numbersInput[i]);

            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                elements.Dequeue();
            }

            if (elements.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (elements.Contains(elementsToChekIfContanis))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var elemts  in elements)
                {
                    if (minValue > elemts)
                    {
                        minValue = elemts;
                    }
                }
                Console.WriteLine(minValue);
            }
        }
    }
}
