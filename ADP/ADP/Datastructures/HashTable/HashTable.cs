using ADP.Datastructures.DynamicArray;

namespace ADP.Datastructures.HashTable;

public class HashTable<TKey, TValue> where TValue : IEquatable<TValue>
{
    private const int GrowthFactor = 2;
    private const double LoadFactorMax = 0.5;
    private const double LoadFactorMin = LoadFactorMax / 2;

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
        ValidateKey(key);
        ValidateValue(value);
        
        var index = GenerateHashCode(key);
        var newKeyValue = new KeyValue<TKey, TValue>(key, value);

        _buckets[index].AddFirst(newKeyValue);
        _count++;

        var loadFactor = GetLoadFactorValue();
        if (loadFactor > LoadFactorMax)
        {
            IncreaseArraySize();
        }
    }
    
    public TValue Get(TKey key)
    {
        ValidateKey(key);
        
        var index = GenerateHashCode(key);

        foreach (var item in _buckets[index].Where(item => item.Key != null && item.Key.Equals(key)))
        {
            return item.Value;
        }

        throw new KeyNotFoundException($"Key {key} not found");
    }

    public void Delete(TKey key)
    {
        ValidateKey(key);

        var index = GenerateHashCode(key);
        var item = _buckets[index].FirstOrDefault(b => b.Key != null && b.Key.Equals(key));

        _buckets[index].Remove(item);
        _count--;

        if (GetLoadFactorValue() < LoadFactorMin)
        {
            DecreaseArraySize();
        }
    }

    public void Update(TKey key, TValue value)
    {
        ValidateKey(key);
        ValidateValue(value);
        
        var index = GenerateHashCode(key);
        
        var currentKeyValue = _buckets[index].FirstOrDefault(b => b.Key != null && b.Key.Equals(key));
        if (currentKeyValue != null)
        {
            currentKeyValue.Value = value;
        }
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
    
    private void ValidateKey(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
    }
    
    private void ValidateValue(TValue value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
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
            var hash = key.GetHashCode();
            return hash % _buckets.Length;
        }

        if (typeof(TKey) == typeof(string))
        {
            var hash = GetCustomHashCode(key.ToString());
            return hash % _buckets.Length;
        }
        
        return key.GetHashCode() % _buckets.Length;
    }

    private int GetCustomHashCode(string key)
    {
        var hash = 17;

        foreach (var item in key)
        {
            hash *= 31 + item;
        }
        
        return hash >= 0 ? hash : -hash; ;
    }
    
    private void IncreaseArraySize()
    {
        _capacity *= GrowthFactor;

        Resize();
    }

    private void DecreaseArraySize()
    {
        _capacity = _capacity / GrowthFactor;

        Resize();
    }
    
    private void Resize()
    {
        var newCapacity = _capacity * GrowthFactor;
        var resizedArray = new LinkedList<KeyValue<TKey, TValue>>[newCapacity];
        
        InstantiateBuckets(resizedArray);

        for (int i = 0; i < _count - 1; i++)
        {
            resizedArray[i] = _buckets[i];
        }

        _buckets = resizedArray;
    }
}