using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    /// <summary>
    /// Represents Deagonal matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int Size) : base(Size) => matrix = new T[Size];

        /// <summary>
        /// Enumerator matrix
        /// </summary>
        /// <returns>Value of matrix</returns>
        protected override IEnumerator<T> GetValidEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                    {
                        yield return default(T);
                    }
                    else
                    {
                        yield return matrix[i];
                    }
                }
            }
        }

        /// <summary>
        /// Get value of matrix
        /// </summary>
        /// <param name="row">Row matrix</param>
        /// <param name="column">Column matrix</param>
        /// <returns>Value of matrix</returns>
        protected override T GetValue(int row, int column)
        {
            if (row != column)
            {
                return default(T);
            }

            return matrix[row];
        }

        /// <summary>
        /// Set value of matrix
        /// </summary>
        /// <param name="row">Row matrix</param>
        /// <param name="column">Column matrix</param>
        /// <param name="value">Value</param>
        /// <exception cref="ArgumentException">
        /// Trow, if column not equals row
        /// </exception>
        protected override void SetValue(int row, int column, T value)
        {
            if (row != column)
            {
                throw new ArgumentException("Invalid postition!");
            }

            matrix[row] = value;
        }
    }
}
