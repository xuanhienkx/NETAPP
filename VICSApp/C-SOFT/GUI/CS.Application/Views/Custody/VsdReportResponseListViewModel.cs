using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Std.Extensions;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Custody
{
    public class VsdReportResponseListViewModel : ListViewModel<long, FileActModel>
    {
        public VsdReportResponseListViewModel()
        {
            BuyRightCommand = new RelayCommand(ShowDialogBuyRight, () => CanExecuteRight);
            MoveRightCommand = new RelayCommand(ShowDialogMoveRight, () => CanExecuteRight);
            ViewConfirmListCommand = new RelayCommand(()=> Invoke<CustodyController>(c => c.ViewConfirmList()), () => ListModels!= null);
        }
        protected override Task<IList<FileActModel>> GetList() => Invoke<CustodyController, IList<FileActModel>>(c => c.GetReportList());

        protected override Task<State<bool>> Delete()
        {
            throw new System.NotImplementedException();
        } 
        protected override bool CanOpen(bool isNew) => SelectedModel != null && !Shell.IsBusy; 

        protected override void Open(bool isNew)
        {
            var contentmodel = new Custody598Confirm()
            {
                ReportCode = SelectedModel.ReportCode,
                LogicalName = SelectedModel.LogicalName,
                OrigTransferRef = SelectedModel.OrigTransferRef,
                ConfirmType = ConfirmType.Confirm,
                StockCode = SelectedModel.StockCode,
                FileActId = SelectedModel.Id,
                ReportStatus = SelectedModel.ReportStatus
            };
            var requestMode = new CustodyRequestModel(SelectedModel.BusinessId)
            {
                Content = contentmodel.Base64ProtoBufSerialize(),
                ContentClrType = typeof(Custody598Confirm).FullName,
                ContentModel = contentmodel
            };

            var viewType = SelectedModel.ReportType == ReportType.Confirm ? ExecuteType.Edit : ExecuteType.View;
            Invoke<CustodyController>(c =>
                c.ShowRequestPublishDialog(this.SelectedModel.BusinessId, requestMode, viewType));
        }
        private void ShowDialogBuyRight()
        {
            var contentModel = new Custody565Model()
            {
                OrigTransferRef = SelectedModel.OrigTransferRef,
                Code = SelectedModel.StockCode,
            };
            var requestMode = new CustodyRequestModel(BusinessIdProviderConstant.RegisterRightToBuyAdditionalStock)
            {
                Content = contentModel.Base64ProtoBufSerialize(),
                ContentClrType = typeof(Custody565Model).FullName,
                ContentModel = contentModel
            };

            Invoke<CustodyController>(c =>
                c.ShowRequestPublishDialog(BusinessIdProviderConstant.RegisterRightToBuyAdditionalStock, requestMode, ExecuteType.Edit));
        }

        private void ShowDialogMoveRight()
        {
            var contentModel = new Custody542RightTranferModel()
            {
                OrigTransferRef = SelectedModel.OrigTransferRef,
                Code = SelectedModel.StockCode,
            };
            var requestMode = new CustodyRequestModel(BusinessIdProviderConstant.TransferRightToBuyAdditionalStock)
            {
                Content = contentModel.Base64ProtoBufSerialize(),
                ContentClrType = typeof(Custody542TranferModel).FullName,
                ContentModel = contentModel
            };

            Invoke<CustodyController>(c =>
                c.ShowRequestPublishDialog(BusinessIdProviderConstant.TransferRightToBuyAdditionalStock, requestMode, UI.Common.Interfaces.ExecuteType.Edit));
        }
        public bool CanExecuteRight
        {
            get => Get<bool>();
            set => Set(value);
        }
        public override void OnSelectedModelChanged()
        {
            CanExecuteRight = SelectedModel != null && SelectedModel.ReportCode.Equals("CA012");
            NotifyPropertyChanged(() => CanExecuteRight);
        }
        public ICommand BuyRightCommand { get; }
        public ICommand MoveRightCommand { get; }
        public ICommand ViewConfirmListCommand { get; }
        public override string Title => Translate("VsdReportResponseViewModel_Title");
        public override string SubTitle => Translate("VsdReportResponseViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.CustodyReport;
    }
}