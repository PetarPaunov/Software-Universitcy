namespace _01._Tour_de_Sofia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Program
    {
        class Edge
        {
            public int FirstNode { get; set; }
            public int SecondNode { get; set; }
            public int Weight { get; set; }
        }

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var startNode = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];

                graph[from].Add(new Edge()
                {
                    FirstNode = from,
                    SecondNode = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            var distance = new double[nodes];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            var bag = new OrderedBag<int>(
                Comparer<int>.Create((x, y) => distance[x].CompareTo(distance[y])));

            foreach (var edge in graph[startNode])
            {
                distance[edge.SecondNode] = edge.Weight;
                bag.Add(edge.SecondNode);
            }

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (startNode == minNode)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    if (double.IsPositiveInfinity(distance[edge.SecondNode]))
                    {
                        bag.Add(edge.SecondNode);
                    }

                    var newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[edge.SecondNode])
                    {
                        distance[edge.SecondNode] = newDistance;
                    }

                    bag = new OrderedBag<int>(
                        bag,
                        Comparer<int>.Create((x, y) => distance[x].CompareTo(distance[y])));
                }
            }

            if (double.IsPositiveInfinity(distance[startNode]))
            {
                Console.WriteLine(distance.Count(x => !double.IsPositiveInfinity(x)) + 1);
            }
            else
            {
                Console.WriteLine(distance[startNode]);
            }
        }
    }
}