using Shouldly;

namespace ADP.Tests.Stack;

public class StackTest
{
    private readonly CustomStack.Stack<int> _stack = new();

    public StackTest()
    {
        foreach (var item in DataSetSorterenHelper.LijstOplopend10000)
        {
            _stack.Push(item);
        }
    }

    [Fact]
    public void TestPush()
    {
        // Arrange
        var valueToPush = 30;

        // Act
        _stack.Push(valueToPush);

        // Assert
        var result = _stack.Top();
        
        result.ShouldBeEquivalentTo(valueToPush);
    }

    [Fact]
    public void TestPop()
    {
        // Arrange
        var topValue = _stack.Top();

        // Act
        var result = _stack.Pop();
 
        // Assert
        result.ShouldBeEquivalentTo(topValue);
        _stack.Top().ShouldNotBe(topValue);
    }

    [Fact]
    public void TestTop()
    {
        // Arrange
        var valueToPush = 40;
        _stack.Push(valueToPush);
        
        // Act
        var result = _stack.Top();
        
        // Assert
        result.ShouldBeEquivalentTo(valueToPush);
    }
}