using System;

namespace lab_5.Logger
{
    public static class ConsoleLogger
    {
        public static void WriteLine(string shortMessage, string fullMessage)
        {
            var output = DateTime.Now + ", " + shortMessage + ": " + fullMessage + ".";
            Console.WriteLine(output);
        }
        
        public static void WriteLine(string shortMessage)
        {
            var output = DateTime.Now + ", " + shortMessage + ".";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(output);
            Console.ResetColor();
        }

        public static void WriteException(Exception ex)
        {
            var output = DateTime.Now + ", " + ex.Message + ": " + ex.Source;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(output);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.WriteLine("#");
            }
            Console.ResetColor();
        }
    }
}