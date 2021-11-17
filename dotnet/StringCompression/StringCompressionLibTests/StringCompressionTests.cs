using System;
using FluentAssertions;
using StringCompressionLib;
using StringCompressionLib.Validators;
using Xunit;

namespace StringCompressionLibTests
{
    public class StringCompressionLibTests
    {
        [Theory]
        [InlineData("AAA", "A3")]
        [InlineData("AAAB", "A3B")]
        [InlineData("AAABB", "A3BB")]
        [InlineData("AAABBB", "A3B3")]
        [InlineData("OPSS", "OPSS")]
        [InlineData("ABCDEF", "ABCDEF")]
        [InlineData("ABBCCCDDDDEEEEEFGGHIIJKKKL", "ABBC3D4E5FGGHIIJK3L")]
        [InlineData("AAAAAAAAAABBBBBBBBBBBBBBBB", "A10B16")]
        public void CheckCompressionAlgorithm(string textToCompress, string expected)
        {
            var compression = new StringCompression(new IValidator[0]);

            string compressed = compression.Compress(textToCompress);

            compressed.Should().Be(expected);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("AAAAAA")]
        public void CheckIfInputValidatorWillThrowExceptionForToLongData(string inptut)
        {
            var compression = new StringCompression(new IValidator[]{new InputStringLengthValidator(2, 5)});
            Assert.Throws<ArgumentException>(()=> compression.Compress(inptut));
        }

        
        [Theory]
        [InlineData("1")]
        [InlineData("A1AA")]
        public void CheckIfInputValidatorWillThrowExceptionForNumericData(string inptut)
        {
            var compression = new StringCompression(new IValidator[]{new OnlyCharactersValidator()});
            Assert.Throws<ArgumentException>(()=> compression.Compress(inptut));
        }
    }
}
