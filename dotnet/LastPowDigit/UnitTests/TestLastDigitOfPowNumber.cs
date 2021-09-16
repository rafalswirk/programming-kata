using System;
using LastDigitLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestLastDigitOfPowNumber
    {
        [TestMethod]
        public void CheckInvalidInputNumberOfTestsTest()
        {
            var runner = new LastDigitExtractorRunner();
            Assert.ThrowsException<ArgumentException>(()=> runner.Run(0));
            Assert.ThrowsException<ArgumentException>(()=> runner.Run(11));
            Assert.IsTrue(!string.IsNullOrEmpty(runner.Run(5)));
        }

        [TestMethod]
        public void CheckValidInputOfNumberOfTestsTest()
        {
            var runner = new LastDigitExtractorRunner();
            Assert.IsTrue(!string.IsNullOrEmpty(runner.Run(5)));
        }
    }
}
