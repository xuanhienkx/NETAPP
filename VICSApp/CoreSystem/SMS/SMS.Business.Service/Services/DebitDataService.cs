using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;
using SMS.Tools.ConsoleExcutor;

namespace SMS.Business.Service.Services
{
    public interface IDebitDataService
    {
        Task<int> InsertTrasaction();
        Task<int> BuilDMessage();

    }
    public class DebitDataService : BaseDataService, IDebitDataService
    {
        private readonly ILogger _logger;

        public DebitDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork, ILogger logger)
            : base(smsUnitOfWork, sbsUnitOfWork)
        {
            
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        public async Task<int> InsertTrasaction()
        {
            var debits =  SbsUnitOfWork.DebitRepository.GetAllSbsDebit();
            if (debits == null || !debits.Any())
                return 0;
            _logger.Log("Begin process debit message"); 
            foreach (var debit in debits.GroupBy(x => x.TransactionNumber))
            {
                if (debit == null) continue;
                var cusDebit = debit.SingleOrDefault(x => x.SectionGl == "3241" && x.TransactionNumber == debit.Key);
                var bank = debit.SingleOrDefault(x => x.SectionGl == "9999" && x.TransactionNumber == debit.Key);

                if (cusDebit == null) continue;
                if (bank == null) continue;

                var cus = SmsUnitOfWork.CustomerRepository.GetCustomerWork(cusDebit.AccountId);

                if (cus == null) continue;
                var existed =
                    SmsUnitOfWork.TransactionDayRepository.GetAll(
                        t =>
                            t.Description == cusDebit.Description && t.Amount == cusDebit.Amount &&
                            t.TransactionTime == cusDebit.TransactionTime &&
                            t.TransactionNumber == cusDebit.TransactionNumber);
                if(existed.Any()) continue;
                var currentBalance = SbsUnitOfWork.DebitRepository.CurrentBalance(cus.Id);
                var smsTran = new SmsTransactionDay
                {
                    Id = Guid.NewGuid(),
                    TransactionDate = cusDebit.TransactionDate,
                    TransactionTime = cusDebit.TransactionTime.HasValue ? cusDebit.TransactionTime.Value : DateTime.Now,
                    TransactionNumber = cusDebit.TransactionNumber,
                    Description = cusDebit.Description,
                    DebitOrCredit = cusDebit.DebitOrCredit,
                    Amount = cusDebit.Amount,
                    CurrentBalance = currentBalance,
                    Customer = cus,
                    BankAccountId = bank.AccountId,
                    BankAccountName = bank.AccountName,
                    BankDebitOrCredit = bank.DebitOrCredit,
                    IsBuild = false
                };
                SmsUnitOfWork.TransactionDayRepository.Insert(smsTran);
                _logger.Log("Insert TransactionDay-->{0}", JsonConvert.SerializeObject( new
                {
                    cusDebit.AccountId, cusDebit.TransactionNumber, cusDebit.Amount
                }));
            }
            return await SmsUnitOfWork.SaveChangesAsync();
        }

        public async Task<int> BuilDMessage()
        {
            var listBuilds =  SmsUnitOfWork.TransactionDayRepository.GetAllNeedBuild();
            int countErr = 0;
            if (listBuilds == null || !listBuilds.Any()) return 0; 
            foreach (var trans in listBuilds.ToList())
            {
                var cus = trans.Customer;
                var dataBuild = new
                {
                    CustomerId = cus.Id,
                    Debit = trans.DebitOrCredit.Equals("C") ? SmsConfiguration.Current.BaseConfig.CreditFormat : SmsConfiguration.Current.BaseConfig.DebitFormat,
                    DebitValue = trans.Amount,
                    Time = trans.TransactionTime.ToString("HH:mm"),
                    CurrentValue = trans.CurrentBalance

                };
                var reqCus = new List<SmsCustomer> { trans.Customer };
                var message = DesignMessage(dataBuild, OnDebited);
                if (string.IsNullOrEmpty(message))
                {
                    _logger.LogError("Error building message -->{0} ", JsonConvert.SerializeObject(dataBuild)); 
                    countErr++;
                    continue;
                }

                var existed = await SmsUnitOfWork.RequestRepository.GetAllAsync(
                            x =>
                                x.Message.Equals(message) && x.Type == (short)(SmsType.NopRut) &&
                                x.OrderDate.Equals(OrderDate));
                if (existed.Any()) continue;
                _logger.Log("MessageDebis ==>{0}!", message);
                var smsRequest = new SmsRequest
                {
                    Id = Guid.NewGuid(),
                    Message = message,
                    CreatedTime = DateTime.Now,
                    Customers = reqCus,
                    IsSent = false,
                    OrderDate = OrderDate,
                    Type = (short)SmsType.NopRut,
                    IsBrandName = true,// IsBrandName(cus.Mobile)
                };
                SmsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                trans.IsBuild = true;
                SmsUnitOfWork.TransactionDayRepository.Update(trans);
                _logger.Log("Debit message--> " + message);  
            }

            var save = await SmsUnitOfWork.SaveChangesAsync();
            if (countErr > 0)
            {
                _logger.Log("Debit Building Err -->{0} ", countErr); 

            }
            _logger.Log(string.Format("Total Debit message had building--> {0} ", TotalMessage));
            return save;
        }

        public override int TotalMessage
        {
            get
            {
                return SmsUnitOfWork.RequestRepository.Count(x => x.Type == (short)SmsType.NopRut);
            }
        }
    }
}