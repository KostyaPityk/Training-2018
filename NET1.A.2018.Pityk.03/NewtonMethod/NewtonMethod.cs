using System;

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
        public static double FindNthRoot(double number, double degree, double accuracy)
        {
            CheckDate(number, degree, accuracy);

            double x0 = number / degree;
            double x1 = (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            return x1;
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
