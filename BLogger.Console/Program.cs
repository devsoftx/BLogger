using ILogger;
using ILogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogger.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dependencies = new DependencyConfig();
            dependencies.Register();

            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();
            log.Write("text1", EventLog.Success);
            log.WriteLog("text1", EventLog.Success);
            log.WriteLogDb("text2", EventLog.Error);
            log.WriteFileLog("text3", EventLog.Warning);
        }
    }
}
