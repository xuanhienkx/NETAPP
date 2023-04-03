using System;
using System.Collections.Generic;
using System.Text;

namespace VSDGateway
{
    public class ConsoleHelper
    {
        public static void Write(string formatString, ConsoleColor color, params object[] argumens)
        {
            var currentBackground = Console.BackgroundColor;

            Console.ForegroundColor = color;
            Console.Write(formatString, argumens);
            Console.ForegroundColor = currentBackground;
        }

        public static void WriteLine(string formatString, ConsoleColor color, params object[] argumens)
        {
            var currentBackground = Console.BackgroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(formatString, argumens);
            Console.ForegroundColor = currentBackground;
        }
    }
}
