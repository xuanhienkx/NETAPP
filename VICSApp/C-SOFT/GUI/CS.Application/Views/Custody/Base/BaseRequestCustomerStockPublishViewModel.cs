using CS.Application.Controllers;
using CS.UI.Common;
using CS.UI.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;

namespace CS.Application.Views.Custody.Base
{
    public abstract class BaseRequestCustomerStockPublishViewModel<T> : BaseRequestCustomerPublishViewModel<T>, IVsdStockCustmerViewModel where T : VsdCustomerStock, new()
    {
        protected BaseRequestCustomerStockPublishViewModel(CustodyRequestModel model) : base(model)
        {
            FilterStockCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterStock(f));

            AddOnPropertyChangeListener(() => SuggestionStock, () => UpdateSuggestionStock());
            AddOnPropertyChangeValidator(() => SuggestionStock,
                () => Stock == null
                    ? Translate("CustodyView_Stock_Validation")
                    : null);
        }

        protected async Task<IEnumerable> FilterStock(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;

            return await Invoke<AssetController, IList<AssetModel>>(c => c.FilterAsset(filter));
        }
        public EnumCollection<AssetSubType> StockTypes { get; } = new EnumCollection<AssetSubType>(new List<AssetSubType>() { AssetSubType.None });
        public EnumCollection<ActivityType> ActivitiesItems { get; } = new EnumCollection<ActivityType>();
        public EnumCollection<UnitType> UnitTypes { get; } = new EnumCollection<UnitType>();
        public AssetModel SuggestionStock { get => Get<AssetModel>(); set => Set(value); }
        public ICommand FilterStockCommand { get; }
        public AssetModel Stock { get => Get<AssetModel>(); set => Set(value); }
        public override async Task LoadDataExtend(T model)
        {
            Stock = await Invoke<AssetController, AssetModel>(c => c.GetStock(model.Code));
        }

        private void UpdateSuggestionStock()
        {
            if (SuggestionStock == null)
                return;
            var model = (T)Model.ContentModel;
            Stock = SuggestionStock;
            model.SubType = Stock.SubType;
            model.Code = Stock.Code;
            model.StockCountryCode = Stock.CountryCode;
            model.StockName = Stock.Name;
        }

    }
}