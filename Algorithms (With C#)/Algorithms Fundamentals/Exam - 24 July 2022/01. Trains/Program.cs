namespace _01._Trains
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var arrival = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();

            var departure = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(FindAllRequiredPlatforms(arrival, departure));
        }

        private static int FindAllRequiredPlatforms(double[] arrival, double[] departure)
        {
            var arrivalPointer = 0;
            var departurePointer = 0;

            var requiredPlatforms = 0;
            var platforms = 0;

            while (arrivalPointer < arrival.Length)
            {
                var arrivalTrain = arrival[arrivalPointer];
                var departureTrain = departure[departurePointer];

                if (arrivalTrain < departureTrain)
                {
                    platforms++;
                    arrivalPointer++;
                    requiredPlatforms = Math.Max(platforms, requiredPlatforms);
                }
                else
                {
                    departurePointer++;
                    platforms--;
                }
            }

            return requiredPlatforms;
        }
    }
}