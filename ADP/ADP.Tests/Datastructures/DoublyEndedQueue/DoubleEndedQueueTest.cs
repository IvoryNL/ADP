using System.Diagnostics;
using ADP.Datastructures.DoublyEndedQueue;
using Xunit.Abstractions;

namespace ADP.Tests.DoublyEndedQueue;

public class DoubleEndedQueueTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DoubleEndedQueueTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // InsertLeft is O(1) constant.
    // There is no use in testing performance due to it always adding the new node to the head node
    // The head node always holds the most left item
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestInsertLeft(int[] input)
    {
        // Arrange
        var doubleEndedQueue = GenerateDoubleEndedQueue(input);
        var valuesToInsert = new int[] { 99, 60, 29 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert left performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLE ENDED QUEUE INSERT LEFT PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToInsert)
        {
            doubleEndedQueue.InsertLeft(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert
        
    }
    
    // DeleteLeft is O(1) constant.
    // There is no use in testing performance due to it always returning the head node
    // The head node always holds the most left item
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestDeleteLeft(int[] input)
    {
        // Arrange
        var doubleEndedQueue = GenerateDoubleEndedQueue(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Delete left performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLE ENDED QUEUE DELETE LEFT PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < 3; i++)
        {
            var result = doubleEndedQueue.DeleteLeft();
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert
        
    }
    
    // InsertRight is O(1) constant.
    // There is no use in testing performance due to it always adding the new node to the tail node
    // The tail node always holds the most right item
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestInsertRight(int[] input)
    {
        // Arrange
        var doubleEndedQueue = GenerateDoubleEndedQueue(input);
        var valuesToInsert = new int[] { 99, 60, 29 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert right performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLE ENDED QUEUE INSERT RIGHT PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToInsert)
        {
            doubleEndedQueue.InsertRight(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert
        
    }
    
    // DeleteRight is O(1) constant.
    // There is no use in testing performance due to it always returning the tail node
    // The tail node always holds the most right item
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestDeleteRight(int[] input)
    {
        // Arrange
        var doubleEndedQueue = GenerateDoubleEndedQueue(input);
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Delete right performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLE ENDED QUEUE DELETE RIGHT PERFORMANCE TEST");
        stopwatch.Start();
        for (var i = 0; i < 3; i++)
        {
            var result = doubleEndedQueue.DeleteRight();
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert
        
    }
    
    private DoubleEndedQueue<int> GenerateDoubleEndedQueue(int[] data)
    {
        var doublyEndedQueue = new DoubleEndedQueue<int>();

        foreach (var item in data)
        {
            doublyEndedQueue.InsertLeft(item);
        }

        return doublyEndedQueue;
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