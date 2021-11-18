using System;
using StringCompressionLib;
using StringCompressionLib.Validators;

namespace StringCompressionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Application started!");
            var numberOfTests = Console.ReadLine();
            if(int.TryParse(numberOfTests, out int testsCount ))
            {
                var compression = new StringCompression(new IValidator[]
                {
                    new InputStringLengthValidator(1, 200),
                    new OnlyCharactersValidator()
                });
                var textToCompress = new string[testsCount];
                for (int i = 0; i < testsCount; i++)
                {
                    textToCompress[i] = Console.ReadLine();
                }
                foreach (var text in textToCompress)
                {
                    System.Console.WriteLine(compression.Compress(text));
                }
            }
        }
    }
}
