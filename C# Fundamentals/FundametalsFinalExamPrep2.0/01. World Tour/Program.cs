using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] inputInfo = input.Split(":");
                string command = inputInfo[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(inputInfo[1]);
                    string town = inputInfo[2];

                    if (index >= 0)
                    {
                        stops = stops.Insert(index, town);
                    }
                    Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(inputInfo[1]);
                    int endIndex = int.Parse(inputInfo[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        int index = endIndex - startIndex;
                        stops = stops.Remove(startIndex, index + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (command == "Switch")
                {
                    string oldString = inputInfo[1];
                    string newString = inputInfo[2];

                    if (stops.Contains(oldString))  
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                    Console.WriteLine(stops);
                }
    
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
