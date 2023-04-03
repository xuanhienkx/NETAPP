using System; 
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Common.Configuration; 

namespace SMS.Tools.App.Process
{
    public class FirstDayProcess : IProcess
    {
        private readonly IFirstDayDataService _firstDayDataService;
        private readonly ILogger logger;
        readonly TimeSpan tfirst = TimeSpan.Parse("8:45");
        readonly TimeSpan tlast = TimeSpan.Parse("9:10");
        private bool isStop = false;

        public FirstDayProcess(IFirstDayDataService firstDayDataService, ILogger logger)
        {
            if (firstDayDataService == null) throw new ArgumentNullException("firstDayDataService");
            if (logger == null) throw new ArgumentNullException("logger");
            _firstDayDataService = firstDayDataService;
            this.logger = logger;
        }

        public bool CanRun()
        {
            
            var isRun = DateTime.Now.TimeOfDay <= tlast && DateTime.Now.TimeOfDay >= tfirst;
            if (isStop)
            {
                logger.LogDebug("Message first day have been completed!");
                return false;
            }
            if (!isRun)
            {
                logger.LogDebug("Task process EndDay.Time for execute must be 8:45 to 9:10");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Run(out string errorMessage)
        {
            if (isStop == true)
            {
                errorMessage = "Building message first day topped!!!";
                return false;
            }
            try
            {
                if (_firstDayDataService.IsNeedBackup)
                {
                    logger.Log("backup history!");
                    _firstDayDataService.BackupFirstDay();
                    logger.Log("Successful backup history!");
                }
                _firstDayDataService.BuildingMessageFirstDay();
                isStop = true;
                errorMessage = "End building message first day!!!";
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
            get { return "Task message First day"; }
        }

        public TimeSpan TimeInterval
        {
            get { return TimeSpan.FromSeconds(SmsConfiguration.Current.TimeWaittingConfig.FirstDate); }
        }
    }
}