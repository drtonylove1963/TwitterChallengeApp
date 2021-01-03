using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterChallenge.Interfaces
{
    public interface IColorLogWriter
    {
        void LogColorLine(string message, string foregroundColor, string backgroundColor);
    }
}
