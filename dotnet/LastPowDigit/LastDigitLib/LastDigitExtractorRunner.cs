using System;
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

        public string Run(int numberOfTests)
        {
            if(numberOfTests < 1 || numberOfTests > 10)
                throw new ArgumentException();

            throw new NotImplementedException();
        }
    }
}