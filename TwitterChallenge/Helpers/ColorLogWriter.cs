using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog;
using TwitterChallenge.Interfaces;
using TwitterChallenge.Services;

namespace TwitterChallenge.Helpers
{
    public class ColorLogWriter : IColorLogWriter
    {
        private readonly ILogger<TwitterFeedService> _log;

        public ColorLogWriter(ILogger<TwitterFeedService> log)
        {
            _log = log;
        }
        public void LogColorLine(string message, string foregroundColor, string backgroundColor)
        {
            if (foregroundColor != null)
            {
                switch (foregroundColor.ToUpper())
                {
                    case "BLACK":
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "BLUE":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "CYAN":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "DARKBLUE":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "DARKCYAN":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "DARKGRAY":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case "DARKGREEN":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "DARKMAGENTA":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "DARKRED":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case "DARKYELLOW":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "GRAY":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case "GREEN":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "MAGENTA":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "RED":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "YELLOW":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }
            }

            if (backgroundColor != null)
            {
                switch (backgroundColor.ToUpper())
                {
                    case "BLACK":
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "BLUE":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case "CYAN":
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                    case "DARKBLUE":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "DARKCYAN":
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "DARKGRAY":
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        break;
                    case "DARKGREEN":
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "DARKMAGENTA":
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "DARKRED":
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        break;
                    case "DARKYELLOW":
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "GRAY":
                        Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    case "GREEN":
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case "MAGENTA":
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        break;
                    case "RED":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "YELLOW":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;

                }
            }

            // Write Log with Colors Selected
            //_log.LogInformation(message);
            Console.WriteLine(message);

            // Reset Colors to defaults
            Console.ResetColor();
        }
    }
}
