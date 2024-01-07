namespace ADP.Datastructures.DoublyLinkedList;

public class DoublyLinkedList<T>
{
    private int _count = 0;
    private Node<T>? Head { get; set; } = null;
    private Node<T>? Tail { get; set; } = null;

    public void Add(T data)
    {
        var newNode = new Node<T>(data);
        
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Head.Previous = newNode;
            newNode.Next = Head;
            Head = newNode;
        }

        _count++;
    }
    
    public T GetValue(int index)
    {
        ValidateIndex(index);
        ValidateNode(Head);

        var counter = 0;
        var node = Head;

        while (node!.Next != null)
        {
            if (index == counter)
            {
                break;
            }

            node = node.Next;
            counter++;
        }

        return node.Data;
    }

    public void SetValue(int index, T data)
    {
        ValidateNodeData(data);

        var newNode = new Node<T>(data);

        if (Head == null)
        {
            Add(newNode);

            return;
        }

        if (index > _count - 1)
        {
            newNode.Previous = Tail!;
            Tail!.Next = newNode;
            Tail = newNode;

            return;
        }

        ValidateNode(Head);

        var counter = 0;
        var node = Head;

        while (node!.Next != null)
        {
            if (index == counter)
            {
                var previousNode = node.Previous;
                var nextNode = node.Next;

                if (previousNode != null)
                {
                    previousNode.Next = newNode;
                }

                nextNode.Previous = newNode;
            }

            node = node.Next;
            counter++;
        }
    }

    public void Remove(T data)
    {
        ValidateNodeData(data);
        ValidateNode(Head);

        var currentNode = Head;

        while (currentNode != null)
        {
            if (currentNode.Data != null && currentNode.Data.Equals(data))
            {
                break;
            }

            currentNode = currentNode.Next;
        }
        
        RemoveNode(currentNode);
    }

    public void RemoveAt(int index)
    {
        ValidateNode(Head);

        var counter = 0;
        var currentNode = Head;

        while (currentNode != null && counter < index)
        {
            currentNode = currentNode.Next;
            counter++;
        }

        RemoveNode(currentNode);
    }

    public bool Contains(T data)
    {
        ValidateNodeData(data);
        ValidateNode(Head);

        var index = 0;
        var node = Head;

        while (node!.Next != null)
        {
            if (node!.Data!.Equals(data))
            {
                return true;
            }

            node = node.Next;
            index++;
        }

        return false;
    }

    public int IndexOf(T data)
    {
        ValidateNodeData(data);
        ValidateNode(Head);

        var index = 0;
        var node = Head;

        while (node != null)
        {
            ValidateNodeData(node.Data);

            if (node!.Data!.Equals(data))
            {
                return index;
            }

            node = node.Next;
            index++;
        }

        return -1;
    }

    private static void ValidateNode(Node<T>? node)
    {
        if (node == null)
        {
            throw new ArgumentException();
        }
    }

    private static void ValidateNodeData(T data)
    {
        if (data == null)
        {
            throw new ArgumentException();
        }
    }

    private void ValidateIndex(int index)
    {
        if (index > _count - 1)
        {
            throw new IndexOutOfRangeException();
        }
    }
    
    private void Add(Node<T> node)
    {
        if (Head is null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Head.Previous = node;
            node.Next = Head;
            Head = node;
        }

        _count++;
    }
    
    private void RemoveNode(Node<T>? currentNode)
    {
        if (currentNode == null)
        {
            throw new IndexOutOfRangeException();
        }

        if (currentNode.Previous != null)
        {
            currentNode.Previous.Next = currentNode.Next;
        }
        else
        {
            Head = currentNode.Next;
        }

        if (currentNode.Next != null)
        {
            currentNode.Next.Previous = currentNode.Previous;
        }
    }
}
