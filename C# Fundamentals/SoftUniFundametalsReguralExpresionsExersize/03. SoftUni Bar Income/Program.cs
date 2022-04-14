using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%([A-Z]{1}[a-z]+)%.*<(\w+)>.*\|([0-9]+)\|.*?([0-9.]+)\$$";

            string input = Console.ReadLine();

            decimal totalSum = 0;

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string name = match.Groups[1].Value;
                string product = match.Groups[2].Value;
                int qty = int.Parse(match.Groups[3].Value);
                decimal price = decimal.Parse(match.Groups[4].Value);

                decimal totalPrice = qty * price;

                
                totalSum += totalPrice;

                Console.WriteLine($"{name}: {product} - {totalPrice:F2}");

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }
}
