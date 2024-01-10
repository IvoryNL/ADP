using System.Diagnostics;
using ADP.Datastructures.PriorityQueue;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Datastructures.PriorityQueue;

public class PriorityQueueTest
{
    private readonly PriorityQueue<int> _priorityQueue;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public PriorityQueueTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        _priorityQueue = GeneratePriorityQueue(DataSetSorterenHelper.LijstWillekeurig3);
    }

    [Fact]
    public void TestEnqueue()
    {
        // Arrange
        var numberToEnqueue = 0;

        // Act
        _priorityQueue.Enqueue(numberToEnqueue);

        // Assert
        _priorityQueue.Peek().ShouldBeEquivalentTo(numberToEnqueue);
    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // It enqueues one at a time. The bubble up skips the children and focuses on the parent.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestEnqueuePerformance(List<int> input)
    {
        // Arrange
        var priorityQueue = GeneratePriorityQueue(input.ToArray());
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Enqueue performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE ENQUEUE PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var numberToEnqueue in input)
        {
            priorityQueue.Enqueue(numberToEnqueue);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    [Fact]
    public void TestDequeue()
    {
        // Arrange
        var expectedNumberToDequeue = 1;

        // Act
        var result = _priorityQueue.Dequeue();

        // Assert
        result.ShouldBeEquivalentTo(expectedNumberToDequeue);
    }
    
    // This test show that the time complexity is O(log N) logarithmic.
    // It dequeues one at a time. The bubble down skips the children and focuses on the parent.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestDequeuePerformance(List<int> input)
    {
        // Arrange
        var priorityQueue = GeneratePriorityQueue(input.ToArray());
        var stopwatch = new Stopwatch();
        var counter = input.Count;

        // Act
        _testOutputHelper.WriteLine($"Dequeue performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE DEQUEUE PERFORMANCE TEST");
        stopwatch.Start();
        while (counter-- > 0)
        {
            var result = priorityQueue.Dequeue();
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    // Peek is O(1) constant.
    // There is no use in testing performance due to it always returning the first element
    [Fact]
    public void TestPeek()
    {
        // Arrange
        var expectedNumber = 1;

        // Act
        var result = _priorityQueue.Peek();

        // Assert
        result.ShouldBeEquivalentTo(expectedNumber);
    }
    
    private PriorityQueue<int> GeneratePriorityQueue(int[] data)
    {
        var priorityQueue = new PriorityQueue<int>();
        
        foreach (var item in data)
        {
            priorityQueue.Enqueue(item);
        }

        return priorityQueue;
    }
    
    public static IEnumerable<object[]> Data(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToList() };
    }
}