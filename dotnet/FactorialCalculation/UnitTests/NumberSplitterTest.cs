using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class NumberSplitterTestTest
    {
        [TestInitialize]
        public void TestNumberSplit()
        {
            var splitter = new NumberSplitterTest();
            var result = splitter.Split(24);
            Assert.Equals(2, result.Decimal);
            Assert.Equals(4, result.Unit);
        }
    }
}