using ADP.Datastructures.Graph;

namespace ADP.Algorithms
{
    public static class DijkstraShortestPathAlgorithm<T>
    {
        public static List<Vertex<T>> DijkstraShortestPath(GraphADP<T> graph, T startVertexValue, T endVertexValue)
        {
            if (!graph.AdjacencyList.ContainsKey(startVertexValue))
            {
                throw new KeyNotFoundException("Start vertex not found");
            }

            if (!graph.AdjacencyList.ContainsKey(endVertexValue))
            {
                throw new KeyNotFoundException("End vertex not found");
            }

            var priorityQueue = new PriorityQueue<Vertex<T>, int>();
            var visitedVertices = new HashSet<T>();

            var startVertex = graph.AdjacencyList[startVertexValue];
            startVertex.Distance = 0;
            priorityQueue.Enqueue(startVertex, startVertex.Distance);

            Vertex<T> currentVertex = null;

            while (priorityQueue.Count > 0 )
            {
                currentVertex = priorityQueue.Dequeue();
                visitedVertices.Add(currentVertex.Value);

                if (currentVertex != null && currentVertex.Value.Equals(endVertexValue))
                {
                    break;
                }

                foreach (var edge in currentVertex.Edges)
                {
                    var destinationVertex = edge.DestinationVertext;
                    if (!visitedVertices.Contains(destinationVertex.Value))
                    {
                        var distanceFromCurrentVertex = edge.Weight >= 0 ? currentVertex.Distance + edge.Weight : currentVertex.Distance + 1;

                        if (destinationVertex.Distance > distanceFromCurrentVertex)
                        {
                            destinationVertex.Distance = distanceFromCurrentVertex;
                            destinationVertex.PreviousVertex = currentVertex;
                        }

                        priorityQueue.Enqueue(destinationVertex, destinationVertex.Distance);

                    }
                }
            }

            var result = new List<Vertex<T>>();
            currentVertex = graph.AdjacencyList[endVertexValue];
            result.Add(currentVertex);

            while (currentVertex.PreviousVertex != null)
            {
                result.Add(currentVertex.PreviousVertex);
                currentVertex = currentVertex.PreviousVertex;
            }

            result.Reverse();
            return result;
        }
    }
}
