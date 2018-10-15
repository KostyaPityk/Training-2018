using System;
using NUnit.Framework;

namespace SearchInArray.Test
{
    [TestFixture]
    public class SearchInArrayTest
    {
        [TestCase(new[] { 1.52, 4.13, 3, 1, 2, 9.65 }, ExpectedResult = 4)]
        [TestCase(new[] { 11.5, 2.1, 3.85, 5.32 }, ExpectedResult = -1)]
        [TestCase(new[] { 4.31, 3.58, 5, 7.89 }, ExpectedResult = 2)]
        [TestCase(new double[] { 17.5, 19.2, 1.1, 4.0, 15.5, 12.2, 10.1 }, ExpectedResult = 3)]
        [TestCase(new double[] { 1.0, 2.0, 3.0, 8.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 5.5, 9.1566, 3.25, 3.25 }, ExpectedResult = 2)]
        public int SearchInArray_ValidData_ValidResult(double[] array)
           => SearchInArray.SearchIndex(array);

        [Test]
        public void SearchInArray_ArrayIsNull_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => SearchInArray.SearchIndex(null));
    }
}
