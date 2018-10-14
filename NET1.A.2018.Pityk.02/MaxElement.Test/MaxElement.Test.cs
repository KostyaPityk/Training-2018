using System;
using NUnit.Framework;

namespace MaxElement.Test
{
    [TestFixture]
    public class MaxElementTest
    {
        [TestCase(new[] { 1, 2, 3, 56 }, ExpectedResult = 56)]
        [TestCase(new[] { 11, 2, 3, 5 }, ExpectedResult = 11)]
        [TestCase(new[] { 4, 3, 5, 1 }, ExpectedResult = 5)]
        [TestCase(new[] { 17, 19, 4, 1 }, ExpectedResult = 19)]
        [TestCase(new[] { 1, 2, 3, 0 }, ExpectedResult = 3)]
        public int? MaxElement_ValidData_ValidResult(int[]  array)
            => MaxElement.SearchMaxElement(array);
            
        [Test]
        public void MaxElement_ArrayIsNull_ArgumentNullException()
            => Assert.Throws(typeof(ArgumentNullException), () => MaxElement.SearchMaxElement(null));
    }
}
