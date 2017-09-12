namespace Graph
{
    using System;
    using System.Collections.Generic;

    public class Graph<T>
    {
        public List<Knot<T>> Knots { get; set; }

        public List<Edge<T>> Edges { get; set; }

        public Graph()
        {
            this.Knots = new List<Knot<T>>();
            this.Edges = new List<Edge<T>>();
        }

        public void Print()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("\nNodes: ");
            this.Knots.ForEach(knot => Console.Write(knot.Identifier + ", "));
            Console.WriteLine("\n\nEdges: ");
            this.Edges.ForEach(edge => Console.WriteLine($"{edge.From.Identifier} -> {edge.To.Identifier} = {edge.Distance}"));
            Console.WriteLine("\n=================================\n");
        }

        public void AddEdge(T from, T to, int distance = 1)
        {
            Knot<T> fromKnot = this.Knots.Find(knot => EqualityComparer<T>.Default.Equals(knot.Identifier, from));
            Knot<T> toKnot = this.Knots.Find(knot => EqualityComparer<T>.Default.Equals(knot.Identifier, to));
            try
            {
                this.Edges.Add(new Edge<T>(ref fromKnot, ref toKnot, distance));
            }
            catch (Exception error)
            {
                Console.WriteLine("Can't add edge: " + error.Message);
            }
        }

        public void RemoveEdge(T from, T to)
        {
            this.Edges.Remove(this.Edges.Find(
                edge => EqualityComparer<T>.Default.Equals(edge.From.Identifier, from)
                        && EqualityComparer<T>.Default.Equals(edge.To.Identifier, to)));
        }

        public void AddKnot(T id)
        {
            this.Knots.Add(new Knot<T>(id));
        }

        public void RemoveKnot(T value)
        {
            this.Knots.Remove(this.Knots.Find(knot => EqualityComparer<T>.Default.Equals(knot.Identifier, value)));
            this.Edges.FindAll(
                edge => EqualityComparer<T>.Default.Equals(edge.From.Identifier, value)
                        || EqualityComparer<T>.Default.Equals(edge.To.Identifier, value)).ForEach(edge => this.Edges.Remove(edge));
        }

        public bool EdgeExists(T from, T to)
        {
            return this.Edges.Find(
                edge => EqualityComparer<T>.Default.Equals(edge.From.Identifier, from)
                        && EqualityComparer<T>.Default.Equals(edge.To.Identifier, to)) != null;
        }
    }
}