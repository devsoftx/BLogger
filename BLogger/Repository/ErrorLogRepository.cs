using System;
using System.Collections.Generic;
using System.Text;
using ILogger.Model;

namespace ILogger.Repository
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly Func<LogContext> _errorLogContextFactory;

        public ErrorLogRepository(Func<LogContext> errorLogContextFactory)
        {
            this._errorLogContextFactory = errorLogContextFactory;
        }

        public bool Save(ErrorLog entity)
        {
            using (var context = this._errorLogContextFactory())
            {
                entity.CreatedBy = "System";
                context.ErrorLogs.Add(entity);
                var returnValues = context.SaveChanges();
                return returnValues > 0;
            }
        }
    }
}
