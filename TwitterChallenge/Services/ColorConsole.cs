using System;
using TwitterChallenge.Interfaces;

namespace TwitterChallenge.Services
{
    public class ColorConsole : IColorConsole
    {
        private static readonly object Sync = new object();
        private static ConsoleColor _defaultColor = ConsoleColor.White;

        public static ConsoleColor Default { get { return _defaultColor; } set { _defaultColor = value; } }

        public void Write(ConsoleColor colour, string text, params object[] args)
        {
            lock (Sync)
            {
                Console.ForegroundColor = colour;
                Console.Write(text, args);
            }
        }

        public void WriteLine(ConsoleColor color, string text, params object[] args)
        {
            Write(color, text + '\n', args);
        }

        public void WriteLine(string text, params object[] args)
        {
            Write(text + '\n', args);
        }

        public void Write(string text, params object[] args)
        {
            Write(_defaultColor, text, args);
        }

        public string ReadLine(ConsoleColor color)
        {
            lock (Sync)
            {
                Console.ForegroundColor = color;
                return Console.ReadLine();
            }
        }

        public string ReadLine()
        {
            return ReadLine(_defaultColor);
        }

        public static void Newline(int count = 1)
        {
            if (count < 0) throw new ArgumentOutOfRangeException("NewLine count cannot be a negative number", "Count value: " + count);
            Console.Write("".PadRight(count, '\n'));
        }
    }
}

