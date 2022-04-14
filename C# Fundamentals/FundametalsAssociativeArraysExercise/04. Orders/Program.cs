using System;
using System.Collections.Generic;
namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, double[]> endPfase = new Dictionary<string, double[]>();
            while (input != "buy")
            {
                string[] namePriceQuntity = input.Split(" ");
                string productName = namePriceQuntity[0];
                double productPrice = double.Parse(namePriceQuntity[1]);
                int quatity = int.Parse(namePriceQuntity[2]);

                if (!endPfase.ContainsKey(productName))
                {
                    endPfase.Add(productName, new double[2]);
                }
                double previousQantity = endPfase[productName][1];

                double[] priceQty = new double[] { productPrice, quatity + previousQantity };

                endPfase[productName] = priceQty;



                input = Console.ReadLine();
            }

            foreach (var product in endPfase)
            {
                double totalPrice = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key:F2} -> {totalPrice:F2}");
            }
        }
    }
}
