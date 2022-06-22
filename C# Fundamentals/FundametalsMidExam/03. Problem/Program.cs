using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine()
                .Split("|")
                .ToList();
            string command = Console.ReadLine();
            while (command != "Shop!")
            {
                string[] commandArgs = command.Split("%");
                string action = commandArgs[0];
                if (action == "Important")
                {
                    string productName = commandArgs[1];
                    if (products.Contains(productName)) 
                    {
                        products.Remove(productName);
                        products.Insert(0, productName);
                    }
                    else
                    {
                        products.Insert(0, productName);
                    }
                }
                else if (action == "Add")
                {
                    string productName = commandArgs[1];
                    if (!products.Contains(productName))
                    {
                        products.Add(productName);
                    }
                    else
                    {
                        Console.WriteLine("The product is already in the list.");
                    }

                }
                else if (action == "Swap")
                {
                    string firstProduct = commandArgs[1];
                    string secondProduct = commandArgs[2];
                    int fisrtIndex = 0;
                    int secondIndex = 0;

                    if (products.Contains(firstProduct) && products.Contains(secondProduct))
                    {
                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i] == firstProduct)
                            {
                                fisrtIndex = i;
                            }
                            else if (products[i] == secondProduct)
                            {
                                secondIndex = i;
                            }
                        }
                        string tmp = products[fisrtIndex];
                        products[fisrtIndex] = products[secondIndex];
                        products[secondIndex] = tmp;
                    }
                    else if (products.Contains(firstProduct) && !products.Contains(secondProduct))
                    {
                        Console.WriteLine($"Product {secondProduct} missing!");
                    }
                    else
                    {
                        Console.WriteLine($"Product {firstProduct} missing!");
                    }

                }
                else if (action == "Remove")
                {
                    string productName = commandArgs[1];
                    if (products.Contains(productName)) 
                    {
                        products.Remove(productName);
                    }
                    else
                    {
                        Console.WriteLine($"Product {productName} isn't in the list.");
                    }
                }
                else if (action == "Reversed")
                {
                    products.Reverse(); 
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"{i + 1}. {products[i]}");
                Console.WriteLine();
            }
        }
    }
}
