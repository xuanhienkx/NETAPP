using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.DataAccess.Models;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App.Process
{
    public class MatchedProcess : IProcess
    {
        private readonly IMatchedDataService _matchedDataService;
        private readonly ILogger logger;
        public MatchedProcess(IMatchedDataService matchedDataService, ILogger logger)
        {
            if (matchedDataService == null) throw new ArgumentNullException("matchedDataService");
            if (logger == null) throw new ArgumentNullException("logger");
            _matchedDataService = matchedDataService;
            this.logger = logger;
        }

        public bool CanRun()
        { 
            var isRun = SmsConfiguration.Current.TimeExecuteConfig.StartDealTime <= DateTime.Now.TimeOfDay
                   && SmsConfiguration.Current.TimeExecuteConfig.EndDealTime > DateTime.Now.TimeOfDay;
            if (!isRun)
            {
                logger.LogDebug("Task process Matched SMS Time for execute must be {0} to {1}", SmsConfiguration.Current.TimeExecuteConfig.StartDealTime, SmsConfiguration.Current.TimeExecuteConfig.EndDealTime);
            }
            return isRun;
        }

        public bool Run(out string errorMessage)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();
                 _matchedDataService.InsertTrading();  
                _matchedDataService.BuilDMessage();  

                ///Todo: logger?
                watch.Stop();

                errorMessage = string.Empty;
                return CanRun();
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                errorMessage = ex.Message;
                return false;
            } 
        }

        public string Name
        {
            get { return "Task message matched trading"; }
        }

        public TimeSpan TimeInterval
        {
            get { return TimeSpan.FromSeconds(SmsConfiguration.Current.TimeWaittingConfig.Matched); }
        }
    }
}