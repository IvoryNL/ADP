namespace ADP.Algorithms.Binary_Search
{
    public static class BinarySearchAlgorithm
    {
        public static int BinarySearch(List<int> sortedList, int numberToFind)
        {
            var left = 0;
            var right = sortedList.Count - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (numberToFind == sortedList[mid])
                {
                    return mid;
                }

                if (numberToFind < sortedList[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}
