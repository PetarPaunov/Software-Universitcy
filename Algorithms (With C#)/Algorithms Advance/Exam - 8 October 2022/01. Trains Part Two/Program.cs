namespace _01._Trains_Part_Two
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

            var solutionPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var source = solutionPoints[0];
            var destination = solutionPoints[1];

            var graph = new Dictionary<int, List<Edge>>();

            for (int node = 0; node < nodes; node++)
            {
                graph.Add(node, new List<Edge>());
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                var edge = new Edge()
                {
                    FirstNode = firstNode,
                    SecondNode = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            var distance = new double[nodes];
            var parent = new int[nodes];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }

            distance[source] = 0;

            var bag = new OrderedBag<int>
                (Comparer<int>.Create((x, y) => (int)(distance[x] - distance[y])));
            bag.Add(source);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(minNode) || minNode == destination)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    var otherNode = edge.FirstNode == minNode ? edge.SecondNode : edge.FirstNode;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    var newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distance[otherNode] = newDistance;

                        bag = new OrderedBag<int>(
                            bag, 
                            Comparer<int>.Create((x, y) => (int)(distance[x] - distance[y])));
                    }
                }
            }

            var path = new Stack<int>();

            var endNode = destination;

            while (endNode != -1)
            {
                path.Push(endNode);
                endNode = parent[endNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}