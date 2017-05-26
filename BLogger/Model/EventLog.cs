using System;
using System.Collections.Generic;
using System.Text;

namespace ILogger.Model
{
    public enum EventLog : int
    {
        Error = 0,
        Success = 1,
        Warning = 2
    }

    public enum LoggerType
    {
        Console,
        File,
        Database
    }
}