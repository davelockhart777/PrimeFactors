using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test output of comma delimited string
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            PrimeNumbers.FactorGen testItem = new PrimeNumbers.FactorGen("67868");

            string testResult = testItem.getFactorString();
            string expected = "2,2,19,19,47";
            Assert.AreEqual(expected, testResult);
          
        }

        
        /// <summary>
        /// Test calculation of factors to equal given number.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            int testNumber = 29853;
            int testResult = 1;
            PrimeNumbers.FactorGen testItem = new PrimeNumbers.FactorGen(testNumber.ToString());

            foreach (int item in testItem.factors)
            {
                testResult = testResult * item;   
            }

            Assert.AreEqual(testNumber, testResult);

        }

        /// <summary>
        /// Test calculation of factors to equal given number.
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            int testNumber = 2213;
            int testResult = 1;
            PrimeNumbers.FactorGen testItem = new PrimeNumbers.FactorGen(testNumber.ToString());

            foreach (int item in testItem.factors)
            {
                testResult = testResult * item;
            }

            Assert.AreEqual(testNumber, testResult);

        }
    }
}
