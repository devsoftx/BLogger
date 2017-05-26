using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ILogger;
using ILogger.Model;

namespace BLogger.Tests
{
    [TestClass]
    public class LoggerTesting
    {
        [TestInitialize]
        public void Logger_Init()
        {
            var dependencies = new DependencyConfig();
            dependencies.Register();            
        }

        [TestMethod]
        public void Logger_instance_of_object()
        {
            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();
            Assert.IsInstanceOfType(log, typeof(Logger));
        }

        [TestMethod]
        public void Logger_can_write_generic()
        {
            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();
            var result = log.Write("text1", EventLog.Success);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Logger_can_write_a_log_database()
        {
            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();
            var result = log.WriteLogDb("text1", EventLog.Success);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Logger_can_write_a_log_console()
        {
            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();            
            var result = log.WriteLog("text1", EventLog.Success);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Logger_can_write_a_log_file()
        {
            ILoggeable log = DependencyConfig.Resolve<ILoggeable>();
            var result = log.WriteFileLog("text1", EventLog.Success);
            Assert.IsTrue(result);
        }
    }
}
