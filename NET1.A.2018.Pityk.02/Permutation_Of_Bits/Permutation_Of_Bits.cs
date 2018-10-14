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
        /// <param name="j">Second poistion of bit</param>
        /// <returns>Value after permutation bits</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises an exception if given positions are not valid
        /// </exception>
        public static int InputNumber(int firstNumber, int secondNumber, int i, int j)
        {
            CheckParameters(i, j);

            return 1;
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

            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("Your first position less then zero");
            }

            if (j > 32)
            {
                throw new ArgumentOutOfRangeException("Your last position great then 32 (Maximum amount of bits in Int.32 )");
            }

        }
    }
}
