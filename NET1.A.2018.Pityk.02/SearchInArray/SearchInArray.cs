using System;
using System.Linq;

namespace SearchInArray
{
    /// <summary>
    /// Contains method SearchIndex which looks for an array element whose sum of elements on the right and left is the same
    /// </summary>
    public class SearchInArray
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
                if (array.Take(i).Sum().ToString().Equals(array.Skip(i + 1).Sum().ToString()))
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
                throw new ArgumentNullException("Invalid array format");
            }
        }
    }
}
