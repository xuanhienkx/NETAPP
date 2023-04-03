using DSoft.Common.Domain.Services;
using DSoft.Common.Extensions;
using DSoft.Common.Models;
using DSoft.Common.Queries;
using DSoft.Common.Shared;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser.Commands;
using DSoft.MarketParser.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Security.Claims;

namespace DSoft.MarketParser.Handlers;

public class PrsMessagesMarketActionHandler : PersistentHandler<MarketInfo, DomainPersistentService>,
        IRequestHandler<MarketInfoCreateCommand, Result<bool>>,
        // query
        IRequestHandler<GetAllQuery<MarketInfo>, Result<List<MarketInfo>>>,
        IRequestHandler<GetByIdQuery<MarketInfo>, Result<MarketInfo>>

{
   // private readonly IHttpContextAccessor httpContextAccessor;
    private readonly ILogger<PrsMessagesMarketActionHandler> logger;
    private readonly IWebSocketService wsService;
    protected readonly IHttpContextAccessor HttpAccessor;
    public PrsMessagesMarketActionHandler(
        IMediator mediator,
        IPersistentService<DomainPersistentService> persistentService,
        ILocalizer localizer, 
        IHttpContextAccessor httpContextAccessor,
        ILogger<PrsMessagesMarketActionHandler> logger,
        IWebSocketService wsService)
        : base(mediator, persistentService, localizer)
    {

      this.HttpAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.wsService = wsService ?? throw new ArgumentNullException(nameof(wsService));
    }

    protected override ProjectionDefinition<MarketInfo> ExcludeGetProjection { get; }

    public async Task<Result<bool>> Handle(MarketInfoCreateCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var collection = PersistentService.GetCollection<MarketInfo>();


        var result = await Executor.TryAsync(async
                   () =>
                    {
                        var bag = request.MarketMessageData;
                        bag.TryGet($"{bag.MessageName}[-1].{ProviderConstants.TradingDate}", out string tradingDate);
                        bag.TryGet($"{bag.MessageName}[-1].{ProviderConstants.UpdateType}", out string updateType);
                        bag.TryGet($"{bag.MessageName}[-1].{ProviderConstants.SessionNumber}", out long sessionNumber);
                        bag.TryGet($"{bag.MessageName}[-1].{ProviderConstants.InputSequenceNumber}", out long inputSequenceNumber);
                        var messageModels = new MarketInfo()
                        {
                            MessageName = bag.MessageName,
                            TradingDate = tradingDate,
                            IsOverride = updateType.Equals(PrsUpdateType.Override.ToString()),
                            InputSequenceNumber = inputSequenceNumber,
                            SessionNumber = sessionNumber
                        };

                        var str = Pars(bag);
                        messageModels.Data = str;
                        // send notifier
                        var hfId = ObjectId.GenerateNewId().ToString();
                        logger.LogInformation("send client with Message Name:{1} hfId -{0}", hfId, bag.MessageName);
                        await wsService.SendHangfire(hfId, JsonConvert.SerializeObject(messageModels));

                        if (PersistentService.HasSession)
                            await collection.InsertOneAsync(PersistentService.Session, messageModels, cancellationToken: cancellationToken);
                        else
                            await collection.InsertOneAsync(messageModels, cancellationToken: cancellationToken);
                       
                        return true;
                    },
                   exception =>
                   {
                       logger.LogError(exception, $"insert message  file {request.MarketMessageData.MessageName}");
                   });



        return Result(result);
    }

    public async Task<Result<List<MarketInfo>>> Handle(GetAllQuery<MarketInfo> request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var collection = PersistentService.GetCollection<MarketInfo>();
        var result = await collection.AsQueryable().ToListAsync(cancellationToken);

        return Result(result);
    }

    public async Task<Result<MarketInfo>> Handle(GetByIdQuery<MarketInfo> request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await PersistentService.GetCollection<MarketInfo>()
            .Find(x => x.Id.Equals(request.Id)).SingleOrDefaultAsync(cancellationToken);
        return Result(result);
    }



    private string Pars(CsBag bag)
    {
        IDictionary<string, object> bagToJson = bag.GetDictionary();
        var data = bagToJson.Where(x => x.Key.IndexOf("[-1]") <= 0).GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
         .Select(group => group.Aggregate(new Dictionary<string, object>(), (obj, item) =>
         {
             obj[item.Key.Substring(item.Key.IndexOf(".") + 1)] = item.Value;
             return obj;
         })).ToList();

        var str = JsonConvert.SerializeObject(data);
        return str;
    }

}
