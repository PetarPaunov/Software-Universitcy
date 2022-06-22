using System;
using System.Text.RegularExpressions;
namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattertn = @"([#\|])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})*\1(?<calories>\d{1,5})\1";

            string input = Console.ReadLine();
            int dayCaloris = 2000;
            MatchCollection matchs = Regex.Matches(input, pattertn);

            int caloriSum = 0;

            foreach (Match match in matchs)
            {
                caloriSum += int.Parse(match.Groups["calories"].Value);
            }

            int totalDays = caloriSum / dayCaloris;

            Console.WriteLine($"You have food to last you for: {totalDays} days!");

            foreach (Match products in matchs)
            {
                Console.WriteLine($"Item: {products.Groups["name"].Value}, Best before: {products.Groups["date"].Value}, Nutrition: {products.Groups["calories"].Value}");
            }
        }
    }
}
