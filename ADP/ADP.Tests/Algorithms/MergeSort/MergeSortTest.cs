using System.Diagnostics;
using ADP.Algorithms.MergeSort;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.MergeSort;

public class MergeSortTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public MergeSortTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(N log N) linearithmic
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
        MergeSortAlgorithm.ParallelMergeSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    [Theory]
    [MemberData(nameof(DataDifferent))]
    public void TestMergeSortDifferentSets(int[] input)
    {
        // Arrange
        var expectedSortedInput = input.ToList();
        expectedSortedInput.Sort();
        
        // Act
        MergeSortAlgorithm.ParallelMergeSort(input);
        
        // Assert
        input.ShouldBeEquivalentTo(expectedSortedInput.ToArray());
    }
    
    public static IEnumerable<object[]> DataDifferent(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstAflopend2.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstOplopend2.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstGesorteerdAflopend3.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstGesorteerdOplopend3.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstHerhaald1000.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstLeeg0.ToArray() };
    }

    public static IEnumerable<object[]> DataUnsorted(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig10000 };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100000 };
    }
}