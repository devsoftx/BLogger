using BLogger.Repository;
using ILogger.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace ILogger.Repository
{
    public class LogContext : DbContext
    {
        public LogContext()
            : this("LogConnection")
        {

        }

        public LogContext(string connectionString)
            : base(nameOrConnectionString: connectionString)
        {
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<LogContext, Configuration>());
        }

        public virtual IDbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
