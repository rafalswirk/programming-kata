using System;

namespace Mathematics
{
    public class FactorialCalculator
    {
        public int Calculate(int number)
        {
            if(number < 1)
                throw new ArgumentException("Input argument should be >= 1");

            var result = 1;
            for(int i = 1; i <= number; i++)
                 result *= i;
            return result;
        }
    }
}