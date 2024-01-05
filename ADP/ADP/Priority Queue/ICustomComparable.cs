namespace ADP.Datastructures.PriorityQueue
{
    public interface ICustomComparable<T1, T2>
    {
        int CompareTo(T1 t1, T2 t2);
    }
}
