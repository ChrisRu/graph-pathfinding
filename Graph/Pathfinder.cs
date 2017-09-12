namespace Graph
{
    using System;
    using System.Collections.Generic;

    public class Pathfinder<T>
    {
        public T FindPath(Graph<T> graph, T fromId, T toId)
        {
            Knot<T> from = graph.Knots.Find(knot => object.Equals(fromId, knot.Identifier));
            Knot<T> to = graph.Knots.Find(knot => object.Equals(toId, knot.Identifier));

            List<Knot<T>> openSet = new List<Knot<T>> { from };
            List<Knot<T>> closedSet = new List<Knot<T>>();

            graph.Knots.ForEach(
                knot =>
                    {
                        knot.CurrentDistance = int.MaxValue;
                        knot.From = null;
                    });

            from.CurrentDistance = 0;

            Knot<T> current = from;
            while (openSet.Count > 0)
            {
                if (EqualityComparer<T>.Default.Equals(to.Identifier, current.Identifier))
                {
                    return current.Identifier;
                }

                graph.Edges
                    .FindAll(edge => EqualityComparer<T>.Default.Equals(edge.From.Identifier, current.Identifier))
                    .ForEach(
                        edge =>
                            {
                                int alt = current.CurrentDistance + edge.Distance;
                                if (alt < edge.To.CurrentDistance)
                                {
                                    edge.To.From = current;
                                    edge.To.CurrentDistance = alt;
                                }

                                if (closedSet.Contains(edge.To) == false)
                                {
                                    openSet.Add(edge.To);
                                }
                            });

                closedSet.Add(current);

                int smallest = int.MaxValue;
                foreach (Knot<T> knot in openSet)
                {
                    if (knot.CurrentDistance < smallest && closedSet.Contains(knot) == false)
                    {
                        smallest = knot.CurrentDistance;
                        current = knot;
                    }
                }
            }

            return EqualityComparer<T>.Default.Equals(to.Identifier, current.Identifier) ? current.Identifier : default(T);
        }

        public void Print(Knot<T> from)
        {
            List<Knot<T>> path = this.GetPath(from);
            path.Reverse();

            for (int i = 0; i < path.Count; i++)
            {
                if (i < path.Count - 1)
                {
                    Console.Write(path[i].Identifier + " -> ");
                }
                else
                {
                    Console.Write(path[i].Identifier);
                }
            }

            Console.Write($" ({from.CurrentDistance})");
            Console.WriteLine();

            int walkedLength = 0;
            for (int i = 0; i < path.Count; i++)
            {
                if (i < path.Count - 1)
                {
                    walkedLength += path[i].CurrentDistance - walkedLength;

                    int current = path[i + 1].CurrentDistance - walkedLength;
                    string distanceString = current < 10 && current > 0 ? current + " " : current.ToString();
                    Console.Write($"  {distanceString} ");
                }
            }

            Console.WriteLine();
        }

        public List<Knot<T>> GetPath(Knot<T> from)
        {
            return this.GetPath(new List<Knot<T>> { from }, from);
        }

        private List<Knot<T>> GetPath(List<Knot<T>> nodes, Knot<T> from)
        {
            if (from?.From != null)
            {
                nodes.Add(from.From);
                return this.GetPath(nodes, from.From);
            }

            return nodes;
        }
    }
}
