using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Enums;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Core.Service.Base;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.VSD.Service.Handlers
{
    public abstract class BaseBusinessActionHandler<T> : IBusinessActionHandler
    {
        private readonly IValidationService validationService;
        protected readonly ICustomerRepository CustomerRepository;
        protected readonly IDomainService<long, CustodyRequestModel, CustodyRequest> Service;
        protected readonly IModelMapperService MappingService;
        protected readonly IDomainDataHandler DomainDataHandler;
        protected readonly IMapper Mapper;
        protected readonly IStringLocalizer Localizer;
        protected readonly ILogger Logger;

        protected BaseBusinessActionHandler(IValidationService validationService,
            ICustomerRepository customerRepository,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IModelMapperService mappingService,
            IDomainDataHandler domainDataHandler,
            IMapper mapper,
            IStringLocalizer localizer,
            ILogger logger)
        {
            this.validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            this.CustomerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            this.Service = service ?? throw new ArgumentNullException(nameof(service));
            this.MappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            this.DomainDataHandler = domainDataHandler ?? throw new ArgumentNullException(nameof(domainDataHandler));
            this.Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public abstract string BussinessId { get; }
        public abstract Task<bool> ProcessMessageApprovedReceived(CsBag bag);
        public abstract Task<string> ProcessMessageRejectedReceived(CsBag bag);
        /// <summary>
        /// Request accepted from VSD
        /// </summary>
        /// <param name="bag"></param>
        /// <returns></returns>
        public async Task<bool> ProcessMessageReceived(CsBag bag)
        {
            bag.TryGet(BusinessIdProviderConstant.TransactionReferenceNumber, out string referenceNumber);

            var hasrequestId = long.TryParse(referenceNumber, out long requestId);

            var isHashRequest = hasrequestId && requestId > 0;

            Logger.LogInformation($"{BussinessId} :MessageId {bag[BusinessIdProviderConstant.MessageId]} Ref number: {referenceNumber}");

            if (bag.TryGet(BusinessIdProviderConstant.ConfirmCode, out string status) && status.Equals(BusinessIdProviderConstant.Rejected))
            {
                //Process receiver VSD Rejected  
                if (!isHashRequest)
                    return false;

                var requestStatus = CustodyRequestStatus.RequestRejected;
                var notes = await ProcessMessageRejectedReceived(bag);
                Logger.LogError($"VSD confirm error: {notes}"); 

                if (!IsExitedRequstOnDb(requestId, out var request))
                {
                    return true;
                }
                await Service.UpdateSpecific(requestId, custodyRequest =>
                {
                    custodyRequest.Status = requestStatus;
                    custodyRequest.Notes = $"{status} => {notes}";
                    custodyRequest.ModifiedDate = DateTime.UtcNow;
                });
                return true;
            }
            //Process receiver VSD Appoved 
            return await TryAsync(async () =>
             {
                 var result = await ProcessMessageApprovedReceived(bag);
                 if (!isHashRequest)
                     return true;


                 if (!IsExitedRequstOnDb(requestId, out CustodyRequestModel request))
                 {
                     return true;
                 }

                 if (result)
                 {
                     request.Status = CustodyRequestStatus.Finished;
                     await DomainDataHandler.SendCommand(
                         new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
                     Logger.LogDebug($"Delete request {BussinessId} -Id {requestId}");
                     await Service.Delete(requestId, true);
                 }
                 else
                 {
                     await Service.UpdateSpecific(requestId, custodyRequest =>
                     {
                         custodyRequest.Status = CustodyRequestStatus.ApprovalPending;
                         custodyRequest.Notes = $"API not jet implement Approved when request message {typeof(T).Name}";
                         custodyRequest.ModifiedDate = DateTime.UtcNow;
                     });
                 }

                 return true;

             }, async ex =>
            {
                Logger.LogError(ex, $"Project {BussinessId} - {referenceNumber} Error");

                if (isHashRequest && hasrequestId)
                {
                    if (IsExitedRequstOnDb(requestId, out var request))
                    {
                        await Service.UpdateSpecific(requestId, custodyRequest =>
                        {
                            custodyRequest.Status = CustodyRequestStatus.ApprovalPending;
                            custodyRequest.Notes = $"Api process approved error:{ex.Message}";
                            custodyRequest.ModifiedDate = DateTime.UtcNow;
                        });
                    }
                }
            });
        }

        private bool IsExitedRequstOnDb(long requestId, out CustodyRequestModel request)
        {
            request = Service.Query.Get(requestId);

            if (request == null || request.Id == 0)
            {
                Logger.LogInformation($"Not found request {requestId}");
                return false;
            }
            return true;
        }
        public virtual IDictionary<string, object> ExtendBag(IDictionary<string, object> dictionary, T model)
        {
            return dictionary;
        }
        public Task<CsBag> PrepareBagToBuildMessage(object model)
        {
            // build all field to 
            if (!(model is T custodyModel))
                return Task.FromResult(new CsBag());

            var dictionary = MappingService.Serialize(custodyModel);
            dictionary.Remove("PropertiesChanged");
            dictionary.Remove("EnablePropertyChange");
            var extendBag = ExtendBag(dictionary, custodyModel);
            return Task.FromResult(new CsBag(extendBag));
        }

        public async Task<bool> ProcessMessageInformed(CsBag bag)
        {
            var requestStatus = CSEnum.Parse<CustodyRequestStatus>(bag[BusinessIdProviderConstant.RequestStatus]);


            var referenceNunber = bag[BusinessIdProviderConstant.TransactionReferenceNumber].ToString();
            if (!long.TryParse(referenceNunber, out long requestId))
                return false;

            var request = Service.Query.Get(requestId);

            if (request == null)
            {
                Logger.LogInformation($"Not found request {requestId}");
                return true;
            }
            var notes = bag[BusinessIdProviderConstant.RejectionMessage]?.ToString();
            Logger.LogDebug($"Update custodyRequest Status:{requestStatus}, notes: {notes} ");

            var model = request.Content.Base64ProtoBufDeserialize<T>();
            await ProcessExtentInformed(request, model);

            if (requestStatus == CustodyRequestStatus.Published)
                return true;

            await Service.UpdateSpecific(requestId, custodyRequest =>
            {
                custodyRequest.Status = requestStatus;
                custodyRequest.Notes = notes;
                custodyRequest.ModifiedDate = DateTime.UtcNow;
            });

            return true;
        }

        public virtual Task ProcessExtentInformed(CustodyRequestModel request, T model)
        {
            return Task.CompletedTask;
        }

        public async Task<bool> ValidateModelContent(object contentModel)
        {
            if (!(contentModel is T custody))
                return false;

            if (!validationService.Validate(custody))
                return false;
            if (custody is IReversionEntity<Guid> modelVerion)
            {
                if (await CustomerRepository.ValidateVersion(modelVerion.Id, modelVerion.Version))
                    return true;

                DomainDataHandler.RaiseError(string.Format(
                    Localizer["VSDPublishFailed_Customer_NotSameVersion"],
                    modelVerion.Version));
                return false;
            }
            return ExtendValidtion(custody);
        }

        public virtual bool ExtendValidtion(T model)
        {
            return true;
        }

        public virtual Task UpdateContentStatus(object contentModel, bool isRevertState)
        {
            return Task.CompletedTask;
        }
        protected async Task<TR> TryAsync<TR>(Func<Task<TR>> action, Action<Exception> error)
        {
            try
            {
                var result = await action();
                return result;
            }
            catch (Exception ex)
            {
                error?.Invoke(ex);
                return default(TR);
            }
        }
    }
}