using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int[]> givenCitys = new Dictionary<string, int[]>();

            while (input != "Sail")
            {
                string[] inputInfo = input.Split("||");
                string city = inputInfo[0];
                int population = int.Parse(inputInfo[1]);
                int gold = int.Parse(inputInfo[2]);
                if (!givenCitys.ContainsKey(city))
                {
                    givenCitys.Add(city, new int[] { population, gold });
                }
                else
                {
                    int[] currnetVelues = givenCitys[city];

                    currnetVelues[0] += population;
                    currnetVelues[1] += gold;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split("=>");
                string command = inputInfo[0];

                if (command == "Plunder")
                {
                    string town = inputInfo[1];
                    int people = int.Parse(inputInfo[2]);
                    int gold = int.Parse(inputInfo[3]);

                    int[] values = givenCitys[town];
                    values[0] -= people;
                    values[1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (values[0] <= 0 || values[1] <= 0)
                    {
                        givenCitys.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");

                    }
                }
                else if (command == "Prosper")
                {
                    string town = inputInfo[1];
                    int gold = int.Parse(inputInfo[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        input = Console.ReadLine();
                        continue;

                    }
                    else
                    {
                        int[] givenGold = givenCitys[town];
                        givenGold[1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {givenGold[1]} gold.");
                    }


                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ahoy, Captain! There are {givenCitys.Count} wealthy settlements to go to:");

            if (givenCitys.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                foreach (var city in givenCitys.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }


        }
    }
}
