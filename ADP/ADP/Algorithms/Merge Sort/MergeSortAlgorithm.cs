namespace ADP.Algorithms.MergeSort
{
    public static class MergeSortAlgorithm
    {
        public static void ParallelMergeSort(int[] inputArray)
        {
            var length = inputArray.Length;

            if (length <= 1) return;

            var mid = length / 2;
            var leftArray = new int[mid];
            var rightArray = new int[length - mid];
            var j = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < mid)
                {
                    leftArray[i] = inputArray[i];
                }
                else
                {
                    rightArray[j++] = inputArray[i];
                }
            }
            
            Parallel.Invoke(() => ParallelMergeSort(leftArray), () => ParallelMergeSort(rightArray));
            
            Merge(inputArray, leftArray, rightArray);
        }
        
        private static void Merge(int[] inputArray, int[] leftArray, int[] rightArray)
        {
            var leftSize = leftArray.Length;
            var rightSize = rightArray.Length;

            var i = 0;
            var left = 0;
            var right = 0;

            while (left < leftSize && right < rightSize)
            {
                if (leftArray[left] < rightArray[right])
                {
                    inputArray[i] = leftArray[left];
                    left++;
                }
                else
                {
                    inputArray[i] = rightArray[right];
                    right++;
                }

                i++;
            }

            while (left < leftSize)
            {
                inputArray[i] = leftArray[left];
                left++;
                i++;
            }

            while (right < rightSize)
            {
                inputArray[i] = rightArray[right];
                right++;
                i++;
            }
        }
    }
}
