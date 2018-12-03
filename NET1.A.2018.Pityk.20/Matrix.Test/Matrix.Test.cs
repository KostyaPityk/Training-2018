using System;
using NUnit.Framework;

namespace Matrix.Test
{
    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public void TestSum_SquareAndDiagonal_Matrix()
        {
            SquareMatrix<int> square = new SquareMatrix<int>(2);
            square[0, 0] = 1;
            square[0, 1] = 2;
            square[1, 0] = 3;
            square[1, 1] = 4;

            DiagonalMatrix<int> diagonal = new DiagonalMatrix<int>(2);
            diagonal[0, 0] = 1;
            diagonal[1, 1] = 1;

            SquareMatrix<int> result = diagonal + square as SquareMatrix<int>;

            SquareMatrix<int> expected = new SquareMatrix<int>(2);
            expected[0, 0] = 2;
            expected[0, 1] = 2;
            expected[1, 0] = 3;
            expected[1, 1] = 5;

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void TestSum_SquareAndSymmetric_Matrix()
        {
            SquareMatrix<int> square = new SquareMatrix<int>(2);
            square[0, 0] = 1;
            square[0, 1] = 2;
            square[1, 0] = 3;
            square[1, 1] = 4;

            SymmetricMatrix<int> symmetric = new SymmetricMatrix<int>(2);
            symmetric[0, 0] = 1;
            symmetric[0, 1] = 1;
            symmetric[1, 1] = 1;

            SquareMatrix<int> result = symmetric + square as SquareMatrix<int>;

            SquareMatrix<int> expected = new SquareMatrix<int>(2);
            expected[0, 0] = 2;
            expected[0, 1] = 3;
            expected[1, 0] = 4;
            expected[1, 1] = 5;

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_ExceprionFromDiagonalMatrix()
        {
            TestDelegate test = () =>
            {
                DiagonalMatrix<int> diagonal = new DiagonalMatrix<int>(2);
                diagonal[0, 1] = 3;
            };


            Assert.Throws(typeof(ArgumentException), test);
        }

        [Test]
        public void Test_ExceprionFromOutOfRange()
        {
            TestDelegate test = () =>
            {
                SquareMatrix<int> diagonal = new SquareMatrix<int>(2);
                int result = diagonal[17, 3];
            };

            Assert.Throws(typeof(ArgumentOutOfRangeException), test);
        }
    }
}
