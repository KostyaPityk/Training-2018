using System;
using Polynomial;
using NUnit.Framework;

namespace Polynomial.Test
{
    [TestFixture]
    public class PolynomialTest
    {
        #region Exceptions
        [TestCase(null)]
        public void PolynimialTest_CheckNullData(double[] coefficent)
        => Assert.Throws(typeof(ArgumentNullException), () => new  Polynomial(coefficent));

        [TestCase(new double[0])]
        public void PolynimialTest_CheckNullLength(double[] coefficent)
        => Assert.Throws(typeof(ArgumentException), () => new Polynomial(coefficent));
        #endregion

        #region Same Power of Polynomial
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 4, 5, 8 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { 0, -1, 8 })]
        public void PolynomialTest_SamePower_PlusTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst + polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 0, 1, 0 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -4, -5, 0 })]
        public void PolynimialTest_SamePower_MinusTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst - polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 4, 10, 22, 20, 16 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -4, -10, -6, -4, 16 })]
        public void PolynomialTest_SamePower_MultiplicationTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst * polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }
        #endregion

        #region Different Power Polynomial
        [TestCase(new double[] { 4, 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 4, 0, 1, 0 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -4, -5, 0 })]
        [TestCase(new double[] { -8, 3, -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -8, 3, -4, -5, 0 })]
        [TestCase(new double[] { -2, -3, 4, 7 }, new double[] { 8, 2, 2, 4, 7 }, new double[] { -8, -4, -5, 0, 0 })]
        public void PolynimialTest_DifferentPower_MinusTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst - polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }

        [TestCase(new double[] { 4, 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 4, 4, 5, 8 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { 0, -1, 8 })]
        [TestCase(new double[] { -8, 3, -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -8, 3, 0, -1, 8 })]
        [TestCase(new double[] { -2, -3, 4, 7 }, new double[] { 8, 2, 2, 4, 7 }, new double[] { 8, 0, -1, 8, 14 })]
        public void PolynimialTest_DifferentPower_PlusTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst + polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }

        [TestCase(new double[] { 4, 2, 3, 4 }, new double[] { 2, 2, 4 }, new double[] { 8, 12, 26, 22, 20, 16 })]
        [TestCase(new double[] { -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -4, -10, -6, -4, 16 })]
        [TestCase(new double[] { -8, 3, -2, -3, 4 }, new double[] { 2, 2, 4 }, new double[] { -16, -10, -30, 2, -6, -4, 16 })]
        [TestCase(new double[] { -2, -3, 4, 7 }, new double[] { 8, 2, 2, 4, 7 }, new double[] { -16, -28, 22, 50, -4, 9, 56, 49 })]
        public void PolynimialTest_DifferentPower_MultiplicationTests(double[] coefficent1, double[] coefficent2, double[] expected)
        {
            Polynomial polynomialFirst = new Polynomial(coefficent1);
            Polynomial polinimialSecond = new Polynomial(coefficent2);
            Polynomial polynomialResult = polynomialFirst * polinimialSecond;

            Assert.AreEqual(new Polynomial(expected), polynomialResult);
        }
        #endregion

        #region Override methods
        [TestCase(new double[] { 5, 4 })]
        [TestCase(new double[] { 7, 1, 5 })]
        public void PolynomialTest_OverridingOperatorEqual(double[] data)
        {
            Polynomial first = new Polynomial(data);
            Polynomial second = new Polynomial(data);
            Polynomial third = new Polynomial(new double[] { 0, 0 });

            Assert.True(first == second);
            Assert.True(first.Equals(second));
            Assert.True(first != third);
        }

        [TestCase(new double[] { 3, 10, 7 }, ExpectedResult = "3*x^2+10*x^1+7")]
        [TestCase(new double[] { 3, 5, 7 }, ExpectedResult = "3*x^2+5*x^1+7")]
        [TestCase(new double[] { -1, 1, 9 }, ExpectedResult = "-1*x^2+1*x^1+9")]
        public string PolynimialTest_ToString(double[] coefficent)
        {
            Polynomial polynomial = new Polynomial(coefficent);
            return polynomial.ToString();
        }

        [TestCase(ExpectedResult = true)]
        public bool PolynomialTest_CheckOverrideGetHashCode()
        {
            Polynomial elementFirst = new Polynomial(new double[] { 7, 5, 9 });
            Polynomial elementSecond = new Polynomial(new double[] { 7, 5, 9 });
            return elementFirst.GetHashCode() == elementFirst.GetHashCode();
        }
        #endregion
    }
}
