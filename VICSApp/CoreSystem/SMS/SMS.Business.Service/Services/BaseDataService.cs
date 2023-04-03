using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Data.Services.EF.UnitsOfWork;

namespace SMS.Business.Service.Services
{
    public abstract class BaseDataService
    {
        public const string OnFirstDay = "OnFirstDay";
        public const string OnMatched = "OnMatched";
        public const string OnDebited = "OnDebited";

        private readonly ISmsUnitOfWork _smsUnitOfWork;
        private readonly ISbsUnitOfWork _sbsUnitOfWork;
        protected readonly object lockObj = new object();

        protected BaseDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork)
        {
            if (smsUnitOfWork == null) throw new ArgumentNullException("smsUnitOfWork");
            if (sbsUnitOfWork == null) throw new ArgumentNullException("sbsUnitOfWork");
            _smsUnitOfWork = smsUnitOfWork;
            _sbsUnitOfWork = sbsUnitOfWork;

        }
        public virtual ISmsUnitOfWork SmsUnitOfWork { get { return _smsUnitOfWork; } }
        public virtual ISbsUnitOfWork SbsUnitOfWork { get { return _sbsUnitOfWork; } }

        public virtual bool IsBrandName(string mobile)
        {
            var telecomeOfBrand = ApiEmsConfiguration.Current.Telecome;
            if (telecomeOfBrand.Equals("All", StringComparison.CurrentCultureIgnoreCase))
                return true;
            if (telecomeOfBrand.Equals("None", StringComparison.CurrentCultureIgnoreCase))
                return true;
            var mobiType = mobile.GePhoneType().ToString();
            return telecomeOfBrand.Contains(mobiType);
        }
        public abstract int TotalMessage { get; }
        private SmsConfiguration _config = SmsConfiguration.Current;
        public virtual string DesignMessage(object sender, string name)
        {
            try
            {
                var options = sender.GetType()
               .GetProperties()
               .ToDictionary(x => x.Name, x => x.GetValue(sender, null));
                var esmsTemplateConfiguration = _config.Templates.FirstOrDefault(x => x.Name == name);
                if (esmsTemplateConfiguration == null)
                    throw new NotImplementedException("not found template name: " + name);
                var temMessage = esmsTemplateConfiguration.Body.Value.Replace("\r", "").Replace("\n", "");
                var message = options.ReplaceText(temMessage);
                return message.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            }
            catch (Exception ex)
            {
                

            }
            return String.Empty;
        }

        public virtual string OrderDate
        {
            get { return SmsConfiguration.Current.TimeExecuteConfig.TransactionDate.ToString("dd/MM/yyyy"); }
        }
    }
}