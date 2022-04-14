using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ")
                .ToArray();
            string command = Console.ReadLine();
            int blackListed = 0;
            int lost = 0;


            while (command != "Report")
            {
                string[] inputArgs = command.Split(" ");
                string action = inputArgs[0];

                if (action == "Blacklist")
                {
                    bool isFound = false;
                    string name = inputArgs[1];
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == name)
                        {
                            isFound = true;
                            blackListed++;
                            names[i] = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (action == "Error")
                {
                    int index = int.Parse(inputArgs[1]);
                    if (index >= 0 && index < names.Length && names[index] != "Blacklisted" && names[index] != "Lost")
                    {
                        lost++;
                        string namesInIndex = names[index];
                        names[index] = "Lost";
                        Console.WriteLine($"{namesInIndex} was lost due to an error.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }


                }
                else if (action == "Change")
                {
                    int index = int.Parse(inputArgs[1]);
                    string name = inputArgs[2];
                    if (index >= 0 && index < names.Length)
                    {
                        string nameOfIndex = names[index];
                        names[index] = name;
                        Console.WriteLine($"{nameOfIndex} changed his username to {name}.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blackListed}");
            Console.WriteLine($"Lost names: {lost}");
            Console.WriteLine(string.Join(" ", names));
        }
    }
}
