using System.Diagnostics;
using ADP.Algorithms.MergeSort;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.MergeSort;

public class MergeSortTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public MergeSortTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(log N) logarithmic
    // Even when the data grows X times the runtime does not due to divide and conquer
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestMergeSortUnsorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Merge Sort Unsorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"MERGE SORT UNSORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        MergeSortAlgorithm.MergeSort(input);
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
}