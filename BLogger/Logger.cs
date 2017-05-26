using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger.Model;
using ILogger.Repository;
using System.IO;
using System.Configuration;
using System.Security.AccessControl;
using System.Reflection;
using BLogger.Config;

namespace ILogger
{
    public class Logger : ILoggeable
    {
        private readonly IErrorLogRepository _errorLogRepository;        
        public Logger(IErrorLogRepository errorLogRepository)
        {
            this._errorLogRepository = errorLogRepository;
        }

        public bool Write(string content, EventLog @event)
        {
            LoggerConfigSection config = (LoggerConfigSection)System.Configuration.ConfigurationManager.GetSection("loggerConfigGroup/loggerConfig");
            Enum.TryParse(config.DefaultLogger.Type, out LoggerType _logger);
            var result = false;
            switch (_logger)
            {
                case LoggerType.Console:
                    result = WriteLog(content, @event);
                    break;
                case LoggerType.File:
                    result = WriteFileLog(content, @event);
                    break;
                case LoggerType.Database:
                    result = WriteLogDb(content, @event);
                    break;
                default:
                    break;
            }

            return result;
        }

        public bool WriteFileLog(string content, EventLog @event)
        {
            var returnValue = false;
            Assembly assembly = typeof(Logger).Assembly;
            var path = System.IO.Path.GetDirectoryName(assembly.Location);
            var fileName = $@"{path}\log.txt";
            if (fileName != string.Empty)
            {
                using (var writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine($@"{@event}: {content}");
                    returnValue = true;
                }                
            }

            return returnValue;
        }

        public bool WriteLog(string content, EventLog @event)
        {
            switch (@event)
            {
                case EventLog.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case EventLog.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case EventLog.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine($"{@event}: {content}");
            return true;
        }

        public bool WriteLogDb(string content, EventLog @event)
        {
            return this._errorLogRepository.Save(new ErrorLog { ErrorLogId = Guid.NewGuid(), Content = content, EventLog = @event });
        }
    }
}
