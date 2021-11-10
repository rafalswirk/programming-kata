using System;
using FluentAssertions;
using StringCompressionLib.Validators;
using Xunit;

namespace StringCompressionLibTests
{
    public class InputStringLengthValidatorTests
    {
        [Fact]
        public void CheckToLongInput()
        {
            var lengthValidator = new InputStringLengthValidator(2, 5);
            lengthValidator.Validate("aaaaaa").Should().BeFalse();
        }        

        [Fact]
        public void CheckToShortInput()
        {
            var lengthValidator = new InputStringLengthValidator(2, 5);
            lengthValidator.Validate("a").Should().BeFalse();
        }

        [Fact]
        public void CheckValidInput()
        {
            var lengthValidator = new InputStringLengthValidator(2, 5);
            lengthValidator.Validate("aa").Should().BeTrue();
        }
    }
}