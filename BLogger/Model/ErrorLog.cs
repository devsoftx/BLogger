using System;
using System.Collections.Generic;
using System.Text;

namespace ILogger.Model
{
    public class ErrorLog : BaseEntity
    {
        public Guid ErrorLogId { get; set; }
        public string Content { get; set; }
        public EventLog EventLog { get; set; }
    }
}
