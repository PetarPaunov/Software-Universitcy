using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cloths = Console.ReadLine().Split(" ")
                .Select(int.Parse).ToArray();

            int rackCapasity = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>();

            foreach (var cloth in cloths)
            {
                box.Push(cloth);
            }

            int rackCouter = 0;
            int clothSum = 0;

            while (box.Count != 0)
            {
                if (clothSum + box.Peek() > rackCapasity)
                {
                    clothSum = 0;
                    rackCouter++;
                    continue;
                    
                }
                else
                {
                    if (box.Count == 1)
                    {
                        rackCouter++;
                    }
                    clothSum += box.Pop();
                }
                
                
                

            }

            Console.WriteLine(rackCouter);
        }
    }
}
