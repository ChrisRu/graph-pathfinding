namespace Graph
{
    public class Knot<T>
    {
        public T Identifier { get; set; }

        public int CurrentDistance { get; set; }

        public Knot<T> From { get; set; }

        public Knot(T id)
        {
            this.Identifier = id;
        }
    }
}
