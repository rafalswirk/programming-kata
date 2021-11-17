using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringCompressionLib.Validators;

namespace StringCompressionLib
{
    public class StringCompression
    {
        private readonly IValidator[] validators;

        public StringCompression(IValidator[] validators)
        {
            this.validators = validators;
        }
        public string Compress(string text)
        {
            if(!validators.All(v => v.Validate(text)))
                throw new ArgumentException();
            var textStack = new Stack<string>();
            if(text?.Length == 0)
                return text;
            textStack.Push(text[0].ToString());
            int counter = 1;
            foreach (var character in text.Skip(1))
            {
                if(character.ToString() == textStack.Peek())
                {
                    counter++;
                    continue;
                }
                if(counter == 1)
                {
                    textStack.Push(character.ToString());
                    counter = 1;
                    continue;
                }
                if(counter == 2)
                {
                    textStack.Push(textStack.Peek());
                    textStack.Push(character.ToString());
                    counter = 1;
                    continue;
                }
                if(counter > 2)
                {
                    textStack.Push(counter.ToString());
                    //textStack.Push(textStack.Peek());
                    textStack.Push(character.ToString());
                    counter = 1;
                }
            }

            if(counter == 2)
            {
                textStack.Push(textStack.Peek());
            }
            if(counter > 2)
            {
                textStack.Push(counter.ToString());
            }

            return string.Join("", textStack.Reverse());
        }
    }
}