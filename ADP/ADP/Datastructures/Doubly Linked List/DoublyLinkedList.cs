namespace ADP.Datastructures.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private int _count;

        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }

        public DoublyLinkedList()
        {
            _count = 0;
            Head = null;
            Tail = null;
        }

        public void Add(Node<T> node)
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

            var node = Head;

            while (node!.Next != null)
            {
                if (node.Data!.Equals(data))
                {
                    var previousNode = node.Previous;
                    var nextNode = node.Next;

                    if (previousNode != null)
                    {
                        previousNode.Next = nextNode;
                    }

                    node.Previous = previousNode;

                    break;
                }

                node = node.Next;
            }
        }

        public void RemoveAt(int index)
        {
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
                        nextNode.Previous = nextNode;
                    }

                    nextNode.Previous = previousNode;

                    break;
                }

                counter--;
            }
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
    }
}
