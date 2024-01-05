namespace ADP.Datastructures.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<T> _heap;
        private IComparer<T> _comparer;

        public PriorityQueue() : this(Comparer<T>.Default)
        {
        }

        public PriorityQueue(Comparer<T> comparer)
        {
            _comparer = comparer;
            _heap = new List<T>();
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);

            BubbleUp();
        }

        public T Dequeue() 
        {
            var result = _heap[0];

            BubbleDown();

            return result;
        }

        public T Peek()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }

            return _heap[0];
        }

        private void BubbleUp()
        {
            var childIndex = _heap.Count - 1;

            while (childIndex >= 0)
            {
                var parentIndex = (childIndex - 1) / 2;

                if (_comparer.Compare(_heap[childIndex], _heap[parentIndex]) < 0)
                {
                    Swap(childIndex, parentIndex);
                    childIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void BubbleDown()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }

            var lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            var index = 0;

            while (true)
            {
                var leftChildIndex = index * 2 + 1;
                var rightChildIndex = index * 2 + 2;

                if (leftChildIndex < _heap.Count - 1)
                {
                    var minChildIndex = leftChildIndex;
                    
                    if (rightChildIndex < _heap.Count - 1 && _comparer.Compare(_heap[rightChildIndex], _heap[leftChildIndex]) < 0)
                    {
                        minChildIndex = rightChildIndex;
                    }

                    if (_comparer.Compare(_heap[minChildIndex], _heap[index]) < 0)
                    {
                        Swap(index, minChildIndex);
                        index = minChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _heap[firstIndex];
            _heap[firstIndex] = _heap[secondIndex];
            _heap[secondIndex] = temp;
        }
    }
}
