using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogger.Config
{
    public class LoggerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("logger")]
        public DefaultLoggerElement DefaultLogger
        {
            get
            {
                return (DefaultLoggerElement)this["logger"];
            }
            set
            { this["logger"] = value; }
        }
    }

    public class DefaultLoggerElement : ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = "Console", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String Type
        {
            get
            {
                return (String)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
    }
}