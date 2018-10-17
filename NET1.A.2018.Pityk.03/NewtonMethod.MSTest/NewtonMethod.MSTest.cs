using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace NewtonMethod.MSTest
{
    [TestClass]
    public class NewtonMethodMSTest
    {
        private TestContext testContextInstanse;

        public TestContext TestContext
        {
            get { return testContextInstanse; }
            set { testContextInstanse = value; }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\NewtonMethodData.csv",
            "NewtonMethodData#csv", DataAccessMethod.Sequential), DeploymentItem("NewtonMethodData.csv")]
        public void NewtonMethod_ValidData_ValidResult_Test()
        {
            double number = double.Parse(TestContext.DataRow["Number"].ToString());
            double degrre = double.Parse(TestContext.DataRow["Degree"].ToString());
            double accuracy = double.Parse(TestContext.DataRow["Accuracy"].ToString());
            double expected = double.Parse(TestContext.DataRow["Expected"].ToString());

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
