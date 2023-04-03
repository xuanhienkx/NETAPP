using CS.Application.Controllers;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Custody.Base
{
    public abstract class RequestPublishViewModel : EditDialogViewModel<CustodyRequestModel>, IResource<long>
    {
        protected RequestPublishViewModel(CustodyRequestModel model, ExecuteType viewType = ExecuteType.New) : base(model, viewType)
        {
            Model = model;
            Model.EnablePropertyChange = true;
            LoadContentModel();
        }

        private void LoadContentModel()
        {
            if (Model != null && Model.ContentModel == null &&
                !string.IsNullOrEmpty(Model.ContentClrType) && !string.IsNullOrEmpty(Model.Content))
            {
                var type = Model.GetType().Assembly.GetType(Model.ContentClrType);
                Model.ContentModel = Model.Content.Base64ProtoBufDeserialize(type);
            }
        }

        private readonly IReadOnlyList<CustodyRequestStatus> allowDeleteStatus = new List<CustodyRequestStatus>()
        {
            CustodyRequestStatus.FailureRejected,
            CustodyRequestStatus.PublishedFailed,
            CustodyRequestStatus.RequestRejected
        };

        public override string Title => Translate("CustodyViewModel_Title");
        public override string SubTitle => Translate("CustodyViewModel_SubTitle");
        public bool IsLoadData { get; set; }
        public EnumCollection<CustodyRequestType> RequestTypes { get; } = new EnumCollection<CustodyRequestType>();
        public EnumCollection<MessagePriority> Prioriries { get; } = new EnumCollection<MessagePriority>();
        public IList<VsdBranch> Branches { get; } = VsdBranch.Branches;

        public abstract Task LoadData();
        public bool CanPulish => Model != null && Model.IsValid && !Shell.IsBusy && !IsViewOnly && !HasError && ContentModelValid;
        public bool AllowDelete => Model != null && allowDeleteStatus.Contains(Model.Status); 
        public abstract bool ContentModelValid { get; }

        protected override bool CanSave() => Model != null && Model.IsValid && !Shell.IsBusy && !IsViewOnly && !HasError && ContentModelValid;

        protected override Task<RequestResult<CustodyRequestModel>> Save()
        {
            if (Model.ContentModel == null)
            {
                ShowMessage(Translate("RequestContentModel_IsNotValid"), NotificationType.Error);
                return new Task<RequestResult<CustodyRequestModel>>(null);
            }

            return Invoke<CustodyController, RequestResult<CustodyRequestModel>>(c => c.PublishCustomer(Model, Model.ContentModel));
        }

        public virtual string GetViewName() => Model.BusinessId;
        public long Id {
            get => Model.Id;
            set => Model.Id = value;
        } 
    }
}
