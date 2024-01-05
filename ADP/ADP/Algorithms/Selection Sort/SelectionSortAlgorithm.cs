namespace ADP.Algorithms.SelectionSort
{
    public class SelectionSortAlgorithm
    {
        public static int[] SelectionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                var minValue = inputArray[i];
                var currentIndex = i + 1;

                for (int j = currentIndex; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < minValue)
                    {
                        minValue = inputArray[j];
                        currentIndex = j;
                    }
                }

                if (minValue < inputArray[i])
                {
                    var temp = inputArray[i];
                    inputArray[i] = inputArray[currentIndex];
                    inputArray[currentIndex] = temp;
                }
            }

            return inputArray;
        }
    }
}
