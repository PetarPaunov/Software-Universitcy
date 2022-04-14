using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToDecript = Console.ReadLine();

            string inputCommands = Console.ReadLine();

            while (inputCommands != "Finish")
            {
                string[] commandArgs = inputCommands.Split(" ");
                string command = commandArgs[0];

                if (command == "Replace")
                {
                    string currentChar = commandArgs[1];
                    string newChar = commandArgs[2];

                    stringToDecript = stringToDecript.Replace(currentChar, newChar);
                    Console.WriteLine(stringToDecript);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if (startIndex > 0 && endIndex < stringToDecript.Length)
                    {
                        int currentIdex = (endIndex - startIndex) + 1;
                        stringToDecript = stringToDecript.Remove(startIndex, currentIdex);
                        Console.WriteLine(stringToDecript);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (command == "Make")
                {
                    string upperOrLower = commandArgs[1];

                    if (upperOrLower == "Upper")
                    {
                        stringToDecript = stringToDecript.ToUpper();
                        Console.WriteLine(stringToDecript);
                    }
                    else
                    {
                        stringToDecript = stringToDecript.ToLower();
                        Console.WriteLine(stringToDecript);
                    }
                }
                else if (command == "Check")
                {
                    string substring = commandArgs[1];
                    if (stringToDecript.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if (startIndex > 0 && endIndex <stringToDecript.Length)
                    {
                        int index = (endIndex - startIndex) + 1;
                        int sum = 0;

                        string substring = stringToDecript.Substring(startIndex, index);
                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += substring[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }

                inputCommands = Console.ReadLine();
            }

        }
    }
}
