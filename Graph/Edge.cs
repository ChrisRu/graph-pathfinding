namespace Graph
{
    using System;

    public class Edge<T>
    {
        public Knot<T> From { get; set; }

        public Knot<T> To { get; set; }

        public int Distance { get; set; }

        public Edge(ref Knot<T> from, ref Knot<T> to, int distance)
        {
            if (from == null || to == null)
            {
                throw new NullReferenceException("Knot not found");
            }

            this.From = from;
            this.To = to;
            this.Distance = distance;
        }
    }
}
