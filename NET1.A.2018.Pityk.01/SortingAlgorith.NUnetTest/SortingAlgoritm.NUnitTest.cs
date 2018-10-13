using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SortingAlgorithm;

namespace SortingAlgorith.NUnetTest
{
    [TestFixture]
    public class SortingAlgoritmNUnitTest
    {
        #region MergeSort Tests

        [Test]
        public void MergeSortTest_SortFullRandomArray()
        {
            int[] value = Enumerable.Range(0, 100).Reverse().ToArray();

            int[] expected = value.Reverse().ToArray();

            SortingAlgorithm.SortingAlgorithm.MergeSort(value);

            CollectionAssert.AreEqual(value, expected);
        }

        [Test]
        public void MergeSortTest_SortFullDefinedArray()
        {
            int[] value = new[] { -10, 0, 3, -11, 2, 7, 12 };

            int[] expected = new[] { -11, -10, 0, 2, 3, 7, 12 };

            SortingAlgorithm.SortingAlgorithm.MergeSort(value);

            CollectionAssert.AreEqual(value, expected);
        }

        [Test]
        public void MergeSortTest_InvalidArray_ArgumentNullException()
            => Assert.Throws(typeof(ArgumentNullException), () => SortingAlgorithm.SortingAlgorithm.MergeSort(null));
        #endregion

        #region Qsort Tests

        [Test]
        public void QsortTest_SortFullDefinedArray()
        {
            int[] value = new[] { -10, 0, 3, -11, 2, 7, 12 };

            int[] expected = new[] { -11, -10, 0, 2, 3, 7, 12 };

            SortingAlgorithm.SortingAlgorithm.Qsort(value, 0, value.Length - 1);

            CollectionAssert.AreEqual(value, expected);
        }

        [Test]
        public void QsortTest_SortFullRandomArray()
        {
            int[] value = Enumerable.Range(0, 100).Reverse().ToArray();

            int[] expected = value.Reverse().ToArray();

            SortingAlgorithm.SortingAlgorithm.Qsort(value, 0, value.Length - 1);

            CollectionAssert.AreEqual(value, expected);
        }

        [Test]
        public void QsortTest_InvalidArray_ArgumentNullException()
            => Assert.Throws(typeof(ArgumentNullException), () => SortingAlgorithm.SortingAlgorithm.Qsort(null, 0, 5)); 

        [Test]
        public void QsortTestInvalidArray_ArgumentOutOfRangeException()
            => Assert.Throws(typeof(ArgumentOutOfRangeException), () => SortingAlgorithm.SortingAlgorithm.Qsort(new int[] { 1, 2, 3 }, 30, 5)); 

        #endregion

        #region Big array

        [Test]
        public void MergeSortBigRandomArray()
        {

            Random randomKey = new Random();

            int[] array = Enumerable.Range(-500000, 1000000).OrderBy(x => randomKey.Next()).ToArray();

            int[] expected = new int[array.Length];

            Array.Copy(array, expected, array.Length);
            Array.Sort(expected);

            SortingAlgorithm.SortingAlgorithm.MergeSort(array);

            CollectionAssert.AreEqual(array, expected);
        }

        [Test]
        public void QsortBigRandomArray()
        {
            Random randomKey = new Random();

            int[] array = Enumerable.Range(-500000, 1000000).OrderBy(x => randomKey.Next()).ToArray();

            int[] expected = new int[array.Length];

            Array.Copy(array, expected, array.Length);
            Array.Sort(expected);

            SortingAlgorithm.SortingAlgorithm.Qsort(array, 0, array.Length - 1);

            CollectionAssert.AreEqual(array, expected);
        }
        #endregion

    }
}
