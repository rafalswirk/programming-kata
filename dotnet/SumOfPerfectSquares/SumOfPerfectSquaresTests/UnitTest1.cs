using SumOfPerfectSquaresLib;

namespace SumOfPerfectSquaresTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(2, SumOfSquares.NSquaresFor(17));
        Assert.AreEqual(4, SumOfSquares.NSquaresFor(15));
        Assert.AreEqual(1, SumOfSquares.NSquaresFor(16));
    }
}