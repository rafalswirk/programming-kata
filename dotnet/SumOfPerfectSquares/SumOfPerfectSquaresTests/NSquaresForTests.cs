using SumOfPerfectSquaresLib;

namespace SumOfPerfectSquaresTests;

public class NSquaresForTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    //[TestCase(4, 15)]
    //[TestCase(1, 16)]
    //[TestCase(2, 17)]
    [TestCase(2, 18)]
    [TestCase(3, 19)]
    public void NSquaresFor_InputNumber_ReturnsSmallestListOfPerfectSquares(int expected, int input)
    {
        Assert.That(SumOfSquares.NSquaresFor(input), Is.EqualTo(expected));
    }
}