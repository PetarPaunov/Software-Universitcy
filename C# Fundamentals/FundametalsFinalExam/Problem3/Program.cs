using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> likedMeal = new Dictionary<string, List<string>>();
            //Dictionary<string, List<string>> unlikedMeal = new Dictionary<string, List<string>>();
            int counter = 0;
            while (command != "Stop")
            {
                string[] commandArgs = command.Split("-");
                string LikeUnlike = commandArgs[0];

                if (LikeUnlike == "Like")
                {
                    string guest = commandArgs[1];
                    string meal = commandArgs[2];
                    if (!likedMeal.ContainsKey(guest))
                    {
                        likedMeal.Add(guest, new List<string> { meal });
                        //unlikedMeal.Add(guest, new List<string> { meal });
                    }
                    else
                    {
                        if (likedMeal[guest].Contains(meal))
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            //unlikedMeal[guest].Add(meal);
                            likedMeal[guest].Add(meal);
                        }

                    }

                }
                else if (LikeUnlike == "Unlike")
                {
                    
                    string guest = commandArgs[1];
                    string meal = commandArgs[2];

                    if (!likedMeal.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!likedMeal[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        likedMeal[guest].Remove(meal);
                        counter++;
                    }

                }


                command = Console.ReadLine();
            }

            foreach (var meal in likedMeal.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{meal.Key}: {string.Join(", ", likedMeal[meal.Key])}");
            }
            Console.WriteLine($"Unliked meals: {counter}");
        }
    }
}
