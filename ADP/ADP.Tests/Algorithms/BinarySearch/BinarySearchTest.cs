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
    
    // This test show that the time complexity is O(log N) logarithmic
    // Even when the data grows X times the runtime does not due to divide and conquer
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
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
    
    public static IEnumerable<object[]> Data(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { Enumerable.Range(1, 10).ToList(), 1 };
        yield return new object[] { Enumerable.Range(1, 100000).ToList(), 1 };
        // yield return new object[] { Enumerable.Range(1, 10000000).ToList(), 1 };
        // yield return new object[] { Enumerable.Range(1, 2000000000).ToList(), 1 };
    }
}