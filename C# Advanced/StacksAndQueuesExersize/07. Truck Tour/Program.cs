using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> truckTour = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] petrolDistans = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                truckTour.Enqueue(petrolDistans);
            }

            int startIndex = 0;

            while (true)
            {
                int currentPetrol = 0;

                foreach (var info in truckTour)
                {
                    int truckPetrol = info[0];
                    int truckDistance = info[1];

                    currentPetrol += truckPetrol;
                    currentPetrol -= truckDistance;

                    if (currentPetrol < 0)
                    {
                        int[] elemten = truckTour.Dequeue();
                        truckTour.Enqueue(elemten);
                        startIndex++;
                        break;
                    }
                }

                if (currentPetrol >= 0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
