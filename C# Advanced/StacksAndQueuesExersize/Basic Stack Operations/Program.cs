using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>();

            int numbersToPush = input[0];
            int numbersToPop = input[1];
            int elementShoudLookFor = input[2];

            int[] numbersInput = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbersToPush; i++)
            {
                numbers.Push(numbersInput[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                numbers.Pop();
            }
            int minValue = int.MaxValue;
            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
                
            }
            else if (!numbers.Contains(elementShoudLookFor))  
            {
                
                foreach (var element in numbers)
                {
                    if (minValue > element)
                    {
                        minValue = element;
                    }
                }
                Console.WriteLine(minValue);
            }
            else if (numbers.Contains(elementShoudLookFor))
            {
                Console.WriteLine("true");
            }
            
        }
    }
}
