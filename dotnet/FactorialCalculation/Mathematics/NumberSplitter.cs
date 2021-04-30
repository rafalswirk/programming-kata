using System;

namespace Mathematics
{
    public class NumberSplitter
    {
        public SplittedNumber Split(int number)
        {
            return new SplittedNumber
            {
                Decimal = number / 10,
                Unit = number - (number / 10 * 10)
            };
        }
    }
}