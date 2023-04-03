using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;
using CS.UI.Common; 
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Custody
{
    public class RequestConfirmListViewModel : ListViewModel<long, CustodyRequestModel>
    {
        public RequestConfirmListViewModel()
        {
            ShowPublishDialogCommand = new RelayCommand<ExecuteType>(
                p => Invoke<CustodyController>(c => c.ShowRequestPublishDialog(SelectedModel.BusinessId, SelectedModel, p)), CanPublish); 
        }
        private bool CanPublish(ExecuteType dialogType)
        {
            return dialogType == ExecuteType.New ||
                   (dialogType == ExecuteType.View && SelectedModel != null) ||
                   (dialogType == ExecuteType.Edit && SelectedModel != null && CanDelete());
        }
        public ICommand ShowPublishDialogCommand { get; }

        protected override async Task<IList<CustodyRequestModel>> GetList()
        {
            var list = await Invoke<CustodyController, IList<CustodyRequestModel>>(c => c.ConfirmRequest());
            foreach (var model in list)
            {
                if (model != null && model.ContentModel == null &&
                    !string.IsNullOrEmpty(model.ContentClrType) && !string.IsNullOrEmpty(model.Content))
                {
                    var type = model.GetType().Assembly.GetType(model.ContentClrType);
                    model.ContentModel = model.Content.Base64ProtoBufDeserialize(type); 
                }
            }
            return list;
        }

        protected override Task<State<bool>> Delete() => Invoke<CustodyController, State<bool>>(c => c.Delete(SelectedModel));

        protected override void Open(bool isNew)
        {
            throw new System.NotImplementedException();
        }
        public override string Title => Translate("RequestConfirmList_Title");
        public override string SubTitle => Translate("RequestConfirmList_SubTitle");
        protected override AccessRight AccessRight => AccessRight.CustodyReport;

        protected override bool CanDelete()
        {
            return SelectedModel != null && allowDeleteStatus.Contains(SelectedModel.Status) && !Shell.IsBusy; 
        } 

        private readonly IReadOnlyList<CustodyRequestStatus> allowDeleteStatus = new List<CustodyRequestStatus>()
        {
            CustodyRequestStatus.FailureRejected,
            CustodyRequestStatus.PublishedFailed,
            CustodyRequestStatus.RequestRejected
        };
    }
}