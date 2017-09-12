namespace Graph
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Graph<char> graph = new Graph<char>();
            new List<char> { 'A', 'B', 'C', 'E', 'S', 'N' }.ForEach(graph.AddKnot);
            graph.AddEdge('S', 'A', 3);
            graph.AddEdge('S', 'B', 6);
            graph.AddEdge('S', 'C', 2);
            graph.AddEdge('A', 'E', 2);
            graph.AddEdge('A', 'N', 6);
            graph.AddEdge('B', 'N', 1);
            graph.AddEdge('C', 'E', 4);
            graph.AddEdge('E', 'N', 2);
            LogGraph(graph);

            Graph<char> graph2 = new Graph<char>();
            new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'S', 'N' }.ForEach(graph2.AddKnot);
            graph2.AddEdge('S', 'A', 1);
            graph2.AddEdge('S', 'B', 4);
            graph2.AddEdge('S', 'C', 5);
            graph2.AddEdge('C', 'E', 4);
            graph2.AddEdge('B', 'C', 2);
            graph2.AddEdge('B', 'D', 5);
            graph2.AddEdge('D', 'F', 3);
            graph2.AddEdge('F', 'G', 2);
            graph2.AddEdge('G', 'N', 1);
            graph2.AddEdge('G', 'E', 3);
            graph2.AddEdge('E', 'N', 8);
            graph2.AddEdge('A', 'D', 7);
            LogGraph(graph2);

            Graph<char> graph3 = new Graph<char>();
            new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'S', 'N' }.ForEach(graph3.AddKnot);
            graph3.AddEdge('S', 'A', 3);
            graph3.AddEdge('S', 'C', 2);
            graph3.AddEdge('S', 'B', 6);
            graph3.AddEdge('B', 'D', 1);
            graph3.AddEdge('C', 'E', 6);
            graph3.AddEdge('A', 'E', 4);
            graph3.AddEdge('A', 'D', 3);
            graph3.AddEdge('E', 'G', 9);
            graph3.AddEdge('D', 'F', 4);
            graph3.AddEdge('E', 'D', 2);
            graph3.AddEdge('G', 'D', 4);
            graph3.AddEdge('F', 'G', 4);
            graph3.AddEdge('G', 'N', 5);
            graph3.AddEdge('D', 'N', 12);
            LogGraph(graph3);

            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        public static void LogGraph(Graph<char> graph)
        {
            Console.WriteLine("\n\n\n\n\n\n---------------------");
            Console.WriteLine("------- GRAPH -------");
            Console.WriteLine("---------------------");

            graph.Print();

            Console.WriteLine("Shortest path between S (start) and N (end):");

            Pathfinder<char> pathFinder = new Pathfinder<char>();

            char found = pathFinder.FindPath(graph, 'S', 'N');
            Knot<char> foundKnot = graph.Knots.Find(knot => knot.Identifier == found);
            pathFinder.Print(foundKnot);
        }
    }
}
