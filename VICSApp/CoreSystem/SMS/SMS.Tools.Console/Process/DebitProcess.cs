using System;
using System.Threading;
using System.Threading.Tasks;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App.Process
{
    public class DebitProcess : IProcess
    {
        private readonly IDebitDataService _debitDataService;
        private readonly ILogger _logger;
        public DebitProcess(IDebitDataService debitDataService, ILogger logger)
        {
            if (debitDataService == null) throw new ArgumentNullException(nameof(debitDataService));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _debitDataService = debitDataService;
            _logger = logger;
        }

        public TimeSpan TimeInterval
        {
            get { return TimeSpan.FromSeconds(SmsConfiguration.Current.TimeWaittingConfig.Debit); }
        }

        public bool CanRun()
        {
            var isRun= SmsConfiguration.Current.TimeExecuteConfig.EndSendTime >= DateTime.Now.TimeOfDay && DateTime.Now.TimeOfDay >= SmsConfiguration.Current.TimeExecuteConfig.StartDealTime;
            if (!isRun)
            {
                _logger.LogDebug("Task process Debit. Time for execute must be {0} to {1}", SmsConfiguration.Current.TimeExecuteConfig.StartDealTime, SmsConfiguration.Current.TimeExecuteConfig.EndSendTime);
            }
            return isRun;
        }

        public bool Run(out string errorMessage)
        {
            try
            {
                _logger.LogDebug("Process Debit start");
                var insert = _debitDataService.InsertTrasaction();
                var bulding = _debitDataService.BuilDMessage();
                Task.WhenAll(insert, bulding); 
                errorMessage = string.Empty;
                _logger.LogDebug("Process Debit end");
                return CanRun();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public string Name
        {
            get { return "Task message transaction"; }
        }
    }
}