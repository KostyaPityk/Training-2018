using System;
using System.Diagnostics;

namespace GCD
{
    /// <summary>
    /// Represents algorithms for evaluating 
    /// Greatest Common Divisor (GCD). Includes two methods for evaluating GDC
    /// </summary>
    public static class GCD
    {
        #region Public methods
        /// <summary>
        /// Represents algorithm of Euclid for evaluation GDC for 2 numbers
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <returns>GDC of given numbers</returns>
        public static int Euclidean(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            while (first != second)
            {
                if (first > second)
                {
                    first = first - second;
                }
                else
                {
                    second = second - first;
                }
            }

            return first;
        }

        /// <summary>
        /// Represents algorithm of Stein for evaluation GDC for 2 numbers
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <returns>GDC of given numbers</returns>
        public static int Stein(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

            if (first == second)
            {
                return first;
            }

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if ((~first & 1) != 0)
            {
                if ((second & 1) != 0)
                {
                    return Stein(first >> 1, second);
                }
                else
                {
                    return Stein(first >> 1, second >> 1) << 1;
                }
            }

            if ((~second & 1) != 0)
            {
                return Stein(first, second >> 1);
            }

            if (first > second)
            {
                return Stein((first - second) >> 1, second);
            }

            return Stein((second - first) >> 1, first);
        }

        /// <summary>
        /// Represents algorithm of Euclid for evaluation GDC for third numbers
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <returns>GDC of given numbers</returns>
        public static int Euclidean(int first, int second, int third)
            => Euclidean(Euclidean(first, second), third);

        /// <summary>
        /// Represents algorithm of Stein for evaluation GDC for third numbers
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="third">Third number</param>
        /// <returns>GDC of given numbers</returns>
        public static int Srein(int first, int second, int third)
            => Stein(Stein(first, second), third);

        /// <summary>
        /// Represents method of evaluating GDC using Euclidean algorithm. Receive arbitrary arguments.
        /// </summary>
        /// <param name="time">Time of execution in milliseconds</param>
        /// <param name="numbers">Numbers</param>
        /// <returns>GDC for given data and time work</returns>
        public static int EuclidGCD(out int time_Milliseconds, params int[] numbers)
        {
            CheckFromNull(numbers);
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int GDC = Euclidean(numbers);

            timer.Stop();

            time_Milliseconds = timer.Elapsed.Milliseconds;
            return GDC;
        }

        /// <summary>
        /// Represents method of evaluating GDC using Stein algorithm. Receive arbitrary arguments.
        /// </summary>
        /// <param name="time">Time of execution in milliseconds</param>
        /// <param name="numbers">Numbers</param>
        /// <returns>GDC for given data and time work</returns>
        public static int SteinGDC(out int time_Milliseconds, params int[] numbers)
        {
            CheckFromNull(numbers);
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int GDC = Stein(numbers);

            timer.Stop();

            time_Milliseconds = timer.Elapsed.Milliseconds;
            return GDC;
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Represents algorithm of Euclidean for evaluation GDC 
        /// </summary>
        /// <param name="numbers">First number</param>
        /// <returns>GDC of given numbers</returns>
        private static int Euclidean(params int[] numbers)
        {
            int GDC = Euclidean(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                GDC = Euclidean(GDC, numbers[i]);
            }

            return GDC;
        }

        /// <summary>
        /// Represents algorithm of Stein for evaluation GDC 
        /// </summary>
        /// <param name="numbers">First number</param>
        /// <returns>GDC of given numbers</returns>
        private static int Stein(params int[] numbers)
        {
            int GDC = Stein(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                GDC = Stein(GDC, numbers[i]);
            }

            return GDC;
        }

        /// <summary>
        /// Check from Null
        /// </summary>
        /// <param name="numbers">Check array</param>
        /// <exception cref="ArgumentNullException">
        /// Raises if given arguments represents as empty array
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Raises if given arguments represents as array with length less 2
        /// </exception>
        private static void CheckFromNull(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "There is no data to evaluate");
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException(nameof(numbers), "Check your data(can't be less than two numbers)");
            }
        }
        #endregion
    }
}
