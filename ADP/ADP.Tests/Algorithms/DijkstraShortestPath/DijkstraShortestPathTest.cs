using ADP.Algorithms;
using ADP.Datastructures.Graph;
using System.Diagnostics;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.DijkstraShortestPath
{
    public class DijkstraShortestPathTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DijkstraShortestPathTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        // The time complexity of the algorithm is O(V + E) * O(log V)
        // V for the Vertices and E for the edges of the Vertices
        // The O(log V) are the operations of the priority queue due to it using an heap
        [Theory]
        [MemberData(nameof(DataWeighted))]
        public void TestDijkstraShortestPathPerformance(int[][][] input, int startValue, int endValue)
        {
            // Arrange
            var graph = GenerateGraphWeighted(input);
            var stopwatch = new Stopwatch();

            // Act
            _testOutputHelper.WriteLine($"Dijkstra's shortest path performance {input.Length}");
            Console.WriteLine("###############################");
            Console.WriteLine("DIJKSTRA'S SHORTEST PATH PERFORMANCE TEST");
            stopwatch.Start();
            var result = DijkstraShortestPathAlgorithm<int>.DijkstraShortestPath(graph, startValue, endValue);
            stopwatch.Stop();
            _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
            Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
            Console.WriteLine("###############################");

            // Assert

        }

        // The time complexity of the algorithm is O(V + E) * O(log V)
        // V for the Vertices and E for the edges of the Vertices
        // The O(log V) are the operations of the priority queue due to it using an heap
        [Theory]
        [MemberData(nameof(DataStringWeighted))]
        public void TestDijkstraShortestPathGraphPerformance(GraphADP<string> graph, string startValue, string endValue, int lijst)
        {
            // Arrange
            var stopwatch = new Stopwatch();

            // Act
            _testOutputHelper.WriteLine($"Dijkstra's shortest path graph performance {lijst}");
            Console.WriteLine("###############################");
            Console.WriteLine("DIJKSTRA'S SHORTEST GRAPH PATH PERFORMANCE TEST");
            stopwatch.Start();
            var result = DijkstraShortestPathAlgorithm<string>.DijkstraShortestPath(graph, startValue, endValue);
            stopwatch.Stop();
            _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
            Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
            Console.WriteLine("###############################");

            // Assert
            var resultString = string.Empty;
            foreach ( var item in result ) 
            {
                resultString = resultString + $"{item.Value} ";
            }

            _testOutputHelper.WriteLine(resultString);
        }

        private GraphADP<int> GenerateGraphWeighted(int[][][] data)
        {
            var graph = new GraphADP<int>();

            for (var i = 0; i < data.Length; i++)
            {
                var vertexData = i;
                graph.AddVertex(vertexData);
            }

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    var vertexData = i;
                    var edgeData = data[i][j];
                    graph.AddEdge(vertexData, edgeData[0], edgeData[1]);
                }
            }

            return graph;
        }

        public static IEnumerable<object[]> DataStringWeighted()
        {
            yield return new object[] { DataSetGraphHelper.Dijkstra1, "S", "E", 1 };
            yield return new object[] { DataSetGraphHelper.Dijkstra2, "S", "E", 2};
            yield return new object[] { DataSetGraphHelper.Dijkstra3, "S", "E", 3 };
        }

        public static IEnumerable<object[]> DataWeighted()
        {
            yield return new object[] { DataSetGraphHelper.LijstGewogen1, 0, 3};
            yield return new object[] { DataSetGraphHelper.LijstGewogen2, 0, 6 };
            yield return new object[] { DataSetGraphHelper.LijstGewogen3, 0 ,10 };
        }
    }
}
