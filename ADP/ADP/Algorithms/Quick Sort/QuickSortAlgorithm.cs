namespace ADP.Algorithms.QuickSort
{
    public static class QuickSortAlgorithm
    {
        public static void QuickSort(int[] inputCollection)
        {
            var start = 0;
            var end = inputCollection.Length - 1;
            QuickSort(inputCollection, start, end);
        }
        
        private static void QuickSort(int[] inputCollection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = Partition(inputCollection, start, end);
            QuickSort(inputCollection, start, pivot - 1);
            QuickSort(inputCollection, pivot + 1, end);
        }

        private static int Partition(int[] inputCollection, int start, int end)
        {
            int j = start - 1;
            int pivot = inputCollection[end];
            int temp;

            for (int i = start; i < end; i++)
            {
                if (inputCollection[i] < pivot)
                {
                    j++;

                    temp = inputCollection[i];
                    inputCollection[i] = inputCollection[j];
                    inputCollection[j] = temp;
                }
            }

            j++;

            temp = inputCollection[j];
            inputCollection[j] = pivot;
            inputCollection[end] = temp;

            return j;
        }
    }
}
