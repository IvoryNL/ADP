namespace ADP.Datastructures.Stack
{
    public class Stack<T>
    {
        private int _count;
        private Node<T>? _head;

        public Stack()
        {
            _count = 0;
            _head = null;
        }

        public void Push(T data)
        {
            var newNode = new Node<T>(data);

            if (_head == null)
            {
                _head = newNode;
            }

            newNode.Next = _head;
            _head = newNode;
            _count++;
        }

        public T Pop()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var data = _head.Data;
            _head = _head.Next;
            _count--;

            return data;
        }

        public T Top()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _head.Data;
        }

        public int Size()
        {
            return _count;
        }

        public bool IsEmpty()
        {
            return _count > 0;
        }
    }
}
