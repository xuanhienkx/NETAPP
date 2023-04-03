using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleInjector;
using SMS.Comon.IOC;
using SMS.Tools.ConsoleExcutor;
using SMS.Common;
using SMS.Tools.App.Process;

namespace SMS.Tools.App
{
    class Program
    {
        private static void Main()
        {
            var container = BootstrapComponentRegistration();

            var logger = container.GetInstance<ILogger>();
            try
            {
                var task = container.GetInstance<ITask>();
                new Executor<ITask>(task, logger).Execute();
            }
            catch (Exception ex)
            {
                logger.LogError("Error send:{0}", ex.Message); 
            }
        }

        private static Container BootstrapComponentRegistration()
        {
            var container = StartupContainer.Initialize(typeof(ConsoleLogger));

            // register all tasks to process
            var processAssembly = typeof(Program).Assembly;

            container.RegisterCollection<IProcess>(new[] { processAssembly });
            container.Register<ITask, MainTask>(Lifestyle.Singleton);

            //// Verify registrations  
            container.Verify(VerificationOption.VerifyOnly);

            return container;
        }

    }
}
