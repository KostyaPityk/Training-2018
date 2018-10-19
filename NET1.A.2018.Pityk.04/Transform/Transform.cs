using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        {
            CheckFromNull(array);

            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = TransformToWords(array[i]);
            }

            return result;
        }

        #endregion

        #region Privete methods
        /// <summary>
        /// Transform digit of real numbers to string word format
        /// </summary>
        /// <param name="digit">Digit to be transforms</param>
        /// <returns>Transforms string word format digit</returns>
        private static string TransformToWords(double digit)
        {
            string string_digit = digit.ToString();
            string result = string.Empty;
            
            foreach (char temp in string_digit)
            {
                string symbol = temp.ToString();

                switch (symbol)
                {
                    case "-":
                        result += DigitToWords.minus;
                        break;
                    case ",":
                        result += DigitToWords.point;
                        break;
                    case "0":
                        result += DigitToWords.zero;
                        break;
                    case "1":
                        result += DigitToWords.one;
                        break;
                    case "2":
                        result += DigitToWords.two;
                        break;
                    case "3":
                        result += DigitToWords.three;
                        break;
                    case "4":
                        result += DigitToWords.four;
                        break;
                    case "5":
                        result += DigitToWords.five;
                        break;
                    case "6":
                        result += DigitToWords.six;
                        break;
                    case "7":
                        result += DigitToWords.seven;
                        break;
                    case "8":
                        result += DigitToWords.eight;
                        break;
                    case "9":
                        result += DigitToWords.nine;
                        break;
                }

                result += " ";
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
