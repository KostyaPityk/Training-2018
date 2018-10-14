using System;
using NUnit.Framework;

namespace StringConcatenation.Test
{
    [TestFixture]
    public class StringConcatenationTest
    {
        [TestCase("kos", "kostya", ExpectedResult = "kostya")]
        [TestCase("stas", "sstaik", ExpectedResult = "stasik")]
        [TestCase("Hello", "Hell", ExpectedResult = "Hello")]
        [TestCase("Team", "Work", ExpectedResult = "TeamWork")]
        [TestCase("AAAA", "bbbb", ExpectedResult = "AAAAbbbb")]
        public string Concatenation_ValidData_ValidResult(string first, string second)
            => StringConcatenation.Concatenation(first, second);

        [Test]
        public void Concatenation_First_String_IsNotValid_ArgumentException()
            => Assert.Throws(typeof(ArgumentException), () => StringConcatenation.Concatenation("ss11", "ss"));

        [Test]
        public void Concatenation_Second_String_IsNotValid_ArgumentException()
            => Assert.Throws(typeof(ArgumentException), () => StringConcatenation.Concatenation("ss", "ss111"));

        [Test]
        public void Concatenation_First_String_IsNull_ArgumentNullException()
            => Assert.Throws(typeof(ArgumentNullException), () => StringConcatenation.Concatenation(null, "ss"));

        [Test]
        public void Concatenation_Second_String_IsNull_ArgumentNullException()
            => Assert.Throws(typeof(ArgumentNullException), () => StringConcatenation.Concatenation("ss", null));
    }
}
