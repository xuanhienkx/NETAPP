using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.Application.Controllers
{
    public class ExchangeStockController: Controller
    {
        private readonly IDataProvider dataProvider;

        public ExchangeStockController(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public Task<ActionResult> Index()
        {
            throw new System.NotImplementedException();
        }
        public async Task<Result<IList<ExchangeStockModel>>> FilterExchange(string filter)
        { 
            var data = await dataProvider.GetList<ExchangeStockModel>($"exchange?filter={filter}");
            return data.IsSuccess ? Result(data.Value) : Result<IList<ExchangeStockModel>>();
        } 
    }
}