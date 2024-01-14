using ADP.Algorithms.Graph;

namespace ADP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a small graph with 3 vertices
            var graph = new GraphADP<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C");
            graph.AddEdge("B", "C");

            // Perform breadth-first search starting from vertex "A"
            graph.BreadthFirstSearch("A");
        }
    }
}