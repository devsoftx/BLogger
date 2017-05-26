using ILogger;
using ILogger.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogger
{
    public class DependencyConfig
    {
        private static readonly IUnityContainer container = new UnityContainer();
        public void Register()
        {
            container.RegisterType<LogContext>(new TransientLifetimeManager(), new InjectionConstructor("LogConnection"));
            container.RegisterType<IErrorLogRepository, ErrorLogRepository>();
            container.RegisterInstance<ILoggeable>(new ILogger.Logger(
                errorLogRepository: container.Resolve<IErrorLogRepository>()
                ));
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
