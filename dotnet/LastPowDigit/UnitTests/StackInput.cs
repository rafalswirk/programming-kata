using System;
using System.Collections.Generic;
using LastDigitLib.IO;

namespace UnitTests
{
    class StackInput : IInputData
    {
        private readonly Stack<int> input;

        public StackInput(Stack<int> input)
        {
            this.input = input;
        }
        public int GetInput()
        {
            return input.Pop();
        }
    }
}