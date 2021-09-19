using System;
using LastDigitLib.IO;

namespace LastDigitLib
{
    public class LastDigitExtractorRunner
    {
        private readonly IInputData inputData;

        public LastDigitExtractorRunner(IInputData inputData)
        {
            this.inputData = inputData;
        }

        public string Run(int numberOfTests)
        {
            if(numberOfTests < 1 || numberOfTests > 10)
                throw new ArgumentException();

            throw new NotImplementedException();
        }
    }
}