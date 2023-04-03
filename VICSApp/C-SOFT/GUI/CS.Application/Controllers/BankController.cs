using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Application.Controllers
{
    public class BankController : Controller
    {
        private readonly IDataProvider dataProvider;

        public BankController(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }
        public Task<ActionResult> Index()
        {
            throw new System.NotImplementedException();
        }
        public async Task<Result<IList<BankModel>>> FilterBank(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return Result<IList<BankModel>>();

            var data = await dataProvider.GetList<BankModel>($"banks?filter={filter}");
            return data.IsSuccess ? Result(data.Value) : Result<IList<BankModel>>();
        }
        public async Task<Result<BankModel>> GetBank(string bankPlRlCode)
        {
            if (string.IsNullOrEmpty(bankPlRlCode))
                return Result<BankModel>();

            var data = await dataProvider.GetList<BankModel>($"banks?filter={bankPlRlCode}");
            return data.HasResult ? Result(data.Value.FirstOrDefault()) : Result<BankModel>();
        }
    }
}