using System.Diagnostics;
using ADP.Datastructures.AVL_Tree;
using Xunit.Abstractions;

namespace ADP.Tests.Datastructures.AvlTree;

public class AvlTreeTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AvlTreeTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // As long as the tree is balanced the only thing thing that can affect the runtime
    // is the rotation needed to balance the tree.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestFind(int[] input)
    {
        // Arrange
        var avlTree = GenerateAvlTree(input);
        var valueToFind = 3;
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Find performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("AVL TREE FIND PERFORMANCE TEST");
        stopwatch.Start();
        var result = avlTree.Find(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // As long as the tree is balanced the only thing thing that can affect the runtime
    // is the rotation needed to balance the tree.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestFindMin(int[] input)
    {
        // Arrange
        var avlTree = GenerateAvlTree(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Find min performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("AVL TREE FIND MIN PERFORMANCE TEST");
        stopwatch.Start();
        var result = avlTree.FindMin();
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // As long as the tree is balanced the only thing thing that can affect the runtime
    // is the rotation needed to balance the tree.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestFindMax(int[] input)
    {
        // Arrange
        var avlTree = GenerateAvlTree(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Find max performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("AVL TREE FIND MAX PERFORMANCE TEST");
        stopwatch.Start();
        var result = avlTree.FindMax();
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // As long as the tree is balanced the only thing thing that can affect the runtime
    // is the rotation needed to balance the tree.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestInsert(int[] input)
    {
        // Arrange
        var avlTree = GenerateAvlTree(input);
        var valuesToInsert = new int[] { 99, 60, 29 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("AVL TREE INSERT PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToInsert)
        {
            avlTree.Insert(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // As long as the tree is balanced the only thing thing that can affect the runtime
    // is the rotation needed to balance the tree.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestRemove(int[] input)
    {
        // Arrange
        var avlTree = GenerateAvlTree(input);
        var valuesToRemove = new int[] { 1, 2, 3 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Remove performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("AVL TREE INSERT PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToRemove)
        {
            avlTree.Remove(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    private AVLTree<int> GenerateAvlTree(int[] data)
    {
        var avlTree = new AVLTree<int>();

        foreach (var item in data)
        {
            avlTree.Insert(item);
        }

        return avlTree;
    }

    public static IEnumerable<object[]> DataUnsorted()
    {
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig5.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig10000.ToArray() };
    }
}