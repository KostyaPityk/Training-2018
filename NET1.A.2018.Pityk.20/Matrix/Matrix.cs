using System;
using System.Collections;
using System.Collections.Generic;
using Matrix.Manager;

namespace Matrix
{
    /// <summary>
    /// Base class which represents Matrix
    /// </summary>
    /// <typeparam name="T">Type matrix</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        /// <summary>
        /// Event, triggered when trying to set the value of the matrix
        /// </summary>
        public event EventHandler MatrixChange;

        /// <summary>
        /// Size of matrix
        /// </summary>
        public int Size { get; private set; }
        
        /// <summary>
        /// Matrix
        /// </summary>
        protected T[] matrix;

        /// <summary>
        /// Method event processings
        /// </summary>
        /// <param name="e">Args</param>
        public void OnMatrixChange(EventArgs e)
        {
            MatrixChange?.Invoke(this, e);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Size">Size of matrix</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw, if size less then zero
        /// </exception>
        public Matrix(int Size)
        {
            if (Size < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Size), "can`t be less or equls with zero");
            }

            this.Size = Size;
        }

        /// <summary>
        /// Indexsitor, get and set value in Matrix
        /// </summary>
        /// <param name="row">Row matrix</param>
        /// <param name="column">Column matrix</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throw, if row or column less then zero or more then size matrix
        /// </exception>
        /// <returns>Value in Matrix</returns>
        public virtual T this[int row, int column]
        {
            get
            {
                if (row >= Size || column >= Size || row < 0 || column < 0)
                {
                    throw new ArgumentOutOfRangeException("Check given indexes!");
                }
                return GetValue(row, column);
            }
            set
            {
                SetValue(row, column, value);
                OnMatrixChange(new EventArgs());
            }
        }

        #region Abstract methods

        protected abstract void SetValue(int row, int column, T value);
        protected abstract T GetValue(int row, int column);
        protected abstract IEnumerator<T> GetValidEnumerator();

        #endregion
        public IEnumerator<T> GetEnumerator()
        {
            return GetValidEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Operator sum two matrix
        /// </summary>
        /// <param name="first">First Matrix</param>
        /// <param name="second">Second Matrix</param>
        /// <returns>Sum of the two Matrix</returns>
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second) => new SumOperations<T>().ChooseVisitor(first, second);

    }
}
