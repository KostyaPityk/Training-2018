using System;
using System.Linq;

namespace MaxElement
{
    /// <summary>
    /// Recursively searches for the maximum element in an array
    /// </summary>
    public class MaxElement
    {
        /// <summary>
        /// Search maximum element in array
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="max">Search result, the result is placed in this variable</param>
        /// <returns>Max element in array</returns>
        public static int? SearchMaxElement(int[] array, int? max = null)
        {
            CheckParameters(array);

            if (array.Length == 0)
            {
                return max;
            }

            if (max < array[0] | max == null)
            {
                max = array[0];
            }

            return max = SearchMaxElement(array.Skip(1).ToArray(), max);
        }

        /// <summary>
        /// Check array on null
        /// </summary>
        /// <param name="array">Array to be cheacked</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        private static void CheckParameters(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Invalid array format");
            }
        }
    }
}
