using System.Diagnostics;
using ADP.Datastructures.DoublyLinkedList;
using Shouldly;
using Xunit.Abstractions;

namespace ADP.Tests.DoublyLinkedList;

public class DoublyLinkedListTest
{
    private readonly DoublyLinkedList<int> _doublyLinkedList;
    private readonly ITestOutputHelper _testOutputHelper;
    
    public DoublyLinkedListTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        _doublyLinkedList = GenerateDoublyLinkedList(DataSetSorterenHelper.LijstOplopend10000);
    }

    // Add is O(1) constant.
    // There is no use in testing performance due to it always adding the new node to the head node
    // The head node always holds the most left item
    [Fact]
    public void TestAdd()
    {
        // Arrange
        var valueToAdd = 30;
        var indexToAddValue = 0;
            
        // Act 
        _doublyLinkedList.Add(valueToAdd);

        // Assert
        var result = _doublyLinkedList.GetValue(indexToAddValue);
        result.ShouldBeEquivalentTo(valueToAdd);
    }

    [Fact]
    public void TestGetValue()
    {
        // Arrange
        var indexToMatch = 9998;
            
        // Act
        var result = _doublyLinkedList.GetValue(0);
            
        // Assert
        result.ShouldBeEquivalentTo(DataSetSorterenHelper.LijstOplopend10000[indexToMatch]);
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestGetValuePerformance(List<int> input)
    {
        // Arrange
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var valueToFind = input[^1];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"GetValue performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE GETVALUE PERFORMANCE TEST");
        stopwatch.Start();
        var result = doublyLinkedList.GetValue(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }

    [Fact]
    public void TestSetValue()
    {
        // Arrange
        var indexToAddValue = 100;
        var valueToAdd = 320;
            
        // Act 
        _doublyLinkedList.SetValue(indexToAddValue, valueToAdd);

        // Assert
        var result = _doublyLinkedList.GetValue(indexToAddValue);
        result.ShouldBeEquivalentTo(valueToAdd);
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestSetValuePerformance(List<int> input)
    {
        // Arrange
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var lastIndex = input.Count - 1;
        var valueToSet = 4;
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"SetValue performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE SETVALUE PERFORMANCE TEST");
        stopwatch.Start();
        doublyLinkedList.SetValue(lastIndex, valueToSet);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }

    [Fact]
    public void TestRemove()
    {
        // Arrange
        var valueToRemove = 9990;
        var indexOfValueToRemove = _doublyLinkedList.IndexOf(valueToRemove);

        // Act
        _doublyLinkedList.Remove(valueToRemove);            

        // Assert
        var result = _doublyLinkedList.GetValue(indexOfValueToRemove);
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
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var valueToRemove = input[0];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Remove performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE REMOVE PERFORMANCE TEST");
        stopwatch.Start();
        doublyLinkedList.Remove(valueToRemove);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }
        
    [Fact]
    public void TestRemoveAt()
    {
        // Arrange
        var valueToRemove = 9999;
        var indexOfValueToRemove = _doublyLinkedList.IndexOf(valueToRemove);

        // Act
        _doublyLinkedList.RemoveAt(indexOfValueToRemove);
        
        // Assert
        var result = _doublyLinkedList.GetValue(indexOfValueToRemove);
        result.ShouldNotBe(valueToRemove);
    }
    
    // This test show that the time complexity is O(N) linear
    // It has to visit one node at a time to find the value
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(Data))]
    public void TestRemoveAtPerformance(List<int> input)
    {
        // Arrange
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var lastIndex = input.Count - 1;
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"RemoveAt performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE REMOVEAT PERFORMANCE TEST");
        stopwatch.Start();
        doublyLinkedList.RemoveAt(lastIndex);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }

    [Fact]
    public void TestContains_ShouldBeTrue()
    {
        // Arrange
        var valueToCheck = 400;

        // Act
        var result = _doublyLinkedList.Contains(valueToCheck);            

        // Assert
        result.ShouldBeTrue();
    }
        
    [Fact]
    public void TestContains_ShouldBeFalse()
    {
        // Arrange
        var valueToCheck = -1;

        // Act
        var result = _doublyLinkedList.Contains(valueToCheck);            

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
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var valueToFind = input[0];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Contains performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE CONTAINS PERFORMANCE TEST");
        stopwatch.Start();
        var result = doublyLinkedList.Contains(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }

    [Fact]
    public void TestIndexOf()
    {
        // Arrange
        var valueToCheck = DataSetSorterenHelper.LijstOplopend10000[^1];
        var indexOfValueToCheck = 0;

        // Act
        var result = _doublyLinkedList.IndexOf(valueToCheck);            

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
        var doublyLinkedList = GenerateDoublyLinkedList(input.ToArray());
        var valueToFind = input[0];
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"IndexOf performance");
        Console.WriteLine("###############################");
        Console.WriteLine("DOUBLY ENDED QUEUE INDEXOF PERFORMANCE TEST");
        stopwatch.Start();
        var result = doublyLinkedList.IndexOf(valueToFind);
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");
        
        // Assert
    }

    private DoublyLinkedList<int> GenerateDoublyLinkedList(int[] data)
    {
        var doublyLinkedList = new DoublyLinkedList<int>();
        
        foreach (var item in data)
        {
            doublyLinkedList.Add(item);
        }

        return doublyLinkedList;
    }
    
    public static IEnumerable<object[]> Data(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToList() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToList() };
    }
}