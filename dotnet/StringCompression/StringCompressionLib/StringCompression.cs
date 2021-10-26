using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCompressionLib
{
    public class StringCompression
    {
        public string Compress(string text)
        {
            var textStack = new Stack<char>();
            if(text?.Length == 0)
                return text;
            textStack.Push(text[0]);
            int counter = 0;
            foreach (var character in text.Skip(1))
            {
                if(character == textStack.Peek())
                {
                    counter++;
                    continue;
                }
            }
        }
    }
}