namespace SumOfPerfectSquaresLib;
public static class SumOfSquares
{
    public static int NSquaresFor(int n)
    {
        var target = n;
        for (int i = 1; i <= n; i++)
        {
            var square = i * i;
            if (square > n)
                break;
            target = Math.Min(target, 1 + NSquaresFor(n - square));
        }

        return target;
    }

}
