using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Business.Service.Services
{
    public interface IFirstDayDataService
    {
        Task<IEnumerable<SmsCustomer>> GetAll(Expression<Func<SmsCustomer, bool>> filter);
        IList<SmsCustomer> CustomerWordDays { get; }
        List<string> CustomerIds { get; }
        void BackupFirstDay();
        void BuildingMessageFirstDay();
        bool IsNeedBackup { get; }
    }

    public class FirstDayDataService : BaseDataService, IFirstDayDataService
    {
        private readonly ILogger _logger;

        public FirstDayDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork, ILogger logger)
            : base(smsUnitOfWork, sbsUnitOfWork)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        public async Task<IEnumerable<SmsCustomer>> GetAll(Expression<Func<SmsCustomer, bool>> filter)
        {
            return await SmsUnitOfWork.CustomerRepository.GetAllAsync(filter);
        }
        private IList<SmsCustomer> _customerWordDays;
        private int _totalMessage;

        public IList<SmsCustomer> CustomerWordDays
        {
            get
            {
                if (_customerWordDays != null) return _customerWordDays;
                var sbsWorkCustomerIds = SbsUnitOfWork.FirstDayRepository.CustomerTradingOnMonth;
                var customers = SmsUnitOfWork.CustomerRepository.GetCustomers(
                    c => c.IsClose == false && sbsWorkCustomerIds.Contains(c.Id));

                return _customerWordDays = customers;
            }
        }

        public List<string> CustomerIds
        {
            get { return CustomerWordDays.Select(x => x.Id).ToList(); }
        }

        public void BackupFirstDay()
        {
            try
            {

                var t = SmsUnitOfWork.HistoryRepository.BackupToHistory();
                if (t <= 0)
                {
                    _logger.Log("Error firstDay success-->{0}", t);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Error:{0}", JsonConvert.SerializeObject(new[] { ex.Message, ex.StackTrace })); 

            }
        }

        private IList<BalanceModel> _blModels;

        public void BuildingMessageFirstDay()
        {

            try
            {
                var balances = GetCurrenBalance();
                var securities = GetSecurities(); 
                int countErr = 0;
                if (balances == null || !balances.Any())
                    return;
                if (securities == null || !securities.Any())
                    return;
                _logger.Log("Building message first day!!!");
                foreach (var bl in balances)
                {
                    if (bl == null) continue;

                    SmsCustomer cus = SmsUnitOfWork.CustomerRepository.GetCustomerWork(bl.AccountId);
                    if (cus == null || (!cus.Mobile.IsNumber())) continue;

                    var reqCus = new List<SmsCustomer> { cus };
                    var stocks = GetSecurities().Where(s => s.AccountId == cus.Id).OrderBy(x => x.StockCode).ToList();
                    var ob = new
                    {
                        CustomerId = cus.Id,
                        balance = bl.CurrentBalance,
                        Securities = stocks.Select(x => new
                        {
                            StockCode = x.StockCode,
                            Volume = x.Quantity
                        }).ToArray()
                    };

                    var message = DesignMessage(ob, OnFirstDay);
                    var buildingMessage = message.Trim();
                    if (message.Contains("tien 00VND;"))
                    {
                        buildingMessage = message.Replace("tien 00VND;", "");
                    }
                    if (message.Trim().EndsWith("ck"))
                    {
                        buildingMessage = message.Replace("ck", "");
                    }
                    if (string.IsNullOrEmpty(buildingMessage.Trim()))
                    {
                        _logger.LogError("Error firstDay bulling message -->{0} ", JsonConvert.SerializeObject(ob)); 
                        countErr++;
                        continue;
                    }

                    var existed =
                          SmsUnitOfWork.RequestRepository.GetAll(
                             x =>
                                 x.Type == (short)(SmsType.DauNgay) && x.Customers.Any(c=>c.Id==cus.Id) &&
                                 x.OrderDate.Equals(OrderDate));

                    if (existed.Any()) continue;
                    var smsRequest = new SmsRequest
                    {
                        Id = Guid.NewGuid(),
                        Message = buildingMessage.Trim(),
                        CreatedTime = DateTime.Now,
                        Customers = reqCus,
                        IsSent = false,
                        OrderDate = OrderDate,
                        Type = (short)SmsType.DauNgay,
                        IsBrandName = true,// IsBrandName(cus.Mobile)

                    };
                    SmsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                    _logger.Log("FirstDay message--> " + message);
                   
                }

                int t = SmsUnitOfWork.SaveChanges();
                _logger.Log("FirstDay total message save -->{0} ", t);
                if (countErr > 0)
                {
                    _logger.Log("FirstDay total message Err -->{0} ", countErr); 
                }
                _logger.Log("Total message first day {0}", TotalMessage);
                _logger.Log("Finish building message first day");
                _logger.Log("End process First day");
            }
            catch (Exception ex)
            { 
                _logger.Log("Error first day-->{0}", ex.Message);
            }

        }
        public bool IsNeedBackup
        {
            get
            {
                return SmsUnitOfWork.HistoryRepository.IsNeedBackup;
            }
        }

        private List<BalanceModel> GetCurrenBalance()
        {
            return SbsUnitOfWork.FirstDayRepository.GetCurrenBalance(CustomerIds).ToList();
        }

        private List<SecurityModel> GetSecurities()
        {
            return SbsUnitOfWork.FirstDayRepository.GetSecurities(CustomerIds).ToList();
        }

        public override int TotalMessage
        {
            get { return SmsUnitOfWork.RequestRepository.Count(x => x.Type == (short)SmsType.DauNgay); }
        }
    }
}