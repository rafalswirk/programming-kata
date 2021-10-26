using System;
using FluentAssertions;
using StringCompressionLib;
using Xunit;

namespace StringCompressionLibTests
{
    public class StringCompressionLibTests
    {
        [Fact]
        public void Test1()
        {
            var compression = new StringCompression();

            string compressed = compression.Compress("OPSS");

            compressed.Should().Be("OPSS");
        }
    }
}
