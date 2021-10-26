using System;
using FluentAssertions;
using StringCompressionLib;
using Xunit;

namespace StringCompressionLibTests
{
    public class StringCompressionLibTests
    {
        [Theory]
        [InlineData("OPSS", "OPSS")]
        [InlineData("ABCDEF", "ABCDEF")]
        [InlineData("ABBCCCDDDDEEEEEFGGHIIJKKKL", "ABBC3D4E5FGGHIIJK3L")]
        [InlineData("AAAAAAAAAABBBBBBBBBBBBBBBB", "A10B16")]
        public void CheckCompressionAlgorithm(string textToCompress, string expected)
        {
            var compression = new StringCompression();

            string compressed = compression.Compress(textToCompress);

            compressed.Should().Be(expected);
        }
    }
}
