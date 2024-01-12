using ADP.Datastructures.AVL_Tree.Enums;

namespace ADP.Datastructures.AVL_Tree;

public class Node<T> : IComparable<T> where T : IComparable
{
    public T Value;
    public Node<T>? Parent { get; set; }
    public Node<T>? LeftChild { get; set; }
    public Node<T>? RightChild { get; set; }
    public int BalanceFactor => _rightHeight - _leftHeight;
    
    private AVLTree<T> _avlTree;
    private int _leftHeight => MaxChildHeight(LeftChild);
    private int _rightHeight => MaxChildHeight(RightChild);
    private TreeState _nodeState
    {
        get
        {
            return BalanceFactor switch
            {
                < -1 => TreeState.LeftHeavy,
                > 1 => TreeState.RightHeavy,
                _ => TreeState.Balanced
            };
        }
    }
    
    public Node(Node<T> parent, T value, AVLTree<T> avlTree)
    {
        Parent = parent;
        Value = value;
        _avlTree = avlTree;
    }

    public void Balance()
    {
        switch (_nodeState)
        {
            case TreeState.LeftHeavy when LeftChild?.BalanceFactor > 0:
                RotateRightLeft();
                break;
            case TreeState.LeftHeavy:
                RotateRight();
                break;
            case TreeState.RightHeavy when RightChild?.BalanceFactor < 0:
                RotateLeftRight();
                break;
            case TreeState.RightHeavy:
                RotateLeft();
                break;
        }
    }

    private void RotateLeft()
    {
        var newRootNode = RightChild;
        
        ReplaceRoot(newRootNode);
        
        RightChild = newRootNode?.LeftChild;

        if (newRootNode is not null)
        {
            newRootNode.LeftChild = this;
        }
    }

    private void RotateRight()
    {
        var newRootNode = LeftChild;
        
        ReplaceRoot(newRootNode);
        
        LeftChild = newRootNode?.RightChild;

        if (newRootNode is not null)
        {
            newRootNode.RightChild = this;
        }
    }

    private void ReplaceRoot(Node<T> newRootNode)
    {
        if (newRootNode == null) throw new ArgumentNullException(nameof(newRootNode));
        
        if (Parent is null)
        {
            _avlTree.Head = newRootNode;
        }
        else
        {
            if (Parent.LeftChild == this)
            {
                Parent.LeftChild = newRootNode;
            }
            else if (Parent.RightChild == this)
            {
                Parent.RightChild = this;
            }
        }
    }

    private void RotateLeftRight()
    {
        RotateLeft();
        RotateRight();
    }

    private void RotateRightLeft()
    {
        RotateRight();
        RotateLeft();
    }

    private int MaxChildHeight(Node<T>? childNode)
    {
        if (childNode is not null)
        {
            return 1 + Math.Max(MaxChildHeight(childNode.LeftChild), MaxChildHeight(childNode.RightChild));
        }
        
        return 0;
    }
    
    public int CompareTo(T? other)
    {
        return Value.CompareTo(other);
    }
}