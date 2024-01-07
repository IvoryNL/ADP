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