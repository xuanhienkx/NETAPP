using System;
using System.Collections.Specialized;
using System.Threading;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.DataAccess.Models;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App.Process
{
    public class SendESmsProcess : IProcess
    {
        private readonly ISendProcessDataService sendProcessDataServics;
        private readonly ILogger logger;

        public SendESmsProcess(ISendProcessDataService sendProcessDataServics, ILogger logger)
        {
            if (sendProcessDataServics == null) throw new ArgumentNullException("sendProcessDataServics");
            if (logger == null) throw new ArgumentNullException("logger");
            this.sendProcessDataServics = sendProcessDataServics;
            this.logger = logger;
        }

        public bool CanRun()
        {
            var isRun= SmsConfiguration.Current.TimeExecuteConfig.EndSendTime >= DateTime.Now.TimeOfDay && DateTime.Now.TimeOfDay >= TimeSpan.Parse("8:50");
            if (!isRun)
            {
                logger.LogDebug("Task process Send SMS Time for execute must be {0} to {1}", TimeSpan.Parse("8:50"), SmsConfiguration.Current.TimeExecuteConfig.EndSendTime);
            }
            return isRun;
        }

        public bool Run(out string errorMessage)
        {
            try
            {
                sendProcessDataServics.ProcessSend(SmsType.All);

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
            get { return "Task send message to API"; }
        }

        public TimeSpan TimeInterval
        {
            get { return TimeSpan.FromSeconds(SmsConfiguration.Current.TimeWaittingConfig.SendSms); }
        }
    }
}