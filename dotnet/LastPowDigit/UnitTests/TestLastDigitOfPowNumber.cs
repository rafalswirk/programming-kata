using System;
using System.Collections.Generic;
using LastDigitLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestLastDigitOfPowNumber
    {
        private int numberOfTests;
        private StackInput input;

        [TestInitialize]
        public void Init()
        {
            var inputData = new Stack<int>();
            inputData.Push(3);
            inputData.Push(3);
            inputData.Push(3);
            inputData.Push(2);
            numberOfTests = inputData.Count / 2;
            input = new StackInput(inputData);
        }

        [TestMethod]
        public void CheckInvalidInputNumberOfTestsTest()
        {
            var runner = new LastDigitExtractorRunner(input);
            Assert.ThrowsException<ArgumentException>(()=> runner.Run(0));
            Assert.ThrowsException<ArgumentException>(()=> runner.Run(11));
        }

        [TestMethod]
        public void CheckValidInputOfNumberOfTestsTest()
        {
            var runner = new LastDigitExtractorRunner(input);
            Assert.IsTrue(!string.IsNullOrEmpty(runner.Run(numberOfTests)));
        }

        [TestMethod]
        public void CheckIfOutputIsValidTest()
        {
            var runner = new LastDigitExtractorRunner(input);
            var output = runner.Run(numberOfTests);
            Assert.AreEqual($"7{Environment.NewLine}8", output);
        }
    }
}
