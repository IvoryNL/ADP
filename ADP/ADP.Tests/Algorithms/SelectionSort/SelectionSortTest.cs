using System.Diagnostics;
using ADP.Algorithms.SelectionSort;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.SelectionSort;

public class SelectionSortTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public SelectionSortTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(N ^ 2) quadratic
    // The algorithm will iterate through the collection to find the smallest for each item in the first iteration
    // It does not matter whether the collection is sorted or unsorted
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestSelectionSortUnsorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Selection Sort Unsorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"SELECTION SORT UNSORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        SelectionSortAlgorithm.SelectionSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    // This test show that the time complexity is O(N ^ 2) quadratic
    // The algorithm will iterate through the collection to find the smallest for each item in the first iteration
    // It does not matter whether the collection is sorted or unsorted
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataSorted))]
    public void TestSelectionSortSorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Selection Sort Sorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"SELECTION SORT SORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        SelectionSortAlgorithm.SelectionSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    public static IEnumerable<object[]> DataUnsorted(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig10000 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100000 };
    }
    
    public static IEnumerable<object[]> DataSorted(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { Enumerable.Range(1, 10).ToArray() };
        yield return new object[] { Enumerable.Range(1, 100).ToArray() };
        yield return new object[] { Enumerable.Range(1, 10000).ToArray() };
        yield return new object[] { Enumerable.Range(1, 100000).ToArray() };
    }
}