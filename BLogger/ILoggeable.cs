using ILogger.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILogger
{
    public interface ILoggeable
    {
        bool Write(string content, EventLog @event);
        bool WriteLog(string content, EventLog @event);
        bool WriteLogDb(string content, EventLog @event);
        bool WriteFileLog(string content, EventLog @event);
    }
}
