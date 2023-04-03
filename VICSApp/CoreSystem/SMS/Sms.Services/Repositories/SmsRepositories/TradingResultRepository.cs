using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SMS.Common.Configuration;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class TradingResultRepository : Repository<SmsTradingResult>, ITradingResultRepository
    {
        private readonly ISmsDataContext _smsContext;

        public TradingResultRepository(ISmsDataContext smsContext)
            : base(smsContext as DbContext)
        {
            this._smsContext = smsContext;
        }

        public IList<SmsTradingResult> GetTradings(bool isBuilded)
        {
            IList<SmsTradingResult> tradingResults =
                 _smsContext.TradingResults.Where(x => x.IsBuildMessage == isBuilded).ToList();
            return tradingResults;
        }

        public async Task<IList<SmsTradingResult>> GetTradingsAsync(bool isBuilded)
        {
            IList<SmsTradingResult> tradingResults = await
                 _smsContext.TradingResults.Where(x => x.IsBuildMessage == isBuilded).ToListAsync();
            return tradingResults;
        }

        private IList<SmsTradingResult> _listNeedBuild;

        public IList<MatchedMessageModel> GetAllNeedBuild()
        {
            IList<SmsTradingResult> tradingResults =
                _smsContext.TradingResults.Where(x => !x.IsBuildMessage).ToList();
            _listNeedBuild = tradingResults;
            if (!tradingResults.Any()) return null;
            IList<MatchedMessageModel> messageModels = tradingResults.GroupBy(x => new
            {
                x.Customer.Id,
                x.OrderNo,
                x.StockCode,
                x.OrderSide,
                x.OrderVolume,
                Price = x.MatchedPrice
            }).Select(item => new MatchedMessageModel
            {
                CustomerId = item.Key.Id,
                OrderNo = item.Key.OrderNo,
                StockCode = item.Key.StockCode,
                OrderSide = item.Key.OrderSide.Equals("B") ? SmsConfiguration.Current.BaseConfig.BuyFormat : SmsConfiguration.Current.BaseConfig.SellFormat,
                OrderVolume = (int)item.Key.OrderVolume,
                Price = item.Key.Price,
                Volume = (int)item.Sum(x => x.MatchedVolume),
                SbsReultId = item.Select(x=>x.SbsResultId).ToList()
            }).ToList();
            return messageModels;
        }

        public async Task<IList<MatchedMessageModel>> GetAllNeedBuildAsync()
        {
            IList<SmsTradingResult> tradingResults = await
                _smsContext.TradingResults.Where(x => !x.IsBuildMessage).ToListAsync();
            _listNeedBuild = tradingResults;
            if (!tradingResults.Any()) return null;
            IList<MatchedMessageModel> messageModels = tradingResults.GroupBy(x => new
            {
                x.Customer.Id,
                x.OrderNo,
                x.StockCode,
                x.OrderSide,
                x.OrderVolume,
                Price = x.MatchedPrice
            }).Select(item => new MatchedMessageModel
            {
                CustomerId = item.Key.Id,
                OrderNo = item.Key.OrderNo,
                StockCode = item.Key.StockCode,
                OrderSide = item.Key.OrderSide.Equals("B") ? SmsConfiguration.Current.BaseConfig.BuyFormat : SmsConfiguration.Current.BaseConfig.SellFormat,
                OrderVolume = (int)item.Key.OrderVolume,
                Price = item.Key.Price,
                Volume = (int)item.Sum(x => x.MatchedVolume)
            }).ToList();
            return messageModels;
        }

        public IEnumerable<SmsTradingResult> ListNeedBuild
        {
            get { return _listNeedBuild; }
        }

        public void SetBuilded(IList<SmsTradingResult> list)
        {
            foreach (var smsTradingResult in list)
            {
                smsTradingResult.IsBuildMessage = true;
                Update(smsTradingResult);
            }

        }
    }
}