using System;
using NUnit.Framework;

namespace NewtonMethod.NUnitTest
{
    [TestFixture]
    public class NewtonMethodNUnitTest
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.22)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void NewtonMethod_ValidData_ValidResult(double number, double degree, double accuracy, double expected)
        {
            double result = NewtonMethod.FindNthRoot(number, degree, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [Test]
        public void NewtonMethod_InvalidDataNegativeNumberAndEvenDegree_ArgumentException() =>
            Assert.Throws(typeof(ArgumentException), () => NewtonMethod.FindNthRoot(-2, 2, 0.01));

        [Test]
        public void NewtonMethod_InvalidDataDegreeLessThenZero_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => NewtonMethod.FindNthRoot(0.001, -2, 0.001));

        [Test]
        public void NewtonMethod_InvalidDataAccurecyLessThenZero_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => NewtonMethod.FindNthRoot(0.01, 2, -1));

        public void NewtonMethod_InvalidDataAccurecyMoreThenOne_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => NewtonMethod.FindNthRoot(0.01, 2, 15));
    }
}
