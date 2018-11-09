using System;
using System.Linq;
using NUnit.Framework;

namespace FibonacciGenerator.Test
{
    [TestFixture]
    public class FibonacciGeneratorTest
    {
        [TestCase(40, new  long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155 })]
        [TestCase(1, new long[] { 0, 1 })]
        [TestCase(20, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 })]
        [TestCase(30, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040 })]
        [TestCase(15, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 })]
        [TestCase(22, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711 })]
        [TestCase(5, new long[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(9, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        [TestCase(35, new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465 })]
        public void FidonacciGeneratorTest_ValidData_ValidResult(int number, long[] expected)
        {
            var result = FibonacciGenerator.Fibonacci(number).ToArray();
            CollectionAssert.AreEqual(result, expected);
        }

        [TestCase(0)]
        [TestCase(-33)]
        public void FidonacciGeneratorTest_InvalidData_ResultException(int number)
            => Assert.Throws(typeof(ArgumentException), () => FibonacciGenerator.Fibonacci(number));
    }
}
