namespace StringCompressionLib.Validators
{
    public class InputStringLengthValidator : IValidator
    {
        private int min;
        private int max;

        public InputStringLengthValidator(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public bool Validate(string input)
        {
            if(input.Length < min || input.Length > max)
                return false;
            return true;
        }
    }
}