using System;
using System.Linq;
using NUnit.Framework;

namespace JaggedArray.Test
{
    [TestFixture]
    public class JaggedArrayTest
    {
        [TestCase(null)]
        public void PolynimialTest_CheckNullData(int[][] coefficent)
        => Assert.Throws(typeof(ArgumentNullException), () => coefficent.Sort(new CompareBySumElementDescending()));

        #region Descending
        [Test]
        public void TestSort_MaxElementDescendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareByMaxElementDescending());
                if (!IsSortedByKeyDescending(array, Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }

        [Test]
        public void TestSort_MinElementDescendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareByMinElementDescending());
                if (!IsSortedByKeyDescending(array, Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }

        [Test]
        public void TestSort_SumElementDescendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareBySumElementDescending());
                if (!IsSortedByKeyDescending(array, Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }
        #endregion

        #region Ascending
        [Test]
        public void TestSort_MaxElementAscendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareByMaxElementAscending());
                if (!IsSortedByKeyAscending(array, Enumerable.Max))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }

        [Test]
        public void TestSort_MinElementAscendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareByMinElementAscending());
                if (!IsSortedByKeyAscending(array, Enumerable.Min))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }

        [Test]
        public void TestSort_SumElementAscendingComparer_Random100ValidValue_ValueResult()
        {
            Random random_value = new Random(0);
            const int SIZE = 100;
            for (int i = 0; i < SIZE; i++)
            {
                int[][] array = CreateRandomArray(SIZE, random_value);

                array.Sort(new CompareBySumElementAscending());
                if (!IsSortedByKeyAscending(array, Enumerable.Sum))
                {
                    Assert.Fail($"Test #{i} fail.");
                }
            }
        }
        #endregion
        #region Private methods
        private int[][] CreateRandomArray(int size, Random rng)
        {
            int[][] array = new int[size][];

            for (int j = 0; j < size; j++)
            {
                array[j] = new int[rng.Next(1, size)];
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rng.Next(-size, size);
                }
            }

            return array;
        }
        private static bool IsSortedByKeyDescending(int[][] array, Func<int[], int> key)
        {
            int[] correct_result = array.Select(key).ToArray();
            for (int i = 0; i < correct_result.Length - 1; i++)
            {
                if (correct_result[i] < correct_result[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSortedByKeyAscending(int[][] array, Func<int[], int> key)
        {
            int[] correct_result = array.Select(key).ToArray();
            for (int i = 0; i < correct_result.Length - 1; i++)
            {
                if (correct_result[i] > correct_result[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
