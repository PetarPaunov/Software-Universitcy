using System;
using System.Collections.Generic;
namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingCap = new Dictionary<string, string>();
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string name = input[1];
                
                if (command == "register")
                {
                    string plateNumber = input[2];
                    string savedPlateNumber = plateNumber;
                    if (!parkingCap.ContainsKey(name))
                    {       
                        parkingCap.Add(name, plateNumber);
                        Console.WriteLine($"{name} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {savedPlateNumber}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!parkingCap.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        parkingCap.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var person in parkingCap)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }
        }
    }
}
