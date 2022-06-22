using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participents = Console.ReadLine()
                .Split(", ");

            Dictionary<string, int> racers = new Dictionary<string, int>();
            string namePatern = @"[A-Za-z]";
            string digitPatern = @"[0-9]";

            foreach (var item in participents)
            {
                racers.Add(item, 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")  
            {
                StringBuilder name = new StringBuilder();

                int kilometars = 0;

                MatchCollection letters = Regex.Matches(input, namePatern);

                MatchCollection digits = Regex.Matches(input, digitPatern);
                 
                foreach (Match letter in letters)
                {
                    name.Append(letter);
                }

                foreach (Match digt in digits)
                {
                    kilometars += int.Parse(digt.Value);
                }

                if (!racers.ContainsKey(name.ToString()))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    racers[name.ToString()] += kilometars;
                }

                input = Console.ReadLine();
            }
            int counter = 1;
            foreach (var racer in racers.OrderByDescending(x => x.Value))
            {
                
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {racer.Key}");
                    
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {racer.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {racer.Key}");
                }
                counter++;
            }
        }
    }
}
