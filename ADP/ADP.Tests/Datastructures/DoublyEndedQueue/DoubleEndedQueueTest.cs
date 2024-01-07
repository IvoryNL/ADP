using ADP.Datastructures.DoublyEndedQueue;
using Shouldly;

namespace ADP.Tests.DoublyEndedQueue;

public class DoubleEndedQueueTest
{
    private readonly DoubleEndedQueue<int> _doubleEndedQueue = new();

    public DoubleEndedQueueTest()
    {
        foreach (var item in DataSetSorterenHelper.LijstOplopend10000)
        {
            _doubleEndedQueue.InsertLeft(item);
        }
    }
    
    // InsertLeft is O(1) constant.
    // There is no use in testing performance due to it always adding the new node to the head node
    // The head node always holds the most left item
    [Fact]
    public void TestInsertLeft()
    {
        // Arrange
        var valueToInsert = 100;

        // Act
        _doubleEndedQueue.InsertLeft(valueToInsert);

        // Assert
        _doubleEndedQueue.PeekLeft().ShouldBeEquivalentTo(valueToInsert);
    }
    
    // DeleteLeft is O(1) constant.
    // There is no use in testing performance due to it always returning the head node
    // The head node always holds the most left item
    [Fact]
    public void TestDeleteLeft()
    {
        // Arrange
        var valueThatWillBeDeleted = _doubleEndedQueue.PeekLeft();

        // Act
        var result = _doubleEndedQueue.DeleteLeft();

        // Assert
        result.ShouldBe(valueThatWillBeDeleted);
        _doubleEndedQueue.PeekLeft().ShouldNotBe(valueThatWillBeDeleted);
    }
    
    // InsertRight is O(1) constant.
    // There is no use in testing performance due to it always adding the new node to the tail node
    // The tail node always holds the most right item
    [Fact]
    public void TestInsertRight()
    {
        // Arrange
        var valueToInsert = 100;

        // Act
        _doubleEndedQueue.InsertRight(valueToInsert);

        // Assert
        _doubleEndedQueue.PeekRight().ShouldBeEquivalentTo(valueToInsert);
    }
    
    // DeleteRight is O(1) constant.
    // There is no use in testing performance due to it always returning the tail node
    // The tail node always holds the most right item
    [Fact]
    public void TestDeleteRight()
    {
        // Arrange
        var valueThatWillBeDeleted = _doubleEndedQueue.PeekRight();

        // Act
        var result = _doubleEndedQueue.DeleteRight();

        // Assert
        result.ShouldBe(valueThatWillBeDeleted);
        _doubleEndedQueue.PeekRight().ShouldNotBe(valueThatWillBeDeleted);
    }
}