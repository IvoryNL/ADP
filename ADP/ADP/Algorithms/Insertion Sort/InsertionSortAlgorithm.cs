namespace ADP.Algorithms.InsertionSort
{
    public static class InsertionSortAlgorithm
    {
        public static int[] InsertionSort(int[] inputArray)
        {
            for (var i = 1; i < inputArray.Length; i++)
            {
                var temp = inputArray[i];
                var currentIndex = i - 1;

                while (temp < inputArray[currentIndex])
                {
                    inputArray[currentIndex + 1] = inputArray[currentIndex];
                    currentIndex--;
                }

                inputArray[currentIndex + 1] = temp;
            }

            return inputArray;
        }
    }
}
