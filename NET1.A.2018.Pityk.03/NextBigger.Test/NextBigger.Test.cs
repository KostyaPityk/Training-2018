using System;
using NUnit.Framework;

namespace NextBigger.Test
{
    [TestFixture]
    public class NextBiggerTest
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int BiggerNumber_ValidData_ValidResult(int number)
            => NextBigger.FindNextBiggerNumber(number, out _).Result;

        [TestCase]
        public void CheckTimeFromOut()
        {
            int timeFromOut;
            int timeFromTuple = NextBigger.FindNextBiggerNumber(12345413, out timeFromOut).Time;
            Assert.AreEqual(timeFromOut, timeFromTuple);
        }
    }
}