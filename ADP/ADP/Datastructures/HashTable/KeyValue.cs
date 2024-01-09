namespace ADP.Datastructures.DynamicArray;

public class KeyValue<TKey, TValue>
{
    public TKey Key { get; }
    public TValue Value { get; set; }
    
    public KeyValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}