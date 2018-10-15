using System;

namespace SortingAlgorithm
{
    /// <summary>
    ///  Class of sorting of integer numbers, contains sorting: Merge and Quick
    /// </summary>
    public static class SortingAlgorithm
    {
        #region Public methods
        /// <summary>
        /// Sorting array of integer values using Merge sort
        /// </summary>
        /// <param name="array">Array for sorting</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        public static void MergeSort(int[] array)
        {
            CheckArray(array);

            if (array.Length <= 1)
            {
                return;
            }

            int middle = array.Length / 2;
            int[] lefthalf = new int[middle];
            int[] righthalf = new int[array.Length - middle];

            Array.Copy(array, 0, lefthalf, 0, middle);
            Array.Copy(array, middle, righthalf, 0, righthalf.Length);

            MergeSort(lefthalf);
            MergeSort(righthalf);

            int i = 0, j = 0, k = 0;

            while (i < lefthalf.Length && j < righthalf.Length)
            {
                if (lefthalf[i] < righthalf[j])
                {
                    array[k] = lefthalf[i];
                    i++;
                }
                else
                {
                    array[k] = righthalf[j];
                    j++;
                }

                k++;
            }

            while (i < lefthalf.Length)
            {
                array[k] = lefthalf[i];
                i++;
                k++;
            }

            while (j < righthalf.Length)
            {
                array[k] = righthalf[j];
                j++;
                k++;
            }   
        }

        /// <summary>
        ///  Sorting array of integer values using Quick sort
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startIndex">Where to start sort position</param>
        /// <param name="endIndex">Where to end sort position</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises if start position great then end position
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        public static void Qsort(int[] array, int startIndex, int endIndex)
        {
            CheckParameters(array, startIndex, endIndex);

            if (startIndex >= endIndex)
            {
                return;
            }

            int i = startIndex;
            int j = endIndex;

            int key = array[(startIndex + endIndex) / 2];

            while (i <= j)
            {
                while (array[i] < key)
                {
                    i++;
                }

                while (array[j] > key)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                Swap(ref array[i], ref array[j]);

                i++;
                j--;
            }

            Qsort(array, startIndex, j);
            Qsort(array, j + 1, endIndex);
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Swap the array elements
        /// </summary>
        /// <param name="first">First element</param>
        /// <param name="second">Second element</param>
        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Checks the array for emptiness and corrected index
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="startIndex">Where to start sort position</param>
        /// <param name="endIndex">Where to end sort position</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises if start position great then end position
        /// </exception>
        private static void CheckParameters(int[] array, int startIndex, int endIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Your array is empty");
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Start position great then end position");
            }
        }

        /// <summary>
        /// Checks the array for emptiness
        /// </summary>
        /// <param name="array">Array</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        private static void CheckArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Your array is empty");
            }
        }
        #endregion
    }
}
