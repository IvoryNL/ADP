namespace ADP.Datastructures.Graph;

public class Vertex<T>
{
    public T Value { get; set; }

    public LinkedList<Edge<T>> Edges { get; set; } = new LinkedList<Edge<T>>();

    public Vertex(T value)
    {
        Value = value;
    }
}
