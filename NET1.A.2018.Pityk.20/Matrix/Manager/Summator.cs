using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Manager
{
    /// <summary>
    /// Repreents summator of two matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Summator<T>
    {
        /// <summary>
        /// Sum of two matrix
        /// </summary>
        /// <param name="first">First matrix</param>
        /// <param name="second">Second matrix</param>
        /// <param name="result">Result matrix</param>
        /// <returns>Sum matrix</returns>
        public static Matrix<T> GetSum(Matrix<T> first, Matrix<T> second, Matrix<T> result)
        {
            for (int i = 0; i < first.Size; i++)
            {
                for (int j = 0; j < first.Size; j++)
                {
                    result[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                }
            }

            return result;
        }
    }
}
