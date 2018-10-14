using System;
using System.Diagnostics;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Filter.NUnitTests
{
    [TestFixture]
    public class FilterNUnitTests
    {
        public static IEnumerable<TestCaseData> Context()
        {
            yield return new TestCaseData(new int[] { 2, 5, 35, 55, 75 }, new int[] { 5, 35, 55, 75 }, 5);
            yield return new TestCaseData(new int[] { 2, 5, 35, 55, 75 }, new int[] { }, 1);
            yield return new TestCaseData(new int[] { 5, 25, 35, 55, 75 }, new int[] { 5, 25, 35, 55, 75 }, 5);
        }

        [TestCaseSource("Context")]
        public void Filter_ValidDigit_ValidResult(int[] array, int[] expected, int value)
        {
            IEnumerable<int> result = Filter.FilterDigit(array, value);

            CollectionAssert.AreEqual(expected, result.ToArray());
        }
    }
}
