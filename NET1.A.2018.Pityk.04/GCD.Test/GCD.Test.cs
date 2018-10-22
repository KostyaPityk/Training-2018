using System;
using NUnit.Framework;

namespace GCD.Test
{
    [TestFixture]
    public class GCDTest
    {
        #region Test from two elements
        [TestCase(10, 100, ExpectedResult = 10)]
        [TestCase(36, 90, ExpectedResult = 18)]
        [TestCase(39, 130, ExpectedResult = 13)]
        [TestCase(-5, 90, ExpectedResult = 5)]
        [TestCase(100, 20, ExpectedResult = 20)]
        public int EucideanTests_TwoElementsValidData_ValidResult(int first, int second)
        {
            return GCD.EuclidGCD(out _, first, second);
        }

        [TestCase(10, 100, ExpectedResult = 10)]
        [TestCase(36, 90, ExpectedResult = 18)]
        [TestCase(39, 130, ExpectedResult = 13)]
        [TestCase(-5, 90, ExpectedResult = 5)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(0, 10000, ExpectedResult = 10000)]
        public int SteinTests_TwoElementsValidData_ValidResult(int first, int second)
        {
            return GCD.SteinGDC(out _, first, second);
        }

        #endregion

        #region Test from three elements
        [TestCase(10, 100, -50, ExpectedResult = 10)]
        [TestCase(36, 90, 216, ExpectedResult = 18)]
        [TestCase(39, 130, 52, ExpectedResult = 13)]
        [TestCase(-5, 90, 35, ExpectedResult = 5)]
        [TestCase(100, 20, 60, ExpectedResult = 20)]
        public int EucideanTests_ThreeElementsValidData_ValidResult(int first, int second, int third)
        {
            return GCD.EuclidGCD(out _, first, second, third);
        }

        [TestCase(10, 100, -50, ExpectedResult = 10)]
        [TestCase(36, 90, 216, ExpectedResult = 18)]
        [TestCase(39, 130, 52, ExpectedResult = 13)]
        [TestCase(-5, 90, 35, ExpectedResult = 5)]
        [TestCase(0, 1, 2, ExpectedResult = 1)]
        [TestCase(0, 0, 10000, ExpectedResult = 10000)]
        public int SteinTests_ThreeElementsValidData_ValidResult(int first, int second, int third)
        {
            return GCD.SteinGDC(out _, first, second, third);
        }

        #endregion

        #region Test from four elements
        [TestCase(10, 100, -50, 30, ExpectedResult = 10)]
        [TestCase(36, 90, 216, 72, ExpectedResult = 18)]
        [TestCase(39, 130, 52, 156, ExpectedResult = 13)]
        [TestCase(-5, 90, 35, -95, ExpectedResult = 5)]
        public int EucideanTests_FourElementsValidData_ValidResult(int first, int second, int third, int four)
        {
            return GCD.EuclidGCD(out _, first, second, third, four);
        }

        [TestCase(10, 100, -50, 30, ExpectedResult = 10)]
        [TestCase(36, 90, 216, 72, ExpectedResult = 18)]
        [TestCase(39, 130, 52, 156, ExpectedResult = 13)]
        [TestCase(-5, 90, 35, -95, ExpectedResult = 5)]
        public int SteinTests_FourElementsValidData_ValidResult(int first, int second, int third, int four)
        {
            return GCD.SteinGDC(out _, first, second, third, four);
        }
        #endregion

        #region Test from five elements
        [TestCase(10, 100, -50, 30, -70, ExpectedResult = 10)]
        [TestCase(36, 90, 216, 72, 252, ExpectedResult = 18)]
        public int EucideanTests_FiveElementsValidData_ValidResult(int first, int second, int third, int four, int five)
        {
            return GCD.EuclidGCD(out _, first, second, third, four, five);
        }

        [TestCase(10, 100, -50, 30, -70, ExpectedResult = 10)]
        [TestCase(36, 90, 216, 72, 252, ExpectedResult = 18)]
        public int SteinTests_FiveElementsValidData_ValidResult(int first, int second, int third, int four, int five)
        {
            return GCD.SteinGDC(out _, first, second, third, four, five);
        }
        #endregion

        #region Exceptions
        [TestCase]
        public void SteinTests_LessThenThowElements_ArgumentException()
           => Assert.Throws(typeof(ArgumentException), () => GCD.SteinGDC(out _, 1));

        [TestCase]
        public void SteinTests_EmptyArray_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => GCD.SteinGDC(out _, null));

        [TestCase]
        public void EucideanTests_LessThenThowElements_ArgumentException()
           => Assert.Throws(typeof(ArgumentException), () => GCD.EuclidGCD(out _, 1));

        [TestCase]
        public void EucideanTests_EmptyArray_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => GCD.EuclidGCD(out _, null));
        #endregion
    }
}
