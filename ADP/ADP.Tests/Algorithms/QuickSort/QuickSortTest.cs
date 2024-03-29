﻿using System.Diagnostics;
using ADP.Algorithms.QuickSort;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.QuickSort;

public class QuickSortTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public QuickSortTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    // This test show that the time complexity is O(N log N) linearithmic
    // the first N being the number of partitions and second N being the items in the collection.
    // It can be O(N) when the pivot is unbalanced
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestQuickSortUnsorted(int[] input)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        _testOutputHelper.WriteLine($"Quick Sort Unsorted Performance Test {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine($"QUICK SORT UNSORTED PERFORMANCE TEST {input.Length}");
        stopwatch.Start();
        QuickSortAlgorithm.QuickSort(input);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
    
    [Theory]
    [MemberData(nameof(DataDifferent))]
    public void TestQuickSortDifferentSets(int[] input)
    {
        // Arrange
        var expectedSortedInput = input.ToList();
        expectedSortedInput.Sort();
        
        // Act
        QuickSortAlgorithm.QuickSort(input);
        
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