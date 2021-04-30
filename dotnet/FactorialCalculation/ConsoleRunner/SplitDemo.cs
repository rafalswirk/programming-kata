using System;
using Mathematics;
using System.Linq;
using System.Text;

namespace ConsoleRunner
{
    class SplitDemo
    {
        public string Run(string[] inputLines)
        {
            var splitter = new NumberSplitter();
            var factorial = new FactorialCalculator();
            var resultText = new StringBuilder();
            var inputNumbers = inputLines.Skip(1).Select(n => int.Parse(n)).ToArray();
            foreach (var number in inputNumbers)
            {
                var factorialValue = factorial.Calculate(number);
                var splitted = splitter.Split(factorialValue);
                resultText.AppendLine($"{splitted.Decimal} {splitted.Unit}");
            }

            return resultText.ToString();
        }
    }
}