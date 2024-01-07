using System.Diagnostics;
using ADP.Algorithms.BinarySearch;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.BinarySearch;

public class BinarySearchTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    public BinarySearchTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Theory]
    [MemberData(nameof(Data1))]
    [MemberData(nameof(Data2))]
    [MemberData(nameof(Data3))]
    [MemberData(nameof(Data4))]
    public void TestBinarySearch(List<int> input, int numberToFind)
    {
        // Arrange
        var stopwatch = new Stopwatch();
        
        // Act
        stopwatch.Start();
        var result = BinarySearchAlgorithm.BinarySearch(input, numberToFind);
        stopwatch.Stop();
        
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        
        // Assert
        result.ShouldBeEquivalentTo(numberToFind - 1);
    }
    
    public static IEnumerable<object[]> Data1(){
        yield return new object[] { Enumerable.Range(1, 10).ToList(), 1 };
    }
    
    public static IEnumerable<object[]> Data2(){
        yield return new object[] { Enumerable.Range(1, 100000).ToList(), 1 };
    }
    
    public static IEnumerable<object[]> Data3(){
        yield return new object[] { Enumerable.Range(1, 10000000).ToList(), 1 };
    }
    
    public static IEnumerable<object[]> Data4(){
        yield return new object[] { Enumerable.Range(1, 2000000000).ToList(), 1 };
    }
}