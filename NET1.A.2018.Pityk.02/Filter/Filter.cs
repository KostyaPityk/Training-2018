using System;
using System.Collections.Generic;

namespace Filter
{
    /// <summary>
    /// Contains method FilterDigit which select numbers in given array, 
    /// which contains digit that you have been chose
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// Filter array from template number
        /// </summary>
        /// <param name="array">Array to be filtered</param>
        /// <param name="template_number">Number by which to filter</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        /// <returns>Filtered array</returns>
        public static IEnumerable<int> FilterDigit(int[] array, int template_number)
        {
            CheckParameters(array);

            foreach (int element in array)
            {
                if (CheckContains(element, template_number))
                {
                    yield return element;
                }
            }
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

        /// <summary>
        /// Check array on null
        /// </summary>
        /// <param name="check_number">Number from array that will be check from contains template number</param>
        /// <param name="template_number">Template number on which there is a comparison</param>
        /// <returns>True, if check number contains template number, else False</returns>
        private static bool CheckContains(int check_number, int template_number)
        {
            return check_number.ToString().Contains(template_number.ToString());
        }
    }
}
