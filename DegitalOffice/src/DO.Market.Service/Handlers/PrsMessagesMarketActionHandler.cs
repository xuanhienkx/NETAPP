using BO.Core.DataCommon.Entities;
using DO.Common;
using DO.Common.Contract.Enums;
using DO.Common.Contract.Models;
using DO.Common.Interfaces;
using DO.Common.Std;
using DO.Common.Std.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DO.Market.Service.Handlers;

public class PrsMessagesMarketActionHandler : BaseOnlyResponseActionHandler
{
    protected readonly IDomainService<long, MarketInfoRequestModel, MarketInfoRequest> Service;
    ILogger<PrsMessagesMarketActionHandler> logger;

    public PrsMessagesMarketActionHandler(
        IDomainService<long, MarketInfoRequestModel, MarketInfoRequest> service, ILogger<PrsMessagesMarketActionHandler> logger)
    {
        this.Service = service ?? throw new ArgumentNullException(nameof(service));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override string BussinessId => BusinessIdProviderConstant.MarketPrs;

    public override async Task<bool> ProcessMessageReceived(CsBag bag)
    {
        bag.TryGet(BusinessIdProviderConstant.MessageName, out string messageName);
        bag.TryGet(BusinessIdProviderConstant.UpdateType, out string updateType);
        IDictionary<string, object> bagToJson = bag.GetDictionary();
        var data = bagToJson.GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
         .Select(group => group.Aggregate(new Dictionary<string, object>(), (obj, item) =>
         {
             obj[item.Key.Substring(item.Key.IndexOf(".") + 1)] = item.Value;
             return obj;
         })).ToList();
        var str = JsonConvert.SerializeObject(data);

        var model = new MarketInfoRequestModel()
        {
            ActionType = updateType == PrsUpdateType.Override.ToString() ? ActionType.Update : ActionType.Insert,
            MessageName = messageName,
            Content = str,
            ModifiedDate = DateTime.Now,

        };
        logger.LogInformation(str);
        //  await Service.Insert(model);
        return true;

    }
}
