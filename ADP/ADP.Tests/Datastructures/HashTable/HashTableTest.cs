using ADP.Datastructures.HashTable;
using System.Diagnostics;
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
    public void TestInsertInt(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);

        // Act
        foreach (var item in input)
        {
            hashTable.Insert(item, item);
        }

        // Assert

    }

    // This test show that the time complexity is O(1) constant.
    // The two factors that can have an affect is resizing the array and when there are more
    // than items on the same index which will cause it to search linear in the bucket.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestInsertIntPerformance(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);
        var valuesToInsert = new int[] { 99, 60, 29 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Insert performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("HASH TABLE INSERT PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToInsert)
        {
            hashTable.Insert(item, item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestDeleteInt(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);
        var halfInput = input.Length / 2;

        // Act
        for (var i = 0; i < halfInput; i++)
        {
            hashTable.Delete(input[i]);
        }

        // Assert

    }

    // This test show that the time complexity is O(1) constant.
    // The two factors that can have an affect is resizing the array and when there are more
    // than items on the same index which will cause it to search linear in the bucket.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestDeleteIntPerformance(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);
        var valuesToDelete = new int[] { 1, 2, 3 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Delete performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("HASH TABLE DELETE PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToDelete)
        {
            hashTable.Delete(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // This test show that the time complexity is O(1) constant.
    // The two factors that can have an affect is resizing the array and when there are more
    // than items on the same index which will cause it to search linear in the bucket.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestUpdateIntPerformance(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);
        var valuesToDelete = new int[][] { new int[] { 1, 71 }, new int[] { 2, 61 }, new int[] { 3, 39 } };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Update performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("HASH TABLE UPDATE PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToDelete)
        {
            hashTable.Update(item[0], item[1]);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

        // Assert

    }

    // This test show that the time complexity is O(1) constant.
    // The two factors that can have an affect is resizing the array and when there are more
    // than items on the same index which will cause it to search linear in the bucket.
    // Ignore the first console output due to startup time
    [Theory]
    [MemberData(nameof(DataUnsorted))]
    public void TestGetIntPerformance(int[] input)
    {
        // Arrange
        var hashTable = GenerateHashTable(input);
        var valuesToDelete = new int[] { 1, 2, 3 };
        var stopwatch = new Stopwatch();

        // Act
        _testOutputHelper.WriteLine($"Get performance {input.Length}");
        Console.WriteLine("###############################");
        Console.WriteLine("HASH TABLE GET PERFORMANCE TEST");
        stopwatch.Start();
        foreach (var item in valuesToDelete)
        {
            var result = hashTable.Get(item);
        }
        stopwatch.Stop();
        _testOutputHelper.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine($"Elapsed time {stopwatch.Elapsed}");
        Console.WriteLine("###############################");

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

    public static IEnumerable<object[]> DataRandom()
    {
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest1.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest2.ToArray() };
    }

    public static IEnumerable<object[]> DataString()
    {
        yield return new object[] { DataSetSorterenHelper.LijstHashingTest3.ToArray() };
    }

    public static IEnumerable<object[]> DataUnsorted()
    {
        // Used for startup due to the first time being inaccurate
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig3.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig100.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig1000.ToArray() };
        yield return new object[] { DataSetSorterenHelper.LijstWillekeurig10000.ToArray() };
    }
}