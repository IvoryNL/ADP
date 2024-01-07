namespace ADP.Datastructures.DoublyEndedQueue
{
    public class DoubleEndedQueue<T>
    {
        private int _count;
        private Node<T>? _head;
        private Node<T>? _tail;

        public DoubleEndedQueue()
        {
            _count = 0;
            _head = null;
            _tail = null;
        }

        public void InsertLeft(T data)
        {
            var newNode = new Node<T>(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _head.Previous = newNode;
                newNode.Next = _head;
                _head = newNode;
            }

            _count++;
        }

        public T DeleteLeft() 
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var data = _head.Data;

            if (_head.Next == null)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
            }

            _count--;

            return data;
        }
        
        public T PeekLeft()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            
            return _head.Data;;
        }

        public void InsertRight(T data)
        {
            var newNode = new Node<T>(data);

            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }

            _count++;
        }

        public T DeleteRight()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var data = _tail.Data;

            if (_tail.Previous == null)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = _tail.Previous;
            }

            _count--;
            return data;
        }
        
        public T PeekRight()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            
            return _tail.Data;;
        }

        public int Size()
        {
            return _count;
        }
    }
}
