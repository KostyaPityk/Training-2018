using System;
using System.Collections.Generic;

namespace SearchInArray
{
    /// <summary>
    /// Contains method SearchIndex which looks for an array element whose sum of elements on the right and left is the same
    /// </summary>
    public static class SearchInArray
    {
        /// <summary>
        /// Search maximum element in array
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <exception cref="ArgumentNullException">
        /// If array is null
        /// </exception>
        /// <returns>Index of element in array</returns>
        public static int SearchIndex(double[] array)
        {
            CheckParameters(array);

            for (int i = 1; i < array.Length; i++)
            {
                double leftSum = array.Take(i).SumOfArray();
                double rightSum = array.Skip(i + 1).SumOfArray();

                if (leftSum.ToString().Equals(rightSum.ToString()))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Check array on null
        /// </summary>
        /// <param name="array">Array to be cheacked</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        private static void CheckParameters(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Invalid array format");
            }
        }

        private static double SumOfArray(this IEnumerable<double> array)
        {
            double result = 0;

            foreach (double number in array)
            {
                result += number;
            }

            return result;
        }

        private static IEnumerable<double> Skip(this double[] array, int index)
        {
            for (int i = index; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        private static IEnumerable<double> Take(this double[] array, int index)
        {
            for (int i = 0; i < index; i++)
            {
                yield return array[i];
            }
        }
    }
}
