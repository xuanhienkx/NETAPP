using System;
using System.Collections.Generic;
using System.Linq; 
using Newtonsoft.Json;
using SMS.Common; 
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models; 

namespace SMS.Business.Service.Services
{
    public interface IMatchedDataService
    {
        void InsertTrading();
        void BuilDMessage();

    }

    public class MatchedDataService : BaseDataService, IMatchedDataService
    {
        private readonly ILogger _logger;

        public MatchedDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork, ILogger logger)
            : base(smsUnitOfWork, sbsUnitOfWork)
        {
            
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        public List<string> CustomerWork()
        {
            return SmsUnitOfWork.CustomerRepository.GetCustomers(false).Select(x => x.Id).ToList();
        }

        public void InsertTrading()
        {
            try
            {
                var sbsTradings = SbsUnitOfWork.MatchedRepository.GetSbsTradings();
                if (sbsTradings == null || !sbsTradings.Any()) return;
                _logger.Log("Begin insert trading");
                foreach (var trade in sbsTradings)
                {
                    var cus = SmsUnitOfWork.CustomerRepository.GetCustomerWork(trade.CustomerId);
                    if (cus == null) continue;
                    var volume = SbsUnitOfWork.MatchedRepository.OrderVolum(trade.OrderNo);
                    var smsTrade = new SmsTradingResult
                    {
                        Id = Guid.NewGuid(),
                        ConfirmNo = trade.ConfirmNo,
                        ConfirmTime = trade.ConfirmTime,
                        MatchedPrice = trade.MatchedPrice,
                        MatchedVolume = trade.MatchedVolume,
                        OrderNo = trade.OrderNo,
                        OrderDate = trade.OrderDate,
                        OrderSide = trade.OrderSide,
                        StockCode = trade.StockCode,
                        IsBuildMessage = false,
                        OrderVolume = volume,
                        SbsResultId = trade.Id,
                        Customer = cus

                    };
                    SmsUnitOfWork.TradingResultRepository.Insert(smsTrade);
                }
                SmsUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }

        }

        public void BuilDMessage()
        {


            try
            {
                var list = SmsUnitOfWork.TradingResultRepository.GetAllNeedBuild();
                if (list == null || !list.Any()) return;

                int countErr = 0;
                _logger.Log("Building Matched message!!!");
                foreach (var it in list.GroupBy(x => new
                {
                    x.CustomerId,
                    x.OrderNo,
                    x.StockCode,
                    x.OrderSide,
                    x.OrderVolume
                }))
                {
                    if (it == null) continue;
                    var key = it.Key;
                    var customer = SmsUnitOfWork.CustomerRepository.GetCustomerWork(key.CustomerId);
                    if (customer == null || !customer.Mobile.IsNumber()) continue;
                    var obj = new MatchedModel
                    {
                        CustomerId = key.CustomerId,
                        OrderSide = key.OrderSide,
                        OrderVolume = key.OrderVolume,
                        StockCode = key.StockCode,
                        Matcheds = it.Select(x => new MatchedByOrderModel
                        {
                            Price = x.Price,
                            Volume = x.Volume
                        }).ToList()
                    };
                    var sbsResultThisId = it.Select(x => x.SbsReultId).ToList();
                    List<Guid> idsSbs = sbsResultThisId.SelectMany(itIds => itIds).ToList();
                    var reqCus = new List<SmsCustomer> { customer };
                    var message = DesignMessage(obj, OnMatched);
                    if (string.IsNullOrEmpty(message))
                    { 
                        _logger.Log("Errors build message Matched {0} !!!",
                            JsonConvert.SerializeObject(customer.Id));
                        countErr++;
                        continue;
                    }

                    var trades =
                        SmsUnitOfWork.TradingResultRepository.GetAll(
                            x => x.Customer.Id == obj.CustomerId
                                 && x.OrderNo == key.OrderNo
                                 && x.OrderVolume == key.OrderVolume
                                 && x.StockCode == obj.StockCode
                                 && idsSbs.Contains(x.SbsResultId)
                            );

                    //var existed =
                    //    SmsUnitOfWork.RequestRepository.Any(
                    //        x =>
                    //            x.Message.Equals(message) && x.Type == (short)(SmsType.KhopLenh) &&
                    //            x.OrderDate.Equals(OrderDate));
                    //if (existed)
                    //{
                    //    SmsUnitOfWork.TradingResultRepository.SetBuilded(trades);
                    //    continue;
                    //}
                    var smsRequest = new SmsRequest
                    {
                        Id = Guid.NewGuid(),
                        Message = message,
                        CreatedTime = DateTime.Now,
                        Customers = reqCus,
                        IsSent = false,
                        OrderDate = OrderDate,
                        Type = (short)SmsType.KhopLenh,
                        IsBrandName =true,// IsBrandName(customer.Mobile),
                        TradingResults = trades
                    };

                    SmsUnitOfWork.RequestRepository.InsertRequest(smsRequest);
                    SmsUnitOfWork.TradingResultRepository.SetBuilded(trades);
                    _logger.Log("Matched-->" + message); 
                }

                if (countErr > 0)
                {
                    _logger.Log("Matched Building Err -->{0} ", countErr); 
                }

                SmsUnitOfWork.SaveChanges();
                _logger.Log("Total message matched have build {0}", TotalMessage);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex);
            }
        }

        public override int TotalMessage
        {
            get { return SmsUnitOfWork.RequestRepository.Count(x => x.Type == (short)SmsType.KhopLenh); }
        }
    }
}