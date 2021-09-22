using System.Text;
using LastDigitLib.IO;

namespace UnitTests
{
    class StringOutput : IOutputData
    {
        private StringBuilder _buffer = new StringBuilder();
        public string Buffer => _buffer.ToString();

        public void Write(string text)
        {
            _buffer.Append(text);
        }
    }
}