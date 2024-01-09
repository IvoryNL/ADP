using System.Diagnostics;
using ADP.Algorithms.InsertionSort;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.InsertionSort;

public class InsertionSortTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public InsertionSortTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(N ^ 2) quadratic
    // When the array is unsorted it will visit each item and compares it in O(1)
    // constant time with the item in front of it until the one in front is smaller
    // therefore continue to visit each that is bigger.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestInsertionSortUnsorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Insertion Sort Unsorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"INSERTION SORT UNSORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        InsertionSortAlgorithm.InsertionSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    // This test show that the time complexity is O(N) linear
    // When the array is sorted it will visit each item and compares it in O(1)
    // constant time with the item in front of it which is already smaller and
    // therefore continue to the next item in the input.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataSorted))]
    public void TestInsertionSortSorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Insertion Sort Sorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"INSERTION SORT SORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        InsertionSortAlgorithm.InsertionSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    [Theory]
    [MemberData(nameof(DataDifferent))]
    public void TestInsertionSortDifferentSets(int[] input)
    {
        // Arrange
        var expectedSortedInput = input.ToList();
        expectedSortedInput.Sort();
        
        // Act
        InsertionSortAlgorithm.InsertionSort(input);
        
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
    
    public static IEnumerable<object[]> DataSorted(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { Enumerable.Range(1, 10).ToArray() };
        yield return new object[] { Enumerable.Range(1, 100).ToArray() };
        yield return new object[] { Enumerable.Range(1, 10000).ToArray() };
        yield return new object[] { Enumerable.Range(1, 1000000).ToArray() };
    }
}