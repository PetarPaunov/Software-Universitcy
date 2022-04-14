using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 },
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            bool isFound = false;
            while (!isFound)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    //Shards, Fragments and Motes
                    int quantity = int.Parse(input[i]);
                    string element = input[i + 1].ToLower();

                    if (element == "shards")
                    {
                        items["shards"] += quantity;
                    }
                    else if (element == "fragments")
                    {
                        items["fragments"] += quantity;
                    }
                    else if (element == "motes")
                    {
                        items["motes"] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(element))
                        {
                            junk.Add(element, 0);
                        }
                        junk[element] += quantity;
                    }

                    if (items.Values.Any(x => x >= 250))
                    {
                        isFound = true;
                        break;
                    }

                }
            }
            if (items["motes"] >= 250)
            {
                items["motes"] -= 250;
                Console.WriteLine("Dragonwrath obtained!");
            }
            else if (items["fragments"] >= 250)
            {
                items["fragments"] -= 250;
                Console.WriteLine("Valanyr obtained!");
            }
            else if (items["shards"] >= 250)
            {
                items["shards"] -= 250;
                Console.WriteLine("Shadowmourne obtained!");
            }

            foreach (var element in items.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
            foreach (var junks in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junks.Key}: {junks.Value}");
            }
        }
    }
}
