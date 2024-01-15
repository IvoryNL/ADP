using Xunit.Abstractions;
using ADP.Algorithms.Graph;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADP.Tests.Datastructures.Graph;

public class GraphTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public GraphTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [MemberData(nameof(DataUnweighted))]
    public void TestInsertVertexUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = GenerateGraphUnweighted(input);
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

    [Theory]
    [MemberData(nameof(DataUnweighted))]
    public void TestRemoveVertexUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = GenerateGraphUnweighted(input);
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

    [Theory]
    [MemberData(nameof(DataUnweighted))]
    public void TestInsertEdgeUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = GenerateGraphUnweighted(input);
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

    [Theory]
    [MemberData(nameof(DataUnweighted))]
    public void TestRemoveEdgeUnweightedPerformance(int[][] input)
    {
        // Arrange
        var graph = GenerateGraphUnweighted(input);
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

    [Theory]
    [MemberData(nameof(DataWeighted))]
    public void TestInsertVertexWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = GenerateGraphWeighted(input);
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

    [Theory]
    [MemberData(nameof(DataWeighted))]
    public void TestRemoveVertexWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = GenerateGraphWeighted(input);
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

    [Theory]
    [MemberData(nameof(DataWeighted))]
    public void TestInsertEdgeWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = GenerateGraphWeighted(input);
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

    [Theory]
    [MemberData(nameof(DataWeighted))]
    public void TestRemoveEdgeWeightedPerformance(int[][][] input)
    {
        // Arrange
        var graph = GenerateGraphWeighted(input);
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

    private GraphADP<int> GenerateGraphUnweighted(int[][] data)
    {
        var graph = new GraphADP<int>();

        for (var i = 0; i < data.Length; i++)
        {
            var vertexData = i;
            graph.AddVertex(vertexData);
        }

        for (var i = 0; i < data.Length; i++)
        {
            for (var j = 0;  j < data[i].Length; j++)
            {
                var vertexData = i;
                var edgeData = data[i][j];
                graph.AddEdge(vertexData, edgeData);
            }
        }

        return graph;
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
    public static IEnumerable<object[]> DataUnweighted()
    {
        yield return new object[] { DataSetGraphHelper.lijstOngewogen1 };
        yield return new object[] { DataSetGraphHelper.lijstOngewogen2 };
        yield return new object[] { DataSetGraphHelper.lijstOngewogen3 };
    }

    public static IEnumerable<object[]> DataWeighted()
    {
        yield return new object[] { DataSetGraphHelper.LijstGewogen1 };
        yield return new object[] { DataSetGraphHelper.LijstGewogen2 };
        yield return new object[] { DataSetGraphHelper.LijstGewogen3 };
    }
}
