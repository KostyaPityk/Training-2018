using System;
using System.Collections.Generic;

namespace JaggedArray
{
    public static class JaggedArray
    {
        public static void Sort(this int[][] array, IComparer<int[]> compared)
        {
            CheckData(array);

            array.BubbleSort(compared.Compare);
        }

        #region Private methods
        private static void CheckData(int[][] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Parameters should not be represent as null array");
            }
        }

        private static void BubbleSort(this int[][] array, Comparison<int[]> compared)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (compared(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
        #endregion
    }
}
