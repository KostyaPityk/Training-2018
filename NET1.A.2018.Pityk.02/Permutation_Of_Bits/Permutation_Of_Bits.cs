using System;

namespace Permutation_Of_Bits
{
    /// <summary>
    /// Contains method InputNumber which is move bits from first number 
    /// according to positions from i to j in second number
    /// </summary>
    public class Permutation_Of_Bits
    {
        /// <summary>
        /// Change bits of first number accroding to second number's bits in position from i to j 
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <param name="i">First position of bit</param>
        /// <param name="j">Second position of bit</param>
        /// <returns>Value after permutation bits</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises an exception if given positions are not valid
        /// </exception>
        public static int InputNumber(int firstNumber, int secondNumber, int i, int j)
        {
            CheckParameters(i, j);

            //Permution bits two to get range from i to j
            int range = 2 << j - i;

            //Get length from range
            int length = range - 1;

            // Permutation bits to left side to get bits mask
            int bitsMask = length << i;

            //Shifting second number's bits, get bits that  range from i to j 
            int secondNumberShifted = secondNumber << i;

            return (~bitsMask & firstNumber) | (bitsMask & secondNumberShifted);
        }

        /// <summary>
        /// Check given parameters 
        /// </summary>
        /// <param name="i">Position of first bit</param>
        /// <param name="j">Position of second bit</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises an exception if given positions are not valid
        /// </exception>
        private static void CheckParameters(int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException("Your first position bigger then last");
            }

            if (i < 0 || i > 32)
            {
                throw new ArgumentOutOfRangeException("Your first position less then zero or great then 32");
            }

            if (j > 32 || j < 0)
            {
                throw new ArgumentOutOfRangeException("Your last position great then 32 or less then zero");
            }

        }
    }
}
