using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathematics;

namespace UnitTests
{
    [TestClass]
    public class NumberSplitterTestTest
    {
        [TestMethod]
        public void TestNumberSplit()
        {
            var splitter = new NumberSplitter();
            CheckAssertion(splitter.Split(24), 2, 4);
            CheckAssertion(splitter.Split(123), 12, 3);
            CheckAssertion(splitter.Split(10), 1, 0);
            CheckAssertion(splitter.Split(4), 0, 4);
            CheckAssertion(splitter.Split(0), 0, 0);
        }

        private void CheckAssertion(SplittedNumber number, int expectedDecimal, int expectedUnit)
        {
            Assert.AreEqual(expectedDecimal, number.Decimal);
            Assert.AreEqual(expectedUnit, number.Unit);
        }
    }
}