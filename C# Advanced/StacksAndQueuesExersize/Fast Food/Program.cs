using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersQuatity = Console.ReadLine().Split(" ")
                .Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>();

            int biggestOrder = int.MinValue;

            foreach (var order in ordersQuatity)
            {
                orders.Enqueue(order);
            }

            foreach (var order in orders)
            {
                if (biggestOrder < order)
                {
                    biggestOrder = order;
                }

            }
            Console.WriteLine(biggestOrder);

            while (orders.Count > 0 && foodQuantity > 0)
            {
                int currentOrder = orders.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    orders.Dequeue();
                    foodQuantity -= currentOrder;
                    continue;
                }
                else
                {
                    break;
                }


            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
            }



            

        }
    }
}
