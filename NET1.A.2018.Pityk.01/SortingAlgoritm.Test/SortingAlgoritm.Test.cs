using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithm;
using System.Linq;
using System.Collections.Generic;

namespace SortingAlgorithm.Test
{
    [TestClass]
    public class TestSortAlgorithms
    {
        #region MergeSort Tests

        [TestMethod]
        public void MergeSortTest_SortFullRandomArray()
        {
            int[] value = Enumerable.Range(0, 100).Reverse().ToArray();

            int[] expected = value.Reverse().ToArray();

            SortingAlgorithm.MergeSort(value);

            CollectionAssert.Equals(value, expected);
        }

        [TestMethod]
        public void MergeSortTest_SortFullDefinedArray()
        {
            int[] value = new[] { -10, 0, 3, -11, 2, 7, 12 };

            int[] expected = new[] { -11, -10, 0, 2, 3, 7, 12 };

            SortingAlgorithm.MergeSort(value);

            CollectionAssert.Equals(value, expected);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortTest_InvalidArray_ArgumentNullException()
            => SortingAlgorithm.MergeSort(null);
        #endregion

        #region Qsort Tests

        [TestMethod]
        public void QsortTest_SortFullDefinedArray()
        {
            int[] value = new[] { -10, 0, 3, -11, 2, 7, 12 };

            int[] expected = new[] { -11, -10, 0, 2, 3, 7, 12 };

            SortingAlgorithm.Qsort(value, 0, value.Length - 1);

            CollectionAssert.Equals(value, expected);
        }

        [TestMethod]
        public void QsortTest_SortFullRandomArray()
        {
            int[] value = Enumerable.Range(0, 100).Reverse().ToArray();

            int[] expected = value.Reverse().ToArray();

            SortingAlgorithm.Qsort(value, 0, value.Length - 1);

            CollectionAssert.Equals(value, expected);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QsortTest_InvalidArray_ArgumentNullException()
            => SortingAlgorithm.Qsort(null, 0, 5);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void QsortTestInvalidArray_ArgumentOutOfRangeException()
            => SortingAlgorithm.Qsort(new int[] { 1, 2, 3 }, 30, 5);
        #endregion

        #region Big array

        [TestMethod]
        public void MergeSortBigRandomArray()
        {

            Random randomKey = new Random();

            int[] array = Enumerable.Range(-500000, 1000000).OrderBy(x => randomKey.Next()).ToArray();

            int[] expected = new int[array.Length];

            Array.Copy(array, expected, array.Length);
            Array.Sort(expected);

            SortingAlgorithm.MergeSort(array);

            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void QsortBigRandomArray()
        {
            Random randomKey = new Random();

            int[] array = Enumerable.Range(-500000, 1000000).OrderBy(x => randomKey.Next()).ToArray();

            int[] expected = new int[array.Length];

            Array.Copy(array, expected, array.Length);
            Array.Sort(expected);

            SortingAlgorithm.Qsort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(array, expected);
        }
        #endregion
    }
}
