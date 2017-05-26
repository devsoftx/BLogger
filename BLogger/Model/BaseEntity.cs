using System;
using System.Collections.Generic;
using System.Text;

namespace ILogger.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
