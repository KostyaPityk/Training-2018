using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Transform.Test
{
    [TestFixture]
    public class TransformTest
    {
        public static IEnumerable<TestCaseData> Context()
        { 
            yield return new TestCaseData(new double[] { 2, 5, 35 }, new string[] { "two ", "five ", "three five " });
            yield return new TestCaseData(new double[] { 2.56, -5, -35.5 }, 
                                            new string[] { "two point five six ", "minus five ", "minus three five point five " });
            yield return new TestCaseData(new double[] { -9.75 }, new string[] { "minus nine point seven five " });
            yield return new TestCaseData(new double[] { 0.56, -0.5, 99.55 },
                                            new string[] { "zero point five six ", "minus zero point five ", "nine nine point five five " });
            yield return new TestCaseData(new double[] { 5.74 }, new string[] { "five point seven four " });
            yield return new TestCaseData(new double[] { 11.11, -3.95, -0.005 },
                                            new string[] { "one one point one one ", "minus three point nine five ", "minus zero point zero zero five " });
        }

        [TestCaseSource("Context")]
        public void Transform_ValidData_ValidResult(double[] array, string[] valid_result)
        {
            string[] result_transform = Transform.TransformToWords(array);

            CollectionAssert.AreEqual(result_transform, valid_result);
        }

        [Test]
        public void Transform_Array_IsNull_ArgumentNullException()
           => Assert.Throws(typeof(ArgumentNullException), () => Transform.TransformToWords(null));
    }
}
