using System.Text.RegularExpressions;

namespace StringCompressionLib.Validators
{
    public class OnlyCharactersValidator : IValidator
    {
        private Regex regex;

        public OnlyCharactersValidator()
        {
            regex = new Regex(@"\d");
        }
        public bool Validate(string input)
        {
            return regex.IsMatch(input) == false;
        }
    }
}