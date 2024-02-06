namespace SortierAlgorithmen_Abgabe
{
    public static class Mergesort
    {
        public static void Sort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int[] leftArray = new int[array.Length / 2];
            int[] rightArray = new int[array.Length - leftArray.Length];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = array[leftArray.Length + i];
            }

            Sort(leftArray);
            Sort(rightArray);
            Merge(leftArray, rightArray, array);
        }

        public static void MergesortDescending(int[] array)
        {
            Sort(array);
            Array.Reverse(array);
        }

        private static void Merge(int[] leftArray, int[] rightArray, int[] mergedArray)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    mergedArray[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[mergedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

            while (leftIndex < leftArray.Length)
            {
                mergedArray[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < rightArray.Length)
            {
                mergedArray[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
}
