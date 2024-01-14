namespace ADP.Algorithms.Graph;

public class Edge<T>
{
    public Vertex<T> DestinationVertext { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex<T> destinationVertex, int weight)
    {
        DestinationVertext = destinationVertex;
        Weight = weight;
    }
}
