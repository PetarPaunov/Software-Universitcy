using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int loot = 0;
            Queue<int> firstBox = new Queue<int>(input1);

            Stack<int> secondBox = new Stack<int>(input2);

            while (true)
            {
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (secondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();
                int itemsSum = firstItem + secondItem;
                if (itemsSum % 2 == 0)
                {
                    loot += itemsSum;

                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int secondBoxItem = secondBox.Pop();

                    firstBox.Enqueue(secondBoxItem);
                }
            }

            if (loot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
