using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewtonMethod.MSTest
{
    [TestClass]
    public class NewtonMethodMSTest
    {
        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test1()
        {
            double number = 1;
            double degrre = 5;
            double accuracy = 0.001;
            double expected = 1;

            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test2()
        {
            double number = 8;
            double degrre = 3;
            double accuracy = 0.0001;
            double expected = 2;

            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test3()
        {
            double number = 0.001;
            double degrre = 3;
            double accuracy = 0.0001;
            double expected = 0.1;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test4()
        {
            double number = 0.04100625;
            double degrre = 4;
            double accuracy = 0.0001;
            double expected = 0.45;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test5()
        {
            double number = 8;
            double degrre = 3;
            double accuracy = 0.0001;
            double expected = 2;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test6()
        {
            double number = 0.0279936;
            double degrre = 7;
            double accuracy = 0.0001;
            double expected = 0.6;
           
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test7()
        {
            double number = 0.0081;
            double degrre = 4;
            double accuracy = 0.1;
            double expected = 0.3;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test8()
        {
            double number = -0.008;
            double degrre = 3;
            double accuracy = 0.1;
            double expected = -0.22;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        public void NewtonMethod_ValidData_ValidResult_Test9()
        {
            double number = 0.004241979;
            double degrre = 9;
            double accuracy = 0.00000001;
            double expected = 0.545;
            
            double result = NewtonMethod.FindNthRoot(number, degrre, accuracy);

            Assert.AreEqual(expected, result, accuracy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NewtonMethod_InvalidDataNegativeNumberAndEvenDegree_ArgumentException()
          => NewtonMethod.FindNthRoot(-2, 2, 0.01);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NewtonMethod_InvalidDataDegreeLessThenZero_ArgumentOutOfRangeException()
           => NewtonMethod.FindNthRoot(0.001, -2, 0.001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NewtonMethod_InvalidDataAccurecyLessThenZero_ArgumentOutOfRangeException()
          => NewtonMethod.FindNthRoot(0.01, 2, -1);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NewtonMethod_InvalidDataAccurecyMoreThenOne_ArgumentOutOfRangeException()
          => NewtonMethod.FindNthRoot(0.01, 2, 15);
    }
}
