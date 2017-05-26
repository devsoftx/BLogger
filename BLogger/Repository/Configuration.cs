using ILogger.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogger.Repository
{
    public sealed class Configuration : DbMigrationsConfiguration<LogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LogContext context)
        {

        }
    }
}
