using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        ///<exception cref="ArgumentException">
        /// if input negative number
        /// </exception>
        public static (int Result, int Time) FindNextBiggerNumber(int number, out int time)
        {
            Stopwatch timeExecution = new Stopwatch();
            timeExecution.Start();

            CheckNumber(number);

            string str = number.ToString();
            List<int> str_int = str.Select(c => (int)char.GetNumericValue(c)).ToList();
            string finish = "";
            List<int> sort_list = new List<int>();
            int max = str_int[str_int.Count - 1];
            int temp = 0;

            for (int j = str_int.Count - 1; j >= 0; j--)
            {
                if (max <= str_int[j])
                {
                    sort_list.Add(str_int[j]);
                    if (j == 0)
                    {
                        continue;
                    }
                    else
                    {
                        temp = str_int[j - 1];
                    }

                    sort_list.Sort();

                    for (int k = 0; k < sort_list.Count; k++)
                    {
                        if (temp < sort_list[k])
                        {
                            temp = sort_list[k];
                            break;
                        }
                    }

                    max = str_int[j];
                }
                else
                {
                    sort_list.Add(str_int[j]);
                    str_int[j] = temp;
                    sort_list.Sort();
                    sort_list.Remove(temp);

                    for (int i = 0; i <= j; i++)
                    {
                        finish += str_int[i];
                    }

                    foreach (var i in sort_list)
                    {
                        finish += i;
                    }

                    break;
                }
            }

            timeExecution.Stop();
            time = timeExecution.Elapsed.Milliseconds;

            if (finish.Length == 0)
            {
                return (-1, time);
            }
            else
            {
                return (Convert.ToInt32(finish), time);
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
