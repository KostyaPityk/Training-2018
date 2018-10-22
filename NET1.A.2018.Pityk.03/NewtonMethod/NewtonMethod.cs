using System;
using System.Data;

namespace NewtonMethod
{
    /// <summary>
    /// Contains a method that helps to find the n-th degree root by Newton's method.
    /// </summary>
    public static class NewtonMethod
    {
        #region Public methods
        /// <summary>
        /// Method to find root with a given accuracy
        /// </summary>
        /// <param name="number">The number from which the root is extracted</param>
        /// <param name="degree">Degree</param>
        /// <param name="accuracy">Aсcuracy</param>
        /// <returns>
        /// Root computed with given accuracy
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If you cannot extract an even root from a negative number
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If Accuracy must be greater than zero and less than one or
        /// Degree must be greater than zero
        /// </exception>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            CheckDate(number, degree, accuracy);

            double current = number / degree;
            double previous = (1 / (double)degree) * (((double)degree - 1) * current + number / Math.Pow(current, degree - 1));

            while (Math.Abs(previous - current) > accuracy)
            {
                current = previous;
                previous = (1 / (double)degree) * (((double)degree - 1) * current + number / Math.Pow(current, degree - 1));
            }

            return previous;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Check valid data
        /// </summary>
        /// <param name="number">The number from which the root is extracted</param>
        /// <param name="degree">Degree</param>
        /// <param name="accuracy">Accurecy calculation</param>
        /// <exception cref="ArgumentException">
        /// If you cannot extract an even root from a negative number
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If Accuracy must be greater than zero and less than one or
        /// Degree must be greater than zero
        /// </exception>
        private static void CheckDate(double number, double degree, double accuracy)
        {
            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(accuracy), "Accuracy must be greater than zero and less than one");
            }

            if (degree <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(degree), "Degree must be greater than zero"); 
            }

            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException(nameof(number), "You cannot extract an even root from a negative number");
            }
        }
        #endregion
    }
}
