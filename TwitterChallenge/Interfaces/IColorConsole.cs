using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterChallenge.Interfaces
{
    public interface IColorConsole
    {
        void Write(ConsoleColor colour, string text, params object[] args);
        void WriteLine(ConsoleColor color, string text, params object[] args);
        void WriteLine(string text, params object[] args);
        void Write(string text, params object[] args);
        string ReadLine(ConsoleColor color);
        string ReadLine();

    }
}
