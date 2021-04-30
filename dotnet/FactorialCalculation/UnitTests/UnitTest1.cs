using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathematics;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateFraction()
        {
            var factorial = new FactorialCalculator();
            Assert.AreEqual(1, factorial.Calculate(1));
            Assert.AreEqual(2, factorial.Calculate(2));
            Assert.AreEqual(6, factorial.Calculate(3));
            Assert.AreEqual(24, factorial.Calculate(4));
        }

        [TestMethod]
        public void CheckInvalidFactorialInput()
        {
            var factorial = new FactorialCalculator();
            Assert.ThrowsException<ArgumentException>(()=> factorial.Calculate(0));
            Assert.ThrowsException<ArgumentException>(()=> factorial.Calculate(-1));
        }
    }
}
