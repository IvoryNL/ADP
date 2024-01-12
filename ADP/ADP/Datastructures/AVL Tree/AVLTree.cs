using System.Collections;
using System.ComponentModel;

namespace ADP.Datastructures.AVL_Tree;

public class AVLTree<T> where T : IComparable
{
    public Node<T>? Head { get; set; }

    public void Insert(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(null, value, this);
        }
        else
        {
            InsertTo(Head, value);
        }
    }

    private void InsertTo(Node<T> node, T value)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            if (node.LeftChild is null)
            {
                node.LeftChild = new Node<T>(node, value, this);
            }
            else
            {
                InsertTo(node.LeftChild, value);
            }
        }
        else
        {
            if (node.RightChild is null)
            {
                node.RightChild = new Node<T>(node, value, this);
            }
            else
            {
                InsertTo(node.RightChild, value);
            }
        }

        node.Balance();
    }

    public void Remove(T value)
    {
        var currentNode = Find(value);
        
        if (currentNode is null)
        {
            throw new InvalidOperationException();
        }

        Node<T> newRootNode = null;

        if (currentNode.RightChild is not null)
        {
            newRootNode = currentNode.RightChild.LeftChild ?? currentNode.RightChild;
            newRootNode.Parent = currentNode.Parent;
            newRootNode.LeftChild = currentNode.LeftChild;
        }
        else if (currentNode.LeftChild is not null)
        {
            newRootNode = currentNode.LeftChild;
            newRootNode.Parent = currentNode.Parent;
        }

        if (currentNode.Parent is null)
        {
            Head = newRootNode;
            if (newRootNode is not null)
            {
                newRootNode.Parent = null;
            }
        }
        else
        {                
            if (currentNode.Parent.LeftChild is not null && currentNode.Parent.LeftChild.Equals(currentNode))
            {
                currentNode.Parent.LeftChild = newRootNode;
            }
            else if (currentNode.Parent.RightChild is not null)
            {
                currentNode.Parent.RightChild = newRootNode;
            }
        }

        if (currentNode.Parent is not null)
        {
            currentNode.Parent.Balance();
        }
        else
        {
            Head?.Balance();
        }
    }

    public Node<T>? Find(T value)
    {
        var currentNode = Head;

        if (currentNode is null)
        {
            throw new InvalidOperationException("Tree is empty");
        }

        while (currentNode is not null)
        {
            var result = value.CompareTo(currentNode.Value);
            if (result < 0)
            {
                currentNode = currentNode.LeftChild;
            }
            else if (result > 0)
            {
                currentNode = currentNode.RightChild;
            }
            else break;
        }

        return currentNode;
    }

    public Node<T> FindMin()
    {
        var currentNode = Head;

        if (Head is null)
        {
            throw new InvalidOperationException();
        }

        while (currentNode?.LeftChild is not null)
        {
            currentNode = currentNode.LeftChild;
        }

        return currentNode;
    }
    
    public Node<T> FindMax()
    {
        var currentNode = Head;

        if (Head is null)
        {
            throw new InvalidOperationException();
        }

        while (currentNode?.RightChild is not null)
        {
            currentNode = currentNode.RightChild;
        }
        
        return currentNode;
    }
}