using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Tools.App.Process;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App
{
    public class MainTask : ITask
    {
        private readonly IEnumerable<IProcess> processes;
        private readonly ILogger logger;
        private readonly List<IProcess> haltedProcesses = new List<IProcess>();

        public MainTask(IEnumerable<IProcess> processes, ILogger logger)
        {
            if (processes == null) throw new ArgumentNullException("processes");
            if (logger == null) throw new ArgumentNullException("logger");
            this.processes = processes;
            this.logger = logger;

            // verify runable
            VerifyRunable();
        }

        public bool Runable { get; private set; }

        public void Run()
        {
            var processesExc = processes.Where(p => haltedProcesses.All(h => h.Name != p.Name)).ToList();
            logger.LogDebug("=======processes running:========\n" + string.Join("\n--", processesExc.Select(x => string.Format("++{0}++\n", x.Name))));
            logger.LogDebug("==================================");
            foreach (var process in processesExc)
            {
                if (!process.CanRun()) continue;
                logger.LogDebug("Process {0} begin executing", process.Name);
                if (haltedProcesses.Any(p=>p.Name== process.Name)) continue;
 
                string erroMessage;
                if (process.Run(out erroMessage) == false)
                {
                    if (string.IsNullOrEmpty(erroMessage) == false)
                    {
                        logger.LogError("[ERROR]-{0}: {1}", process.Name, erroMessage);
                    }
                    logger.Log("{0} stops executing", process.Name);
                    // add to unprocess list
                    if (!haltedProcesses.Any(x=>x.Name.Equals(process.Name)))
                        haltedProcesses.Add(process);
                }
                logger.LogDebug("Process {0} executed !!! ", process.Name);
                var waitTime = process.TimeInterval;
                logger.Log("Waits {0} seconds after {1} process completed!!!", waitTime.TotalSeconds, process.Name);
                Thread.Sleep(process.TimeInterval);
            }

            // verify runable
            VerifyRunable();
            //logger.LogDebug("Waits 1 seconds!!"); 
                
        }



        private void VerifyRunable()
        {
            var listProcessName = processes.Select(x => x.Name).Distinct().ToList();
            var listhaltedProcessesName = haltedProcesses.Select(x => x.Name).Distinct().ToList();
            var checkedRunning = listProcessName.Count() != listhaltedProcessesName.Count();
            logger.LogDebug("listNamecheck is {0}", checkedRunning);
            logger.LogDebug("Runable is {0}", Runable);
            Runable = checkedRunning && DateTime.Now.TimeOfDay <= SmsConfiguration.Current.TimeExecuteConfig.EndCloseTime; 
            logger.LogDebug("Runable is {0}", Runable);
            logger.LogDebug("=======processes topped:========\n" + string.Join("\n---", haltedProcesses.Select(x => string.Format("++{0}++\n", x.Name)).Distinct()));
            logger.LogDebug("==================================");
        }
    }
}
