using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        public SymmetricMatrix(int Size) : base(Size) => matrix = new T[Size * Size];

        /// <summary>
        /// Enumerator matrix
        /// </summary>
        /// <returns>Value of matrix</returns>
        protected override IEnumerator<T> GetValidEnumerator()
        {
            foreach (T item in matrix)
            {
                yield return item;
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
            return matrix[(row * Size) + column];
        }

        /// <summary>
        /// Set value of matrix
        /// </summary>
        /// <param name="row">Row matrix</param>
        /// <param name="column">Column matrix</param>
        /// <param name="value">Value</param>
        protected override void SetValue(int row, int column, T value)
        {
            matrix[(row * Size) + column] = value;

            if (row != column)
            {
                matrix[(column * Size) + row] = value;
            }
        }
    }
}
