using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] cloths = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    
                }

                foreach (var item in cloths)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }

            }

            string[] clothLookingFor = Console.ReadLine().Split(" ");
            string colorLookingFor = clothLookingFor[0];
            string dressLookingFor = clothLookingFor[1];

            foreach (var (color, cloth) in wardrobe)
            {
                Console.WriteLine($"{color} cloths:");
                foreach (var (cloths, count) in cloth)
                {

                    if (colorLookingFor == color && dressLookingFor == cloths)
                    {
                        Console.WriteLine($"* {cloths} - {count} (found!)");

                        continue;
                    }
                    Console.WriteLine($"* {cloths} - {count}");

                    
                }
            }

            
        }
    }
}
