using System;
using System.Collections.Generic;
using NUnit.Framework;
using Filter;

namespace FilterTest
{
    [TestFixture]
    public class FilterTest
    {
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, 3, new string[] { "one", "two" })]
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, 5, new string[] { "three" })]
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, 4, new string[] { "four", "five" })]
        public void TestFilter_LengthString_ValidData_ValidResult(IEnumerable<string> data, int length, IEnumerable<string> expected)
        => CollectionAssert.AreEqual(data.Filter(x => x.Length == length), expected);

        [TestCase(new string[] { "one", "two", "three", "four", "five" }, "o", new string[] { "one", "two", "four" })]
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, "three", new string[] { "three" })]
        public void TestFilter_ContainsString_ValidData_ValidResult(IEnumerable<string> data, string line, IEnumerable<string> expected)
        => CollectionAssert.AreEqual(data.Filter(x => x.Contains(line)), expected);

        [TestCase(new string[] { "one", "two", "three", "four", "five" }, ".", new string[] { "one.", "two.", "three.", "four.", "five." })]
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, "!", new string[] { "one!", "two!", "three!", "four!", "five!" })]
        [TestCase(new string[] { "one", "two", "three", "four", "five" }, " elephant", new string[] { "one elephant", "two elephant", "three elephant", "four elephant", "five elephant" })]
        public void TestTransformer_AddedString_ValidData_ValidResult(IEnumerable<string> data, string line, IEnumerable<string> expected)
        => CollectionAssert.AreEqual(data.Transformer(x => x + line), expected);

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5, 6, 7, 8, 9 })]
        public void TestTransformer_AddedInt_ValidData_ValidResult(IEnumerable<int> data, int numbers, IEnumerable<int> expected)
        => CollectionAssert.AreEqual(data.Transformer(x => x + numbers), expected);

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] {3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 44 }, 4, new int[] { 4, 44 })]
        public void TestFilter_Int_TheRemainder_ValidData_ValidResult(IEnumerable<int> data, int remainder, IEnumerable<int> expected)
        => CollectionAssert.AreEqual(data.Filter(x => x % remainder == 0), expected);

        [Test]
        public void Filter_NullData_ArgumentNullException()
        {
            IEnumerable<string> data = null;
            Assert.Throws(typeof(ArgumentNullException), () => data.Filter(x => x.Length == 3));
        }

        [Test]
        public void Transformer_NullData_ArgumentNullException()
        {
            IEnumerable<string> data = null;
            Assert.Throws(typeof(ArgumentNullException), () => data.Transformer(x => x + "test"));
        }
    }
}
