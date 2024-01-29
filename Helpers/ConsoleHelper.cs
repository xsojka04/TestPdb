using System;

namespace TestPdb.Helpers
{
    public static class ConsoleHelper
    {

        public static void WriteLineInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLineSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLineError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
