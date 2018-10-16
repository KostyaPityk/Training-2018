using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NextBigger
{
    /// <summary>
    /// Represents methods to evaluate next bigger number based on digits
    /// of given number. Contains methods to get time of execution. 
    /// </summary>
    public class NextBigger
    {
        /// <summary>
        /// Get valid result of executing FindNextBiggerNumber
        /// and value of time.
        /// </summary>
        /// <param name="number">Number to be explored</param>
        /// <param name="time">Time of execution in miliseconds</param>
        /// <returns>
        /// Valid result of searching number and time of executing program in ValueTuple item
        /// and using out paramaters
        /// </returns>
        /// <exception cref="ArgumentException">
        /// if input negative number
        /// </exception>
        public static (int Result, int Time) FindNextBiggerNumber(int number, out int time)
        {
            Stopwatch timeExecution = new Stopwatch();
            timeExecution.Start();

            CheckNumber(number);

            string number_string = number.ToString();
            List<int> array = number_string.Select(c => (int)char.GetNumericValue(c)).ToList();
            List<int> sort_array = new List<int>();
          
            int max = array[array.Count - 1];
            int temp = 0;
            string result = string.Empty;

            for (int j = array.Count - 1; j >= 0; j--)
            {
                if (max <= array[j])
                {
                    sort_array.Add(array[j]);

                    if (j == 0)
                    {
                        continue;
                    }
                    else
                    {
                        temp = array[j - 1];
                    }

                    for (int k = 0; k < sort_array.Count; k++)
                    {
                        if (temp < sort_array[k])
                        {
                            temp = sort_array[k];
                            break;
                        }
                    }

                    max = array[j];
                }
                else
                {
                    sort_array.Add(array[j]);
                    array[j] = temp;
                    sort_array.Sort();
                    sort_array.Remove(temp);

                    for (int i = 0; i <= j; i++)
                    {
                        result += array[i];
                    }

                    foreach (var i in sort_array)
                    {
                        result += i;
                    }

                    break;
                }
            }

            timeExecution.Stop();
            time = timeExecution.Elapsed.Milliseconds;

            if (result.Length == 0)
            {
                return (-1, time);
            }
            else
            {
                return (Convert.ToInt32(result), time);
            }
        }

        /// <summary>
        /// Check number to given rules (number should be GT or equal to zero)
        /// </summary>
        /// <param name="number">Number to be checked</param>
        private static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Your number is negative number!");
            }
        }
    }
}