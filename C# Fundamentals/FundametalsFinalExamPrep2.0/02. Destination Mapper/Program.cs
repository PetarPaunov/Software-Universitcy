using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=\/]{1})([A-Z][A-Za-z]{2,})\1{1}";
            string input = Console.ReadLine();
            int travelPoint = 0;
            MatchCollection destination = Regex.Matches(input, pattern);
            List<string> endpfase = new List<string>();
            Console.Write("Destinations: ");


            foreach (Match match in destination)
            {
                
                string currentDestination = match.Groups[2].Value;

                travelPoint += currentDestination.Length;

                endpfase.Add(currentDestination);  
            }

            Console.WriteLine(string.Join(", ", endpfase));

            Console.WriteLine($"Travel Points: {travelPoint}");


        }
    }
}
