namespace ADP.Datastructures.DynamicArray
{
    public class DynamicArray<T>
    {
        private const int GROWTH_FACTOR = 2;
        private const int SHRINK_FACTOR = 4;

        private int _capacity = 10;
        private int _count = 0;

        private T[] _array;

        public DynamicArray()
        {
            _array = new T[_capacity];
        }

        public void Add(T element)
        {
            var index = _count++;

            if (index >= _capacity - 1)
            {
                IncreaseArraySize();
            }

            _array[index] = element;
        }

        public T GetValue(int index)
        {
            ValidateIndex(index);

            return _array[index];
        }

        public void SetValue(int index, T value)
        {
            ValidateIndex(index);

            if (index >= _count)
            {
                Add(value);
            }

            ShiftValuesForInsert(index);

            _array[index] = value;
        }

        public void Remove(T element)
        {
            var index = IndexOf(element);

            if (index == -1)
            {
                return;
            }

            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            ShiftValuesForDelete(index);

            _count--;

            if (_count < _capacity / SHRINK_FACTOR - 1)
            {
                DecreaseArraySize();
            }
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                var item = _array[i];
                if (item is null)
                {
                    continue;
                }

                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                var item = _array[i];
                if (item is null)
                {
                    continue;
                }

                if (item.Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        private void IncreaseArraySize()
        {
            _capacity *= GROWTH_FACTOR;

            Resize();
        }

        private void DecreaseArraySize()
        {
            _capacity = _capacity / GROWTH_FACTOR;

            Resize();
        }

        private void Resize()
        {
            var resizedArray = new T[_capacity];

            for (int i = 0; i < _count - 1; i++)
            {
                resizedArray[i] = _array[i];
            }

            _array = resizedArray;
        }

        private void ShiftValuesForInsert(int index)
        {
            if (_count >= _capacity - 2)
            {
                IncreaseArraySize();
            }

            for (int i = _count - 2; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }
        }

        private void ShiftValuesForDelete(int index)
        {
            for (int i = index; i < _count - 2; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= _capacity)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
