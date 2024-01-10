using ADP.Datastructures.HashTable;
using Xunit.Abstractions;

namespace ADP.Tests.Datastructures.HashTable;

public class HashTableTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    public HashTableTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [MemberData(nameof(DataString))]
    public void TestInsertString(string[][] input)
    {
        // Arrange
        var hashTable = new HashTable<string, string>();
        
        // Act
        foreach (var item in input)
        {
            hashTable.Insert(item[0], item[1]);
        }

        // Assert
        
    }

    [Theory]
    [MemberData(nameof(DataRandom))]
    public void TestInsertPerformance(int[] input)
    {
        // Arrange
        var hashTable = new HashTable<int, int>();

        // Act
        foreach (var item in input)
        {
            hashTable.Insert(item, item);
        }

        // Assert

    }

    private HashTable<int, int> GenerateHashTable(int[] data)
    {
        var doublyLinkedList = new HashTable<int, int>();
        
        foreach (var item in data)
        {
            doublyLinkedList.Insert(item, item);
        }

        return doublyLinkedList;
    }
    
    private HashTable<string, string> GenerateHashTable(string[][] data)
    {
        var doublyLinkedList = new HashTable<string, string>();
        
        foreach (var item in data)
        {
            doublyLinkedList.Insert(item[0], item[1]);
        }

        return doublyLinkedList;
    }
    
    public static IEnumerable<object[]> DataRandom(){
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest1.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest2.ToArray() };
    }
    
    public static IEnumerable<object[]> DataString(){
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest3.ToArray() };
    }
    
    public static IEnumerable<object[]> DataUnsorted(){
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToArray() };
    }
}