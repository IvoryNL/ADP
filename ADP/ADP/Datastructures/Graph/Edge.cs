namespace ADP.Datastructures.Graph;

public class Edge<T>
{
    public Vertex<T> DestinationVertext { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex<T> destinationVertex, int weight)
    {
        DestinationVertext = destinationVertex;
        Weight = weight >= 0 ? weight : throw new ArgumentException("Weight cannot be negative");
    }
}
