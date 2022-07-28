namespace SumOfPerfectSquaresLib;
public static class SumOfSquares
{
    public static int NSquaresFor(int i)
    {
        var squares = new List<int>();
        var currentValue = i;
        var squaresSum = 0;
        while (squaresSum - i != 0)
        {
            if (squaresSum < 0)
                throw new InvalidOperationException();
            if (IsSqure(currentValue))
            {
                squares.Add(currentValue);
                squaresSum += currentValue;
                currentValue = i - squaresSum;
                continue;
            }

            currentValue--;
            
        }

        return squares.Count;
    }

    private static bool IsSqure(int i)
    {
        var sqrt = Math.Sqrt(i);
        if (int.TryParse(sqrt.ToString(), out int intValue))
            return true;
        return false;
    }

}
