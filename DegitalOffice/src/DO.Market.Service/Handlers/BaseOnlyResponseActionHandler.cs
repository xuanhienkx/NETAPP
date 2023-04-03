using DO.Common;
using DO.Common.Contract.MarketModels;
using DO.Common.Std;
using Newtonsoft.Json;

namespace DO.Market.Service.Handlers;

public abstract class BaseOnlyResponseActionHandler : IBusinessActionHandler
{

    public abstract Task<bool> ProcessMessageReceived(CsBag bag);
    public Task<CsBag> PrepareBagToBuildMessage(object model)
    {
        throw new NotImplementedException();
    }
    public abstract string BussinessId { get; }
    public Task<bool> ProcessMessageInformed(CsBag bag)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateModelContent(object contentModel)
    {
        throw new NotImplementedException();
    }

    public Task UpdateContentStatus(object contentModel, bool isRevertState)
    {
        throw new NotImplementedException();
    }
    private void Pars(CsBag bag)
    {
        bag.TryGet(BusinessIdProviderConstant.MessageName, out string messageName);
        bag.TryGet(BusinessIdProviderConstant.UpdateType, out string updateType);
        bag.TryGet(BusinessIdProviderConstant.TradingDate, out string tradingDate);
        IDictionary<string, object> bagToJson = bag.GetDictionary();
        var data = bagToJson.GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
         .Select(group => group.Aggregate(new Dictionary<string, object>(), (obj, item) =>
         {
             obj[item.Key.Substring(item.Key.IndexOf(".") + 1)] = item.Value;
             return obj;
         })).ToList();

        var str = JsonConvert.SerializeObject(data);
        var messageModels = new PrsMessageModel()
        {
            MessageName = messageName,
            UpdateType = updateType,
            Data = str,
            TradingDate = tradingDate

        };
    }
}
