using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Filter;
using System.Linq;
using System.Collections.Generic;

namespace Filter.MSTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void Filter_ValidDigit_ValidResult()
        {
            int value = 3;
            int[] array = { 35, 132, 13, 52, 53, 0, 10 };
            int[] expected = { 35, 132, 13, 53 };

            IEnumerable<int> result = Filter.FilterDigit(array, value);

            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void Filter_ValidDigitButNoMatches_ResultEmptyArray()
        {
            int value = 5;
            int[] array = { 1, 2, 3, 4 };
            int[] expected = { };

            IEnumerable<int> result = Filter.FilterDigit(array, value);

            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod]
        public void Filter_AllValidDigitContainsTemplateDigit_ResultAllArray()
        {
            int value = 5;
            int[] array = { 15, 35, 52, 55 };
            int[] expected = { 15, 35, 52, 55 };

            IEnumerable<int> result = Filter.FilterDigit(array, value);

            CollectionAssert.AreEqual(expected, result.ToArray());
        }
    }
}
