using System;
using System.Threading;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Tools.App.Process
{
    public class EndDayProcess : IProcess
    {
        private readonly ILogger logger; 
        private readonly TimeSpan tfirst = TimeSpan.Parse("16:30");
        private bool isStop = false;

        private readonly IGetStatusProcessDataService _getStatusProcessDataService;

        public EndDayProcess(IGetStatusProcessDataService getStatusProcessDataService, ILogger logger)
        {
            if (getStatusProcessDataService == null) throw new ArgumentNullException("getStatusProcessDataService");
            if (logger == null) throw new ArgumentNullException("logger");
            _getStatusProcessDataService = getStatusProcessDataService;
            this.logger = logger;
        }

        public bool CanRun()
        {
            if (isStop) return false;
            var isRun = DateTime.Now.TimeOfDay >= tfirst && DateTime.Now.TimeOfDay <= SmsConfiguration.Current.TimeExecuteConfig.EndCloseTime;
            if (!isRun)
            {
                logger.LogDebug("Task process EndDay. Time for execute must be {0} to {1}", tfirst, SmsConfiguration.Current.TimeExecuteConfig.EndCloseTime);
            }
            return isRun;
        }

        public bool Run(out string errorMessage)
        {
            try
            {
                logger.Log("Begin get status");
                var orderDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                //_getStatusProcessDataService.GetReceiverSms(orderDate);
                _getStatusProcessDataService.GetMissReceiverAndInsert(startDate, endDate);
                logger.Log("End get status");
                isStop = true; 
                errorMessage = "End process end day!!!"; 
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                errorMessage = ex.Message;
            }
            return CanRun();
        }

        public string Name
        {
            get { return "Task End day process"; }
        }

        public int Id {get { return 10; }}

        public TimeSpan TimeInterval
        {
            get { return TimeSpan.FromHours(1); }
        }
    }
}