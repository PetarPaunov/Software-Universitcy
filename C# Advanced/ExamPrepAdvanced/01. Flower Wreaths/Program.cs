using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int wreaths = 0;
            int flowersForLater = 0;
            while (lilies.Count != 0 && roses.Count != 0)
            {
                int lilie = lilies.Peek();
                int rose = roses.Peek();

                int sumOfThem = lilie + rose;

                if (sumOfThem == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sumOfThem > 15)
                {
                    
                    while (true )
                    {
                        lilie -= 2;
                        if (lilie + rose == 15)
                        {
                            wreaths++;
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                        else if (lilie + rose < 15)
                        {
                            flowersForLater += lilie + rose;
                             
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                         
                    }
                }
                else if (sumOfThem < 15)
                {
                    flowersForLater += lilie + rose;
                    lilies.Pop();
                    roses.Dequeue();
                }

            }
            
            int increse = flowersForLater / 15;
            wreaths += increse;


            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                int needed = 5 - wreaths;
                Console.WriteLine($"You didn't make it, you need {needed} wreaths more!");
            }

        }
    }
}
