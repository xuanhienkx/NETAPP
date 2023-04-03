using AutoMapper;
using CS.Common;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Enums;
using CS.Common.MessageQueue;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Core.Service;
using CS.Domain.Audit.Entities;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.VSD.Service.Controllers
{
    /// <summary>
    /// This controller comunicate between users and core. Any route contains "gateway" must be exclude because it is used for service communicate
    /// </summary>
    [Route("vsd")]
    public class CustodyRequestController : ApiControllerBase
    {
        private readonly INotificationPublisher notificationPublisher;
        private readonly IEnumerable<IBusinessActionHandler> businessActionHandlers;

        private static readonly IReadOnlyList<CustodyRequestStatus> AllowRequestStatus = new List<CustodyRequestStatus>
        {
            CustodyRequestStatus.Published,
            CustodyRequestStatus.FailureRejected,
            CustodyRequestStatus.PublishedFailed,
            CustodyRequestStatus.RequestRejected
        };

        private readonly IDomainService<long, CustodyRequestModel, CustodyRequest> service;
        private readonly IMessagePublisherFactory publisherFactory;

        public CustodyRequestController(
                    IEnumerable<IBusinessActionHandler> businessActionHandlers,
                    IDomainService<long, CustodyRequestModel, CustodyRequest> service,
                    IMessagePublisherFactory publisherFactory,
                    IDomainDataHandler domainDataHandler,
                    ILogger<CustodyRequestController> logger,
                    IStringLocalizer<CustodyRequestController> localizer,
                    IMapper mapper,
                    INotificationPublisher notificationPublisher)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.notificationPublisher = notificationPublisher ?? throw new ArgumentNullException(nameof(notificationPublisher));
            this.businessActionHandlers = businessActionHandlers ?? throw new ArgumentNullException(nameof(businessActionHandlers));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.publisherFactory = publisherFactory ?? throw new ArgumentNullException(nameof(publisherFactory));
        }

        [HttpGet]
        public async Task<IActionResult> Get(string business)
        {
            return await ResultAsync(async () => await service.Query.FilterAsync(x => x.BusinessId == business), false);
        }
        [HttpGet("ConfirmRequests")]
        public async Task<IActionResult> GetConfirmRequests()
        {
            var businessList = new[]
            {
                BusinessIdProviderConstant.TradingResultConfirmation,
                BusinessIdProviderConstant.AccountListConfirmation,
                BusinessIdProviderConstant.SecuritiesBalanceConfirmation
            };
            return await ResultAsync(async () => await service.Query.FilterAsync(x => businessList.Contains(x.BusinessId)), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await ResultAsync(async () => await service.Query.GetAsync(id), false);
        }

        [HttpPost]
        public async Task<IActionResult> PublishRequest([FromBody] CustodyRequestModel request)
        {
            if (!CheckModelStateValidation(request))
                return Result(request);

            if (!AllowRequestStatus.Contains(request.Status))
            {
                DomainDataHandler.RaiseError(Localizer["VSDPublishFailed_InvalidRequestStatus"]);
                return Result(request);
            }

            var contentType = request.GetType().Assembly.GetType(request.ContentClrType);
            var contentModel = request.Content.Base64ProtoBufDeserialize(contentType);
            if (contentModel == null)
            {
                DomainDataHandler.RaiseError(Localizer["VSDPublishFailed_ContentObject_NotFound"]);
                return Result(request);
            }

            var handler = businessActionHandlers.FirstOrDefault(x => x.BussinessId == request.BusinessId);
            if (handler == null)
            {
                DomainDataHandler.RaiseError(Localizer["VSDHandler_NotFound"]);
                return Result(request);
            }

            // validate the request model
            if (!await handler.ValidateModelContent(contentModel))
            {
                // DomainDataHandler.RaiseEvent(new ErrorEvent(Localizer["VSDPublishFailed_InvalidRequestStatus"]));
                return Result(contentModel);
            }

            return await ResultAsync(async () =>
            {
                // create new request
                var newRequest = await service.Insert(request);
                Logger.LogDebug("New request created: {0}", newRequest.Id);

                // create message to publish
                var messageTypes = new[] { MessageQueueType.VsdPublisedMessage };
                var message = new Message<object>(newRequest.BusinessId, BusinessIdProviderConstant.MessageRequestCommandPublished)
                {
                    Model = contentModel,
                    ModelClrType = newRequest.ContentClrType,
                    ExtendData =
                    {
                        {BusinessIdProviderConstant.RequestDate, newRequest.CreatedDate},
                        {BusinessIdProviderConstant.TransactionReferenceNumber, newRequest.Id},
                        {BusinessIdProviderConstant.Proprietary, "NORMAL"},
                        {BusinessIdProviderConstant.MessageFunction, newRequest.RequestType.DisplayName()},
                        {BusinessIdProviderConstant.MessagePriority, newRequest.Priority.DisplayName()},
                        {BusinessIdProviderConstant.DeliveryMonitor, $"{(int) newRequest.Priority}"},
                        {BusinessIdProviderConstant.VsdBicode, newRequest.VsdBicCode}
                    }
                };

                // register request event to notificator
                await notificationPublisher.Register(context => context.Data[$"CustodyRequest_{newRequest.Id}"] = Request.Headers[GlobalConstantsProvider.RequestId]);

                // publish to VSD
                var published = await publisherFactory.Publish(message, messageTypes);
                if (published)
                {
                    // send the old request to history
                    if (request.Id != 0)
                    {
                        await DomainDataHandler.SendCommand(
                            new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));
                        Logger.LogDebug("Move the request to history: {0}", request.Id);

                        // delete old request
                        await service.Delete(request.Id, true);
                        Logger.LogDebug("Deleted request: {0}", request.Id);
                    }

                    // inform the sucess publish to update the changes in content model
                    await handler.UpdateContentStatus(message, false);

                    return newRequest;
                }
                else
                {
                    // delete the new request
                    await service.Delete(newRequest.Id, true);
                    Logger.LogDebug("Deleted request: {0}", newRequest.Id);

                    // inform the publish failure
                    await handler.UpdateContentStatus(message, true);

                    return request;
                };
            });
        }

        /// <summary>
        /// Delete must create the new cancel to pending request to VSD.
        /// However this process is not supported now. The delete is just delete the request from
        /// database for failed request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="businessId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{businessId}")]
        public async Task<IActionResult> DeleteRequest(long id, string businessId)
        {
            var handler = businessActionHandlers.FirstOrDefault(x => x.BussinessId == businessId);
            if (handler == null)
            {
                DomainDataHandler.RaiseError(Localizer["VSDHandler_NotFound"]);
                return Result(id);
            }

            return await ResultAsync(async () =>
            {
                var request = service.Query.Get(id);
                var contentType = request.GetType().Assembly.GetType(request.ContentClrType);
                var contentModel = request.Content.Base64ProtoBufDeserialize(contentType);

                // update content status for delete
                await handler.UpdateContentStatus(contentModel, true);

                // udpate customer status
                //customer.Status = customer.Status == CustomerStatus.PendingClose ? CustomerStatus.Open : CustomerStatus.Initial;

                // sent the old request to history
                await DomainDataHandler.SendCommand(new AuditHistoryCommand(Mapper.Map<CustodyRequestHistory>(request)));

                // delete old request
                await service.Delete(request.Id);

                return true;
            });
        }
    }
}
