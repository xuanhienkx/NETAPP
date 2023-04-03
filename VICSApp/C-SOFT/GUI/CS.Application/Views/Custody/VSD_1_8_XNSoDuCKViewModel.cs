using System;
using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CS.Application.Views.Custody
{
    public class VSD_1_8_XNSoDuCKViewModel : RequestPublishViewModel
    {
        public VSD_1_8_XNSoDuCKViewModel(CustodyRequestModel model) : base(model)
        {
            ViewType = ExecuteType.View;
        }
        public DataTable ListVsvReports { get; set; }
        public override string Title => GetDialogTitle();
        public AssetModel Stock { get; set; }
        public VsdReportModel VsdReportModel { get; set; }

        public override async Task LoadData()
        {
            if (Model.ContentModel != null)
            {
                var content = (Custody598Confirm)Model.ContentModel;
                Model.ContentModel = content;
                ListVsvReports = await Invoke<CustodyController, DataTable>(c => c.GetFileCsvData(content.LogicalName));
                Stock = await Invoke<AssetController, AssetModel>(c => c.GetStock(content.StockCode));
                NotifyPropertyChanged(() => ListVsvReports);
                NotifyPropertyChanged(() => Stock);
            }
            else
            {
                Model.ContentModel = new Custody598Confirm();
                Model.ContentClrType = typeof(Custody598Confirm).FullName;
            }
        }
        public EnumCollection<BoardType> BoardTypes { get; } = new EnumCollection<BoardType>(BoardType.Hnx, BoardType.Hose, BoardType.Upcom, BoardType.Dccny);
        public EnumCollection<ConfirmType> ConfirmTypes { get; } = new EnumCollection<ConfirmType>();
        public override bool ContentModelValid => Model.ContentModel != null && Model.ContentModel is Custody598Confirm model && model.IsValid;
        public bool IsConfirm { get; set; }
        private string GetDialogTitle()
        {
            string key;
            switch (Model.BusinessId)
            {
                case BusinessIdProviderConstant.LoggingAdditionalSecurities:
                    key = "CustodyViewModel_VSD_1_2_4_KyGuiCKTuQuyen_Dialog_Title";
                    break;
                case BusinessIdProviderConstant.LimitTransferChanges:
                    key = "CustodyViewModel_VSD_1_7_TBThayDoiChuyenNhuong_Dialog_Title";
                    break;
                case BusinessIdProviderConstant.AccountListConfirmation:
                    key = "CustodyViewModel_VSD_2_2_XNDSThucHienQuyen_Dialog_Title";
                    IsConfirm = true;
                    ViewType = UI.Common.Interfaces.ExecuteType.Edit;
                    break;
                case BusinessIdProviderConstant.TradingResultConfirmation:
                    key = "CustodyViewModel_VSD_3_1_XNKetQuaGD_Dialog_Title";
                    IsConfirm = true;
                    ViewType = UI.Common.Interfaces.ExecuteType.Edit;
                    break;
                case BusinessIdProviderConstant.ClearingAndSettlementConfirmation:
                    key = "CustodyViewModel_VSD_3_2_TBKetQuaBuTru_Dialog_Title";
                    break;
                case BusinessIdProviderConstant.ReportsRequested:
                    key = "CustodyViewModel_VSD_4_TraXuatBC_Dialog_Title";
                    break;
                case BusinessIdProviderConstant.SecuritiesBalanceConfirmation:
                default:
                    key = "CustodyViewModel_VSD_1_8_XNSoDuCK_Dialog_Title";
                    IsConfirm = true;
                    ViewType = UI.Common.Interfaces.ExecuteType.Edit;
                    break;
            }
            return Translate(key);
        }

        public override string GetViewName()
        {
            return BusinessIdProviderConstant.SecuritiesBalanceConfirmation;
        }
        protected override AccessRight AccessRight => AccessRight.CustodyReport;
    }
}
