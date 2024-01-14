namespace ADP.Algorithms.Graph;

public class GraphADP<T>
{
    public Dictionary<T, Vertex<T>> AdjacencyList { get; set; } = new Dictionary<T, Vertex<T>>();

    public void AddVertex(T vertexValue)
    {
        if (AdjacencyList.ContainsKey(vertexValue))
        {
            throw new InvalidOperationException($"Vertex with the value {vertexValue} already exists");
        }

        var newVertex = new Vertex<T>(vertexValue);
        AdjacencyList.Add(vertexValue, newVertex);
    }

    public void RemoveVertex(T vertexValue)
    {
        if (!AdjacencyList.ContainsKey(vertexValue))
        {
            throw new KeyNotFoundException($"Vertex with the value {vertexValue} doesn't exists");
        }

        AdjacencyList.Remove(vertexValue);

        foreach (var vertex in AdjacencyList)
        {
            RemoveEdge(vertex.Value.Value, vertexValue);
        }
    }

    public void AddEdge(T sourceVertexValue, T destinationVertexValue, int weight = 0)
    {
        if (!AdjacencyList.ContainsKey(sourceVertexValue))
        {
            throw new KeyNotFoundException($"Source Vertex with the value {sourceVertexValue} doesn't exists");
        }

        var sourceVertex = AdjacencyList[sourceVertexValue];

        if (sourceVertex.Value.Equals(destinationVertexValue))
        {
            throw new InvalidOperationException($"Source Vertex cannot be the same as the destination Vertex {destinationVertexValue}");
        }

        var edgeExists = sourceVertex.Edges.Any(e => e.DestinationVertext.Value.Equals(destinationVertexValue));

        if (edgeExists)
        {
            throw new InvalidOperationException($"Edge with the destination Vertex {destinationVertexValue} already exists");
        }

        if (!AdjacencyList.ContainsKey(destinationVertexValue))
        {
            throw new KeyNotFoundException($"Destination Vertex with the name {destinationVertexValue} doesn't exists");
        }

        var destinationVertex = AdjacencyList[destinationVertexValue];
        var newEdge = new Edge<T>(destinationVertex, weight);
        sourceVertex.Edges.AddFirst(newEdge);
    }

    public void RemoveEdge(T sourceVertexValue, T destinationVertexValue)
    {
        if (!AdjacencyList.ContainsKey(sourceVertexValue))
        {
            throw new KeyNotFoundException($"Source Vertex with the name {sourceVertexValue} doesn't exists");
        }

        var sourceVertex = AdjacencyList[sourceVertexValue];
        var destinationVertext = sourceVertex.Edges.FirstOrDefault(e => e.DestinationVertext.Value.Equals(destinationVertexValue));

        if (destinationVertext != null)
        {
            sourceVertex.Edges.Remove(destinationVertext);
        }
    }

    public void BreadthFirstSearch(T startVertexValue)
    {
        var visitedVertices = new HashSet<T>();
        var vertexQueue = new Queue<Vertex<T>>();

        if (!AdjacencyList.ContainsKey(startVertexValue))
        {
            throw new KeyNotFoundException($"Start Vertex with the value {startVertexValue} doesn't exists");
        }

        var startVertext = AdjacencyList[startVertexValue];
        vertexQueue.Enqueue(startVertext);
        visitedVertices.Add(startVertexValue);

        while (vertexQueue.Count() > 0)
        {
            var start = vertexQueue.Dequeue();
            Console.Write(start.Value + " ");

            foreach (var adjacentVertex in start.Edges)
            {
                var adjacentVertexName = adjacentVertex.DestinationVertext.Value;
                if (!visitedVertices.Contains(adjacentVertexName))
                {
                    visitedVertices.Add(adjacentVertexName);
                    vertexQueue.Enqueue(adjacentVertex.DestinationVertext);
                }
            }
        }
    }
}
