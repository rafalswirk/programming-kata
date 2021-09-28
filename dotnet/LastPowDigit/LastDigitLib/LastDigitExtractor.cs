using System;

namespace LastDigitLib
{
    public class LastDigitExtractor
    {
        public string ProcessData(string input)
        {
            var splittedValues = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int numberOfTests;
            if(!int.TryParse(splittedValues[0], out numberOfTests))
                throw new ArgumentException();
            throw new NotImplementedException();
        }
    }
}