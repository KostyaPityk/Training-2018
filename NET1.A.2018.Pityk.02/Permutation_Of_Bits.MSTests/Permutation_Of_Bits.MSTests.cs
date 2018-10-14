using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Permutation_Of_Bits.MSTests
{
    [TestClass]
    public class UnitPermutation_Of_BitsMSTests
    {
        [TestMethod]
        public void Permutation_Of_Bits_SameNumbers_SamePosition_ValidResult()
        {
            int expected = 15;

            int result = Permutation_Of_Bits.InputNumber(15, 15, 0, 0);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Permutation_Of_Bits_DifferentNumbers_SamePosition_ValidResult()
        {
            int expected = 9;

            int result = Permutation_Of_Bits.InputNumber(8, 15, 0, 0);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Permutation_Of_Bits_DifferentNumbers_DifferentPosition_ValidResult()
        {
            int expected = 120;

            int result = Permutation_Of_Bits.InputNumber(8, 15, 3, 8);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Permutation_Of_Bits_SameNumbers_DifferentPosition_ValidResult()
        {
            int expected = 164; 

            int result = Permutation_Of_Bits.InputNumber(20, 20, 3, 8);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Permutation_Of_Bits_First_Position_Bigger_Then_Last_ArgumentOutOfRangeException()
           => Permutation_Of_Bits.InputNumber(15, 15, 25, 2);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Permutation_Of_Bits_SecontIndexOutOfRange_ArgumentOutOfRangeException()
           => Permutation_Of_Bits.InputNumber(15, 15, 10, 50);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Permutation_Of_Bits_Negative_FirstIndex_ArgumentOutOfRangeException()
          => Permutation_Of_Bits.InputNumber(15, 15, -1, 8);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Permutation_Of_Bits_Negative_SecondIndex_ArgumentOutOfRangeException()
          => Permutation_Of_Bits.InputNumber(15, 15, 1, -8);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Permutation_Of_Bits_FirstIndexOutOfRange_ArgumentOutOfRangeException()
          => Permutation_Of_Bits.InputNumber(15, 15, 50, 10);
    }
}
