using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Manager
{
    /// <summary>
    /// Base class for get sum two matrix with specific type
    /// </summary>
    /// <typeparam name="T">Matrix type</typeparam>
    public abstract class MatrixVisitor<T>
    {
        protected abstract SquareMatrix<T> Visit(Matrix<T> first, Matrix<T> second);
        protected abstract DiagonalMatrix<T> Visit(DiagonalMatrix<T> first, DiagonalMatrix<T> second);
        protected abstract SymmetricMatrix<T> Visit(SymmetricMatrix<T> first, SymmetricMatrix<T> second);

        //protected abstract DiagonalMatrix<T> Visit(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs);
        //protected abstract DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs);

        public Matrix<T> ChooseVisitor(Matrix<T> first, Matrix<T> second)
        {
            return Visit((dynamic)first, (dynamic)second);
        }

    }
}
