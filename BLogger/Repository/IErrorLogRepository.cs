using ILogger.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILogger.Repository
{
    public interface IErrorLogRepository
    {
        bool Save(ErrorLog entity);
    }
}
