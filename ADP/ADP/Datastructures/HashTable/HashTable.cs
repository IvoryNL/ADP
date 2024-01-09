using ADP.Datastructures.DynamicArray;

namespace ADP.Datastructures.HashTable;

public class HashTable<TKey, TValue>
{
    
    private const int GROWTH_FACTOR = 2;
    private const int SHRINK_FACTOR = 4;
    private const double LOAD_FACTOR_MAX = 0.5;
    private const double LOAD_FACTOR_MIN = LOAD_FACTOR_MAX / 2;

    private LinkedList<KeyValue<TKey, TValue>>[] _buckets;
    private int _count;
    private int _capacity = 10;

    public HashTable()
    {
        _buckets = new LinkedList<KeyValue<TKey, TValue>>[_capacity];
        InstantiateBuckets(_buckets);
    }

    public void Insert(TKey key, TValue value)
    {
        var index = GenerateHashCode(key);
        var newKeyValue = new KeyValue<TKey, TValue>(key, value);

        _buckets[index].AddFirst(newKeyValue);
        _count++;
        
        if (GetLoadFactorValue() > LOAD_FACTOR_MAX)
        {
            DecreaseArraySize();
        }
    }

    public TValue Get(TKey key)
    {
        var index = GenerateHashCode(key);

        foreach (var item in _buckets[index].Where(item => item.Key != null && item.Key.Equals(key)))
        {
            return item.Value;
        }

        throw new KeyNotFoundException($"Key {key} not found");
    }

    public void Delete(TKey key)
    {
        var index = GenerateHashCode(key);
        var values = _buckets[index].Where(b => b.Key.Equals(key));
        
        foreach (var item in values)
        {
            _buckets[index].Remove(item);
            _count--;
        }

        if (GetLoadFactorValue() < LOAD_FACTOR_MIN)
        {
            DecreaseArraySize();
        }
    }

    public void Update(TKey key, TValue value)
    {
        var index = GenerateHashCode(key);
        
        var currentKeyValue = _buckets[index].FirstOrDefault(b => b.Key.Equals(key));
        currentKeyValue.Value = value;
    }

    private double GetLoadFactorValue()
    {
        return _count * 1.0 / _buckets.Length;
    }

    private void InstantiateBuckets(LinkedList<KeyValue<TKey, TValue>>[] buckets)
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new LinkedList<KeyValue<TKey, TValue>>();
        }
    }

    private int GenerateHashCode(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        
        if (typeof(TKey) == typeof(int))
        {
            return key.GetHashCode();
        }

        if (typeof(TKey) == typeof(string))
        {
            return GetCustomHashCode(key.ToString());
        }
        
        return key.GetHashCode();
    }

    private int GetCustomHashCode(string key)
    {
        var hash = 17;

        foreach (var item in key)
        {
            hash *= 31 + item;
        }
        
        return hash;
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
        var newCapacity = _capacity * GROWTH_FACTOR;
        var resizedArray = new LinkedList<KeyValue<TKey, TValue>>[newCapacity];
        
        InstantiateBuckets(resizedArray);

        for (int i = 0; i < _count - 1; i++)
        {
            resizedArray[i] = _buckets[i];
        }

        _buckets = resizedArray;
    }
}