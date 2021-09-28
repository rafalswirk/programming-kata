using System;
using System.Text;
using LastDigitLib.IO;

namespace LastDigitLib
{
    public class LastDigitExtractorRunner
    {
        private readonly IInputData inputData;
        private readonly IOutputData outputData;

        public LastDigitExtractorRunner(IInputData inputData, IOutputData outputData)
        {
            this.inputData = inputData;
            this.outputData = outputData;
        }

        public string Run()
        {
            var numberOfTests = inputData.GetInput();
            if(numberOfTests < 1 || numberOfTests > 10)
                throw new ArgumentException();

            var rawInput = new StringBuilder();
            rawInput.AppendLine(numberOfTests.ToString());

            for (int i = 0; i < numberOfTests; i++)
            {
                rawInput.AppendLine($"{inputData.GetInput()} {inputData.GetInput()}");
            }

            var extractor = new LastDigitExtractor();
            return extractor.ProcessData(rawInput.ToString());
        }
    }
}