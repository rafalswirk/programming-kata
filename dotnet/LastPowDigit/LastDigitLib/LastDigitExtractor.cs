using System;
using System.Text;

namespace LastDigitLib
{
    public class LastDigitExtractor
    {
        public string ProcessData(string input)
        {
            var splittedValues = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int numberOfTests;
            if(!int.TryParse(splittedValues[0], out numberOfTests))
                throw new ArgumentException("Invalid number of tests");
            var results = new StringBuilder();
            for (int i = 1; i <= numberOfTests; i++)
            {
                var rawCaseData = splittedValues[i].Trim().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                if(rawCaseData.Length != 2)
                    throw new ArgumentException("Invalid input data for calculating power");

                double numberToBeRaisedToPower;
                if(!double.TryParse(rawCaseData[0], out numberToBeRaisedToPower))
                    throw new ArgumentException($"Cannot read number to be raised to power! Raw data:{rawCaseData[0]}");
                
                double specificPower;
                if(!double.TryParse(rawCaseData[1], out specificPower))
                    throw new ArgumentException($"Cannot read number to be raised to power! Raw data:{rawCaseData[1]}");

                var powResult = (int)Math.Pow(numberToBeRaisedToPower, specificPower);
                results.AppendLine(powResult.ToString());
            }

            return results.ToString();
        }
    }
}