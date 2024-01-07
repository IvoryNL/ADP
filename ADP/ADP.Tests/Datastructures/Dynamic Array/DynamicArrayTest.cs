using ADP.Datastructures.DynamicArray;
using Shouldly;

namespace ADP.Tests.Dynamic_Array;

public class DynamicArrayTest
{
    private readonly DynamicArray<int> _dynamicArray = new();
        
    public DynamicArrayTest()
    {
        foreach (var item in DataSetSorterenHelper.LijstOplopend10000)
        {
            _dynamicArray.Add(item);
        }
    }

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
}