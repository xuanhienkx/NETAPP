using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Common.Models;
using SMS.Data.Services.EF.UnitsOfWork;
using SMS.DataAccess.Models;

namespace SMS.Business.Service.Services
{
    public interface IGetStatusProcessDataService
    {
        void GetReceiverSms(string orderDate);
        IList<SmsStatusResult> GetReceiverForTime(DateTime startDate, DateTime endDate);
        void GetMissReceiverAndInsert(DateTime startDate, DateTime endDate);
    }
    public class GetStatusProcessDataService : BaseDataService, IGetStatusProcessDataService
    {
        readonly SmsClient smsClient = ApiEmsConfiguration.Current.SmsClient;
        public GetStatusProcessDataService(ISmsUnitOfWork smsUnitOfWork, ISbsUnitOfWork sbsUnitOfWork)
            : base(smsUnitOfWork, sbsUnitOfWork)
        {
        }

        public override int TotalMessage => throw new NotImplementedException();

        public void GetReceiverSms(string orderDate)
        {

            var smsRequests = SmsUnitOfWork.RequestRepository.GetAll(x => x.IsSent && !string.IsNullOrEmpty(x.SmsIdResponse) && x.OrderDate == orderDate);

            foreach (var request in smsRequests)
            {
                if (SmsUnitOfWork.StatusResultRepository.IsExisted(request.SmsIdResponse, request.OrderDate))
                    continue;

                SmsReceiver status = ESmsServices.GetReceiverMessage(ESmsServices.OnGetStatusBrandName, new
                {
                    SmsId = request.IsBrandName ? string.Format("<REFID>{0}</REFID>", request.SmsIdResponse) : string.Format("<SMSID>{0}</SMSID>", request.SmsIdResponse),
                    Apikey = smsClient.Apikey,
                    Secretkey = smsClient.Secretkey
                });
                if (status != null && status.CodeResult == "100" && status.ReceiverList.Receiver.Any())
                {
                    bool allSuccess = status.ReceiverList.Receiver.All(x => x.SentResult);
                    foreach (var it in status.ReceiverList.Receiver)
                    {
                        var smsResult = new SmsStatusResult
                        {
                            CodeResult = status.CodeResult,
                            OrderDate = request.OrderDate,
                            Transdate = request.CreatedTime,
                            Id = Guid.NewGuid(),
                            SmsRequestId = request.Id,
                            SmsId = request.SmsIdResponse,
                            IsSent = it.IsSent,
                            SentResult = it.SentResult,
                            Phone = it.Phone,
                            IsAllSuccess = allSuccess
                        };

                        SmsUnitOfWork.StatusResultRepository.InsertStatus(smsResult);
                    }

                }
            }
            SmsUnitOfWork.SaveChanges();
        }

        public IList<SmsStatusResult> GetReceiverForTime(DateTime startDate, DateTime endDate)
        {

            var statrD = startDate.Date;
            var endD = endDate.Date.AddHours(23).AddMinutes(59).AddMilliseconds(59);
            var listComplate =
                SmsUnitOfWork.StatusResultRepository.GetAll(
                    x => x.IsAllSuccess && x.Transdate >= statrD && x.Transdate <= endD);
            return listComplate;
        }

        public void GetMissReceiverAndInsert(DateTime startDate, DateTime endDate)
        {
            var statrD = startDate.Date;
            var endD = endDate.Date.AddHours(23).AddMinutes(59).AddMilliseconds(59);
            var listComplate =
                SmsUnitOfWork.StatusResultRepository.GetAll(
                    x => x.IsAllSuccess && x.Transdate >= statrD && x.Transdate <= endD)
                    .Select(s => s.SmsId)
                    .Distinct();
            var listquest =
                SmsUnitOfWork.RequestHistRepository.GetAll(
                    x =>
                        x.CreatedTime >= statrD && x.CreatedTime <= endD && 
                        !string.IsNullOrEmpty(x.SmsIdResponse)).Select(r => new
                        {
                            SmsIdResponse = r.SmsIdResponse,
                            Id = r.RequestId,
                            OrderDate = r.OrderDate,
                            CreatedTime = r.CreatedTime,
                            IsBrandName = r.IsBrandName
                        }).Distinct();
            var listNeed = listquest.Where(x => !listComplate.Contains(x.SmsIdResponse)).ToList();
            if(!listNeed.Any()) return;
            foreach (var request in listNeed)
            {
                SmsReceiver status = ESmsServices.GetReceiverMessage(ESmsServices.OnGetStatusBrandName, new
                {
                    SmsId = request.IsBrandName ? string.Format("<REFID>{0}</REFID>", request.SmsIdResponse) : string.Format("<SMSID>{0}</SMSID>", request.SmsIdResponse),
                    Apikey = smsClient.Apikey,
                    Secretkey = smsClient.Secretkey
                });
                if (status != null && status.CodeResult == "100" && status.ReceiverList.Receiver.Any())
                {
                    bool allSuccess = status.ReceiverList.Receiver.All(x => x.SentResult);
                    foreach (var it in status.ReceiverList.Receiver)
                    {
                        var smsResult = new SmsStatusResult
                        {
                            CodeResult = status.CodeResult,
                            OrderDate = request.OrderDate,
                            Transdate = request.CreatedTime,
                            Id = Guid.NewGuid(),
                            SmsRequestId = request.Id,
                            SmsId = request.SmsIdResponse,
                            IsSent = it.IsSent,
                            SentResult = it.SentResult,
                            Phone = it.Phone,
                            IsAllSuccess = allSuccess
                        };
                        if (SmsUnitOfWork.StatusResultRepository.IsExisted(request.SmsIdResponse, request.OrderDate, it.Phone))
                            SmsUnitOfWork.StatusResultRepository.UpdateStatus(smsResult);
                        else
                            SmsUnitOfWork.StatusResultRepository.InsertStatus(smsResult);
                       
                    }
                    
                }
                SmsUnitOfWork.SaveChanges();
            } 
        }
    }
}