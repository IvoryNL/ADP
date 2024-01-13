using System.Diagnostics;
using Xunit.Abstractions;
using ADPStack = ADP.Datastructures.Stack;

namespace ADP.Tests.Stack;

public class StackTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public StackTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    // Push is O(1) constant.
    // There is no use in testing performance due to it always adding to the head
    // The head node always holds the first item
    // Last in first out
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestPush(int[] input)
    {
        // Arrange
        var stack = GenerateStack(input);
        var valuesToInsert = new int[] { 99, 60, 29 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Push performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("STACK PUSH PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToInsert)
        {
            stack.Push(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // Pop is O(1) constant.
    // There is no use in testing performance due to it always adding to the head
    // The head node always holds the first item
    // Last in first out
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestPop(int[] input)
    {
        // Arrange
        var stack = GenerateStack(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Pop performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("STACK POP PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < 3; i++)
        {
            var result = stack.Pop();
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // Top is O(1) constant.
    // There is no use in testing performance due to it always adding to the head
    // The head node always holds the first item
    // Last in first out
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestTop(int[] input)
    {
        // Arrange
        var stack = GenerateStack(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Top performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("STACK TOP PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < 3; i++)
        {
            var result = stack.Top();
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }
    
    private ADPStack.Stack<int> GenerateStack(int[] data)
    {
        var stack = new ADPStack.Stack<int>();

        foreach (var item in data)
        {
            stack.Push(item);
        }

        return stack;
    }

    public static IEnumerable<object[]> DataUnsorted()
    {
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig10000.ToArray() };
    }
}