using ADP.Datastructures.DoublyLinkedList;
using Shouldly;

namespace ADP.Tests.DoublyLinkedList;

public class DoublyLinkedListTest
{
    private readonly DoublyLinkedList<int> _doublyLinkedList = new();
        
    public DoublyLinkedListTest()
    {
        foreach (var item in DataSetSorterenHelper.LijstOplopend10000)
        {
            _doublyLinkedList.Add(item);
        }
    }

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


    [Fact]
    public void TestIndexOf()
    {
        // Arrange
        var valueToCheck = 9999;
        var indexOfValueToCheck = 0;

        // Act
        var result = _doublyLinkedList.IndexOf(valueToCheck);            

        // Assert
        result.ShouldBeEquivalentTo(indexOfValueToCheck);
    }
}