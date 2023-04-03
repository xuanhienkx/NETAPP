using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Application.Controllers
{
    public class AssetController : Controller
    {
        private readonly IDataProvider dataProvider;
        private readonly ITranslator translator;

        public AssetController(IDataProvider dataProvider, ITranslator translator)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }
        public Task<ActionResult> Index()
        {
            throw new System.NotImplementedException();
        }
        public async Task<Result<IList<AssetModel>>> FilterAsset(string filter, AssetType type = AssetType.Stock)
        {
            if (string.IsNullOrEmpty(filter))
                return Result<IList<AssetModel>>();

            var data = await dataProvider.GetList<AssetModel>($"assets?code={filter}&type={type}");
            return data.IsSuccess ? Result(data.Value) : Result<IList<AssetModel>>();
        }

        public async Task<Result<AssetModel>> GetStock(string code)
        {
            if (string.IsNullOrEmpty(code))
                return Result<AssetModel>();  

            var data = await dataProvider.GetList<AssetModel>($"assets?code={code}&type={AssetType.Stock}");
            return data.HasResult ? Result(data.Value.SingleOrDefault()) : Result<AssetModel>();
        }
    }
}