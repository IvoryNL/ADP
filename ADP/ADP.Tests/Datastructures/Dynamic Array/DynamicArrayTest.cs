using System.Diagnostics;
using ADP.Datastructures.DynamicArray;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.Dynamic_Array;

public class DynamicArrayTest
{
    private readonly DynamicArray<int> _dynamicArray;
    private readonly ITestOutputHelper _testOutputHelper;
        
    public DynamicArrayTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        
        _dynamicArray = GenerateDynamicArray(DataSetSorterenHelper.LijstOplopend10000);
    }

    // Add is O(1) most of the time
    // The factor that affects the time complexity is the resize array grow or shrink array
    // These operations are costly due to allocation a new array in memory and copying all the items to the new array
    // A grow factor of 2 and a shrink factor of 4 is chosen for the best balance
    [Fact]
    public void TestAdd()
    {
        // Arrange
        var valueToAdd = 30;
        var indexToAddValue = 9999;
            
        // Act 
        _dynamicArray.Add(valueToAdd);

        // Assert
        var result = _dynamicArray.GetValue(indexToAddValue);
        result.ShouldBeEquivalentTo(valueToAdd);
    }

    [Fact]
    public void TestGetValue()
    {
        // Arrange
        var indexToMatch = 500;
            
        // Act
        var result = _dynamicArray.GetValue(indexToMatch);
            
        // Assert
        result.ShouldBeEquivalentTo(DataSetSorterenHelper.LijstOplopend10000[indexToMatch]);
    }

    // SetValue is O(1) most of the time
    // The factor that affects the time complexity is the resize array grow or shrink array
    // These operations are costly due to allocation a new array in memory and copying all the items to the new array
    // A grow factor of 2 and a shrink factor of 4 is chosen for the best balance
    [Fact]
    public void TestSetValue()
    {
        // Arrange
        var indexToAddValue = 600;
        var valueToAdd = 320;
            
        // Act 
        _dynamicArray.SetValue(indexToAddValue, valueToAdd);

        // Assert
        var result = _dynamicArray.GetValue(indexToAddValue);
        result.ShouldBeEquivalentTo(valueToAdd);
    }
    
    [Fact]
    public void TestRemove()
    {
        // Arrange
        var valueToRemove = 400;
        var indexOfValueToRemove = _dynamicArray.IndexOf(valueToRemove);

        // Act
        _dynamicArray.Remove(valueToRemove);            

        // Assert
        var result = _dynamicArray.GetValue(indexOfValueToRemove);
        result.ShouldNotBe(valueToRemove);
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestRemovePerformance(List<int> input)
    {
        // Arrange
        var dynamicArray = GenerateDynamicArray(input.ToArray());
        var valueToFind = input[^1];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Remove performance");
        Console.WriteLine($"Remove performance");
        stopwatch.Start();
        dynamicArray.Remove(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        
        // Assert
    }
    
    // RemoveAt is O(1) most of the time
    // The factor that affects the time complexity is the resize array grow or shrink array
    // These operations are costly due to allocation a new array in memory and copying all the items to the new array
    // A grow factor of 2 and a shrink factor of 4 is chosen for the best balance
    [Fact]
    public void TestRemoveAt()
    {
        // Arrange
        var valueToRemove = 400;
        var indexOfValueToRemove = _dynamicArray.IndexOf(valueToRemove);

        // Act
        _dynamicArray.RemoveAt(indexOfValueToRemove);            

        // Assert
        var result = _dynamicArray.GetValue(indexOfValueToRemove);
        result.ShouldNotBe(valueToRemove);
    }

    [Fact]
    public void TestContains_ShouldBeTrue()
    {
        // Arrange
        var valueToCheck = 400;

        // Act
        var result = _dynamicArray.Contains(valueToCheck);            

        // Assert
        result.ShouldBeTrue();
    }
        
    [Fact]
    public void TestContains_ShouldBeFalse()
    {
        // Arrange
        var valueToCheck = -1;

        // Act
        var result = _dynamicArray.Contains(valueToCheck);            

        // Assert
        result.ShouldBeFalse();
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestContainsPerformance(List<int> input)
    {
        // Arrange
        var dynamicArray = GenerateDynamicArray(input.ToArray());
        var valueToFind = input[0];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Contains performance");
        Console.WriteLine($"Contains performance");
        stopwatch.Start();
        var result = dynamicArray.Contains(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        
        // Assert
    }
    
    [Fact]
    public void TestIndexOf()
    {
        // Arrange
        var valueToCheck = 400;
        var indexOfValueToCheck = 399;

        // Act
        var result = _dynamicArray.IndexOf(valueToCheck);            

        // Assert
        result.ShouldBeEquivalentTo(indexOfValueToCheck);
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestIndexOfPerformance(List<int> input)
    {
        // Arrange
        var dynamicArray = GenerateDynamicArray(input.ToArray());
        var valueToFind = input[0];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"IndexOf performance");
        Console.WriteLine($"IndexOf performance");
        stopwatch.Start();
        var result = dynamicArray.IndexOf(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        
        // Assert
    }
    
    private static DynamicArray<int> GenerateDynamicArray(int[] data)
    {
        var dynamicArray = new DynamicArray<int>();
        
        foreach (var item in data)
        {
            dynamicArray.Add(item);
        }

        return dynamicArray;
    }
    
    public static IEnumerable<object[]> Data(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToList() };
    }
}