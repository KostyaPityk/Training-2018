using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Manager
{
    /// <summary>
    /// Represent methods to get sum two matrix with specific type
    /// </summary>
    /// <typeparam name="T">Type matrix</typeparam>
    public class SumOperations<T> : MatrixVisitor<T>
    {
        protected override SquareMatrix<T> Visit(Matrix<T> first, Matrix<T> second)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(first.Size);
            return Summator<T>.GetSum(first, second, result) as SquareMatrix<T>;
        }

        protected override DiagonalMatrix<T> Visit(DiagonalMatrix<T> first, DiagonalMatrix<T> second)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(first.Size);
            return Summator<T>.GetSum(first, second, result) as DiagonalMatrix<T>;
        }

        protected override SymmetricMatrix<T> Visit(SymmetricMatrix<T> first, SymmetricMatrix<T> second)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(first.Size);
            return Summator<T>.GetSum(first, second, result) as SymmetricMatrix<T>;
        }
    }
}
