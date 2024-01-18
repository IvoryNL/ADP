using Xunit.Abstractions;
using System.Diagnostics;
using ADP.Datastructures.Graph;
using ADP.Datastructures.Graph.Helpers;
using ADP.Algorithms;

namespace ADP.Tests.Datastructures.Graph;

public class GraphTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public GraphTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    // The time complexity is O(1)
    [Theory]
    [MemberData(nameof(AdjacencyListUnweighted))]
    public void TestInsertVertexUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListUnweightedInt(input);

        var valueToInsert = input.Length;
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert vertex unweighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH INSERT VERTEX UNWEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        graph.AddVertex(valueToInsert);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time conplexity O(V + E)
    [Theory]
    [MemberData(nameof(AdjacencyListUnweighted))]
    public void TestRemoveVertexUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListUnweightedInt(input);

        var stopwatch = new Stopwatch();

        var edgesToRemove = new int[] { 4, 5, 6 };

        // Act
        _testOutputHelper.WriteLine($"Remove vertex unweighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH REMOVE VERTEX UNWEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var vertexData in edgesToRemove)
        {
            graph.RemoveVertex(vertexData);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time complexity is O(1)
    [Theory]
    [MemberData(nameof(AdjacencyListUnweighted))]
    public void TestInsertEdgeUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListUnweightedInt(input);

        var valueToInsert = input.Length;
        graph.AddVertex(valueToInsert);
        var edgeToInsert = 3;
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert edge unweighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH INSERT EDGE UNWEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        graph.AddEdge(valueToInsert, edgeToInsert);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time conplexity O(V + E)
    [Theory]
    [MemberData(nameof(AdjacencyListUnweighted))]
    public void TestRemoveEdgeUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListUnweightedInt(input);

        var stopwatch = new Stopwatch();

        var edgesToRemove = new int[] { 4, 5, 6 };

        // Act
        _testOutputHelper.WriteLine($"Remove edge unweighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH REMOVE EDGE UNWEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < input.Length; i++)
        {
            foreach (var edgeData in edgesToRemove)
            {
                var vertexData = i;
                graph.RemoveEdge(vertexData, edgeData);
            }
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time complexity is O(1)
    [Theory]
    [MemberData(nameof(AdjacencyListWeighted))]
    public void TestInsertVertexWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListWeightedInt(input);

        var valueToInsert = input.Length;
        var stopwatch = new Stopwatch();


        // Act
        _testOutputHelper.WriteLine($"Insert vertex weighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH INSERT VERTEX WEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        graph.AddVertex(valueToInsert);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time conplexity O(V + E)
    [Theory]
    [MemberData(nameof(AdjacencyListWeighted))]
    public void TestRemoveVertexWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListWeightedInt(input);

        var stopwatch = new Stopwatch();

        var verticesToRemove = new int[] { 0, 2, 3 };

        // Act
        _testOutputHelper.WriteLine($"Remove vertex unweighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH REMOVE VERTEX UNWEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var vertexData in verticesToRemove)
        {
            graph.RemoveVertex(vertexData);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // The time complexity is O(1)
    [Theory]
    [MemberData(nameof(AdjacencyListWeighted))]
    public void TestInsertEdgeWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListWeightedInt(input);

        var valueToInsert = input.Length;
        graph.AddVertex(valueToInsert);
        var edgeToInsert = new int[] { 3, 50 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert edge weighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH INSERT EDGE WEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        graph.AddEdge(valueToInsert, edgeToInsert[0], edgeToInsert[1]);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    // The time conplexity O(V + E)
    [Theory]
    [MemberData(nameof(AdjacencyListWeighted))]
    public void TestRemoveEdgeWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyListWeightedInt(input);

        var stopwatch = new Stopwatch();

        var edgesToRemove = new int[] { 0, 2, 3 };

        // Act
        _testOutputHelper.WriteLine($"Remove edge weighted performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("GRAPH REMOVE EDGE WEIGHTED PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < input.Length; i++)
        {
            foreach (var edgeData in edgesToRemove)
            {
                var vertexData = i;
                graph.RemoveEdge(vertexData, edgeData);
            }
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    [Fact]
    public void TestRemoveVertexAdjacencyMatrixWeighted()
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyMatrixWeightedInt(DataSetGraphHelper.verbindingsmatrix_gewogen);

        var vertexToRemove = 3;

        // Act
        graph.RemoveVertex(vertexToRemove);

        // Assert

    }

    [Fact]
    public void TestRemoveVertexAdjacencyMatrixUnweighted()
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadAdjacencyMatrixWeightedInt(DataSetGraphHelper.verbindingsmatrix);

        var vertexToRemove = 3;

        // Act
        graph.RemoveVertex(vertexToRemove);

        // Assert

    }

    [Fact]
    public void TestRemoveVertexEdgeListUnweighted()
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadEdgeListUnweightedInt(DataSetGraphHelper.lijnlijst);

        var vertexToRemove = 3;

        // Act
        graph.RemoveVertex(vertexToRemove);

        // Assert

    }

    [Fact]
    public void TestRemoveVertexEdgeListWeighted()
    {
        // Arrange
        var graph = new GraphADP<int>();
        graph.ReadEdgeListUnweightedInt(DataSetGraphHelper.lijnlijst_gewogen);

        var vertexToRemove = 3;

        // Act
        graph.RemoveVertex(vertexToRemove);

        // Assert

    }

    public static IEnumerable<object[]> AdjacencyListUnweighted()
    {
        yield return new object[] { DataSetGraphHelper.verbindingslijst1 };
        yield return new object[] { DataSetGraphHelper.verbindingslijst2 };
        yield return new object[] { DataSetGraphHelper.verbindingslijst3 };
    }

    public static IEnumerable<object[]> AdjacencyListWeighted()
    {
        yield return new object[] { DataSetGraphHelper.verbindingslijst_gewogen1 };
        yield return new object[] { DataSetGraphHelper.verbindingslijst_gewogen2 };
        yield return new object[] { DataSetGraphHelper.verbindingslijst_gewogen3 };
    }
}
