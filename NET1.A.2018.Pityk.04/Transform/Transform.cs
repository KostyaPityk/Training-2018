using System;
using System.Collections.Generic;
using DoubleExtention;

namespace Transform
{
    /// <summary>
    /// Contains method TransformToWords which takes an array of real numbers and transforms 
    /// it into an array of strings so that each real number is converted to its " word format"
    /// </summary>
    public static class Transform
    {
        #region Public methods
        /// <summary>
        /// Transform array of real numbers to array of strings
        /// </summary>
        /// <param name="array">Array to be transforms</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        /// <returns>Transforms string array</returns>
        public static string[] TransformToWords(double[] array)
             => CommonTransform(TransformToWords, array);

        /// <summary>
        /// Transform array of real numbers to array of strings by format IEEE754
        /// </summary>
        /// <param name="array">Array to be transforms</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        /// <returns>Transforms string array</returns>
        public static string[] TransformToIEEEFormat(double[] array)
             => CommonTransform(DoubleExtention.DoubleExtention.ToBinaryString, array);
        #endregion

        #region Privete methods
        /// <summary>
        /// Transform digit of real numbers to string word format
        /// </summary>
        /// <param name="digit">Digit to be transforms</param>
        /// <returns>Transforms string word format digit</returns>
        private static string TransformToWords(double digit)
        {
            Dictionary<char, string> dictionarywords = new Dictionary<char, string>
            {
                { '-', "minus" },
                { ',', "point" },
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" }
            };
            string string_digit = digit.ToString();
            string result = string.Empty;
            
            foreach (char symbol in string_digit)
            {
                result += dictionarywords[symbol] + " ";
            }

            return result;
        }

        private static string[] CommonTransform(Func<double, string> method, double[] array)
        {
            CheckFromNull(array);

            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = method.Invoke(array[i]);
            }

            return result;
        }

        /// <summary>
        /// Check array on null
        /// </summary>
        /// <param name="array">Array to be cheacked</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given array is null
        /// </exception>
        private static void CheckFromNull(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null");
            }
        }
        #endregion
    }
}
