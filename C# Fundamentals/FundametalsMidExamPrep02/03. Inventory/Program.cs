using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] commandArgs = command.Split(" - ");
                string commandName = commandArgs[0];
                string item = commandArgs[1];
                if (commandName == "Collect")
                {
                    if (!input.Contains(item))
                    {
                        input.Add(item);
                    }
                }
                else if (commandName == "Drop")
                {
                    input.Remove(item);
                }
                else if (commandName == "Combine Items")
                {
                    string[] splitedItems = item.Split(":");
                    string oldItem = splitedItems[0];
                    string newItem = splitedItems[1];

                    int idex = input.IndexOf(oldItem);

                    if (idex >= 0 )
                    {
                        input.Insert(idex + 1, newItem);
                    }
                }
                else if (commandName == "Renew")
                {
                    bool isDeletd = input.Remove(item);

                    if (isDeletd)
                    {
                        input.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", input));
         
        }
    }
}
