namespace SumOfPerfectSquaresLib;
public static class SumOfSquares
{
    public static int NSquaresFor(int i)
    {
        var currentValue = i;
        var squaresNumber = 0;
        while (currentValue > 1)
        {
            var sqrt = Math.Sqrt(currentValue);
            if (int.TryParse(sqrt.ToString(), out int intValue))
                return ++squaresNumber;

            currentValue -= (int)Math.Pow((int)sqrt, 2);
            squaresNumber++;
        }

        return ++squaresNumber;
    }

}
