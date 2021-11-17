using FluentAssertions;
using StringCompressionLib.Validators;
using Xunit;

namespace StringCompressionLibTests
{
    public class OnlyLettersValidatorTests
    {
        [Theory]
        [InlineData("A1A", false)]
        [InlineData("1A", false)]
        [InlineData("A1", false)]
        [InlineData("AAAVVV2BBB", false)]
        public void CheckAlphanumericInput(string input, bool expectedResult)
        {
            var validator = new OnlyCharactersValidator();
            validator.Validate(input).Should().Be(expectedResult);
        }
    }
}