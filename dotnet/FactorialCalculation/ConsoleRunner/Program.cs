using System;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[]
            {
                "2",
                "1",
                "4"
            };
            Console.Write(new SplitDemo().Run(input));
        }
    }
}
