using SumOfPerfectSquaresLib;

namespace SumOfPerfectSquaresTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(2, 17)]
    [TestCase(4, 15)]
    [TestCase(1, 16)]
    public void Test1(int expected, int input)
    {
        Assert.AreEqual(expected, SumOfSquares.NSquaresFor(input));
    }
}