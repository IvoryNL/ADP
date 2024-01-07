using System.Diagnostics;
using ADP.Algorithms.BinarySearch;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Algorithms.BinarySearch;

public class BinarySearchTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private const int COUNT_SMALL_ORDERED_LIST = 1000;
    private const int COUNT_MEDIUM_ORDERED_LIST = 10000;
    private const int COUNT_LARGE_ORDERED_LIST = 100000;
    
    private static List<int> smallOrderedList = new();
    private static List<int> mediumOrderedList = new();
    private static List<int> largeOrderedList = new();

    public BinarySearchTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        for (int i = 1; i <= COUNT_SMALL_ORDERED_LIST; i++)
        {
            smallOrderedList.Add(i);
        }
        
        for (int i = 1; i <= COUNT_MEDIUM_ORDERED_LIST; i++)
        {
            mediumOrderedList.Add(i);
        }
        
        for (int i = 1; i <= COUNT_LARGE_ORDERED_LIST; i++)
        {
            largeOrderedList.Add(i);
        }
    }
    
    [Theory]
    [MemberData(nameof(Data))]
    public void TestBinarySearch(List<int> input, int numberToFind)
    {
        var stopwatch = new Stopwatch();
        _testOutputHelper.WriteLine("Stopwatch start");
        stopwatch.Start();
        var result = BinarySearchAlgorithm.BinarySearch(input, numberToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine("Stopwatch stop");
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        
        result.ShouldBeEquivalentTo(numberToFind);
    }
    
    public static IEnumerable<object[]> Data(){
        yield return new object[] { smallOrderedList, 990 };
        yield return new object[] { mediumOrderedList, 9990 };
        yield return new object[] { largeOrderedList, 99990 };
    }
}