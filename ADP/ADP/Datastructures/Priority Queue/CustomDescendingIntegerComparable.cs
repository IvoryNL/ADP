namespace ADP.Datastructures.PriorityQueue
{
    public class CustomDescendingIntegerComparable : ICustomComparable<int, int>
    {
        public int CompareTo(int t1, int t2)
        {
            return t1 < t2 ? 1 : -1;
        }
    }
}
