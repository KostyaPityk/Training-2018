using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciGenerator
{
    /// <summary>
    /// Represent funktion to calculate fibonacci numbers
    /// </summary>
    public static class FibonacciGenerator
    {
        /// <summary>
        /// Calculates the Fibonacci sequence
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>IEnumerable of fibonacci numbers</returns>
        /// <exception cref="ArgumentException">
        /// Throw if numbers less or equls zero
        /// </exception>
        public static IEnumerable<int> Fibonacci(int number)
        {
            CheckData(number);

            yield return 0;

            int first_number = 0;
            int second_number = 1;

            for (int i = 0; i < number; i++)
            {  
               
                ChangeNumbers(ref first_number, ref second_number);
                yield return first_number;
            }
        }

        private static void CheckData(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException(nameof(number), "can`t be less or equls zero");
            }
        }

        private static void ChangeNumbers(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second += temp;
        }
    }
}
