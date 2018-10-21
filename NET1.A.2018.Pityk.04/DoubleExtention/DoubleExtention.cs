using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleExtention
{
    /// <summary>
    /// Represents class that expands the possibilities of System.Double
    /// by implementing method to represent System.Double into its binary string
    /// representation according to IEEE 754 rules
    /// </summary>
    public static class DoubleExtention
    {
        /// <summary>
        /// Extension method for System.Double to convert double to 
        /// IEEE 754 binary representation
        /// </summary>
        /// <param name="number">Double value to be converted to string</param>
        /// <returns>Representation of System.Double in IEEE 754</returns>
        public static string ToBinaryString(double number)
        {
            if (number == -0.0)
            {
                return "1000000000000000000000000000000000000000000000000000000000000000";
            }
            else if (number == 0.0)
            {
                return "0000000000000000000000000000000000000000000000000000000000000000";
            }
            else if (number == double.PositiveInfinity)
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }
            else if (number == double.NegativeInfinity)
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }
            else if (number == double.Epsilon)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }
            else if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            string str_number = number.ToString();
            string[] split = str_number.Split(Convert.ToChar(","));
            string result = CheckFromPositive(split[0]);

            string whole = split[0].StartsWith("-") ? split[0].Split(Convert.ToChar("-"))[1] : split[0];
            double power = Convert.ToDouble(whole);
            string fractional = split.Length > 1 ? split[1] : "0";

            whole = ConvertToBin(whole);
            fractional = FindOffset(fractional);

            string mantissa = Mantissa(whole, fractional);
            string exponent = Exponent(CheckPower(Convert.ToInt64(power)));

            while (exponent.Length < 11)
            {
                exponent = exponent + "0";
            }

            return result + exponent + mantissa;
        }

        #region Private methods
        /// <summary>
        /// Calculates the number of bits that an integer part of a number occupies.
        /// </summary>
        /// <param name="whole">The integer part of the number</param>
        /// <returns>Number of items</returns>
        private static int CheckPower(double whole)
        {
            int i = 0;

            while (whole > 1)
            {
                whole = Math.Truncate(whole / 2);
                i++;
            }

            return i;
        }

        /// <summary>
        /// Calculates the binary representation of the fractional part
        /// </summary>
        /// <param name="fractional">Fractional part of number</param>
        /// <returns>Binary representation</returns>
        private static string FindOffset(string fractional)
        {
            double offset = Convert.ToDouble("0," + fractional);
            string result = string.Empty;

            for (int i = 0; i < 52; i++)
            {
                offset *= 2;

                if (offset >= 1)
                {
                    result += "1";
                    offset -= 1;
                }
                else
                {
                    result += "0";
                }
            }

            return result;
        }

        /// <summary>
        /// Calculates the exponent of a number in IEEE 754
        /// </summary>
        /// <param name="shift">Shift</param>
        /// <returns>Exponent of binary format</returns>
        private static string Exponent(int shift) => ConvertToBin(Convert.ToString(1023 + shift));

        /// <summary>
        /// Calculates the mantissa of a number in IEEE 754
        /// </summary>
        /// <param name="whole">Whole part of number</param>
        /// <param name="fractional">Fractional part of number</param>
        /// <returns>Mantissa of binary format</returns>
        private static string Mantissa(string whole, string fractional)
        {
            string result = whole + fractional;
            result = result.Remove(51, result.Length - 52 - 1);
            if (result[0] == Convert.ToChar("1"))
            {
                result = result.Remove(0, 1);
            }
            else
            {
                int i = 0;
                while (result[i] == Convert.ToChar("0"))
                {
                    result = result.Remove(0, 1);
                }

                result = result.Remove(0, 1);
            }

            while (result.Length < 52)
            {
                result += "0";
            }

            return result;
        }

        /// <summary>
        /// Check positive input number
        /// </summary>
        /// <param name="number">Number to be check</param>
        /// <returns>1 if negative number and 0 if positive</returns>
        private static string CheckFromPositive(string number) => number.StartsWith("-") ? "1" : "0";

        /// <summary>
        /// Convert number from binary format
        /// </summary>
        /// <param name="value">Number to be format</param>
        /// <returns>Binary format number</returns>
        private static string ConvertToBin(string value)
        {
            long number = Convert.ToInt64(value);
            double temp = 0;
            List<int> result_array = new List<int>();

            while (number > 0)
            {
                temp = (int)(number % 2);
                number /= 2;
                result_array.Add(Convert.ToInt32(temp));
            }

            result_array.Reverse();

            string result = string.Empty;
            foreach (int temp_number in result_array)
            {
                result += temp_number;
            }

            return result;
        }

        #endregion
    }
}
