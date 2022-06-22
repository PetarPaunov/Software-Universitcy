using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();
            while (input[0] != "End")
            {
                string companyName = input[0];
                string employId = input[1];

                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                    company[companyName].Add(employId);
                }
                if(!company[companyName].Contains(employId))
                {
                    
                    company[companyName].Add(employId);
                }
                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var emplay in company.OrderBy(x => x.Key))
            {
                Console.WriteLine(emplay.Key);
                Console.Write("-- ");
                Console.WriteLine(string.Join("\n-- ", emplay.Value));
            }
        }
    }
}
