using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Permutation_Of_Bits.NUnitTests
{
    [TestFixture]
    public class Permutation_Of_BitsNUnitTests
    {
        public static IEnumerable<TestCaseData> Source()
        {
            yield return new TestCaseData(8, 15, 0, 0, 9);
            yield return new TestCaseData(8, 15, 3, 8, 120);
            yield return new TestCaseData(15, 15, 0, 0, 15);
            yield return new TestCaseData(20, 20, 3, 8, 164);
            yield return new TestCaseData(3, 19, 2, 4, 15);
        }

        [TestCaseSource("Source")]
        public void Permutation_Of_Bits_ValidData_ValidResult(int firstNumber, int secondNumber, int i, int j, int expected)
        {
            int result = Permutation_Of_Bits.InputNumber(firstNumber, secondNumber, i, j);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Permutation_Of_Bits_First_Position_Bigger_Then_Last_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Permutation_Of_Bits.InputNumber(15, 15, 25, 2));

        [Test]
        public void Permutation_Of_Bits_SecontIndexOutOfRange_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Permutation_Of_Bits.InputNumber(15, 15, 10, 50));

        [Test]
        public void Permutation_Of_Bits_Negative_FirstIndex_ArgumentOutOfRangeException() =>
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Permutation_Of_Bits.InputNumber(15, 15, -1, 8));
    }
}
