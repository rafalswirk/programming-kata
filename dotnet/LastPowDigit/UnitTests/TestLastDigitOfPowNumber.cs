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
        private StringOutput output;

        [TestInitialize]
        public void Init()
        {
            var inputData = new Stack<int>();
            inputData.Push(3);
            inputData.Push(3);
            inputData.Push(3);
            inputData.Push(2);
            inputData.Push(2);
            numberOfTests = inputData.Count / 2;
            input = new StackInput(inputData);
            output = new StringOutput();
        }

        [TestMethod]
        public void CheckInvalidInputNumberOfTestsTest()
        {
            input = new StackInput(new Stack<int>(new int[] {11}));
            var runner = new LastDigitExtractorRunner(input, output);
            Assert.ThrowsException<ArgumentException>(()=> runner.Run());

            input = new StackInput(new Stack<int>(new int[] {0}));
            runner = new LastDigitExtractorRunner(input, output);
            Assert.ThrowsException<ArgumentException>(()=> runner.Run());
        }

        [TestMethod]
        public void CheckValidInputOfNumberOfTestsTest()
        {
            var runner = new LastDigitExtractorRunner(input, output);
            Assert.IsTrue(!string.IsNullOrEmpty(runner.Run()));
        }

        [TestMethod]
        public void CheckIfOutputIsValidTest()
        {
            var runner = new LastDigitExtractorRunner(input, output);
            var result = runner.Run();
            Assert.AreEqual($"7{Environment.NewLine}8", result);
        }
    }
}
