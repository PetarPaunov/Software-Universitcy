using System;
using System.Collections.Generic;
namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> resoures = new Dictionary<string, int>();

            bool isOdd = true;
            string currentItem = string.Empty;
            while (input != "stop")
            {
                if (isOdd)
                {
                    if (!resoures.ContainsKey(input))
                    {
                        resoures.Add(input, 0);
                    }

                    currentItem = input;
                    isOdd = false;
                    
                }
                else
                {
                    resoures[currentItem] += int.Parse(input);
                    isOdd = true;
                }


                input = Console.ReadLine();
            }

            foreach (var item in resoures)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
