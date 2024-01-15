namespace ADP.Datastructures.Graph;

public class Vertex<T> : IComparable<int>
{
    public T Value { get; set; }
    public Vertex<T>? PreviousVertex { get; set; }
    public int Distance { get; set; } = int.MaxValue;

    public LinkedList<Edge<T>> Edges { get; set; } = new LinkedList<Edge<T>>();

    public Vertex(T value)
    {
        Value = value;
    }

    public int CompareTo(int other)
    {
        return Distance.CompareTo(other);
    }
}
