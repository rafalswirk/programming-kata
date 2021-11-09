using System;
using StringCompressionLib.Validators;
using Xunit;

namespace StringCompressionLibTests
{
    public class InputStringLengthValidatorTests
    {
        [Fact]
        public void CheckToLongInput()
        {
            var lengthValidator = new InputStringLengthValidator(1, 5);
            lengthValidator.Validate("aaaaaa");
        }        

        [Fact]
        public void CheckToShortInput()
        {
            throw new NotImplementedException();
        }
    }
}