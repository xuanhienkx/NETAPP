using System;
using CS.Application.Controllers;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Application.Services.Interfaces;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;
using CS.UI.Common.ViewBase;
using ExecuteType = CS.UI.Common.Interfaces.ExecuteType;

namespace CS.Application.Views.Custody
{
    public class RequestListViewModel : ListViewModel<long, RequestPublishViewModel>, IObservableListViewModel
    {
        private readonly string businessId;
        private readonly ICustodyBusinessHandler businessHandler;

        public RequestListViewModel(string businessId, ICustodyBusinessHandler businessHandler)
        {
            this.businessId = businessId;
            this.businessHandler = businessHandler ?? throw new ArgumentNullException(nameof(businessHandler)); 

            ShowPublishDialogCommand = new RelayCommand<ExecuteType>(
                p => Invoke<CustodyController>(c => c.ShowRequestPublishDialog(this.businessId, SelectedModel == null ? null : SelectedModel.Model, p)), CanPublish);
        }

        public override string Title => Translate($"CustodyViewModel_{businessId}_Title");
        public override string SubTitle => Translate($"CustodyViewModel_{businessId}_SubTitle");

        protected override AccessRight AccessRight => businessHandler.RequiredAccessRight(businessId);

        protected override async Task<IList<RequestPublishViewModel>> GetList()
        {
            var custodyRequests = await Invoke<CustodyController, IList<CustodyRequestModel>>(c => c.GetByBusiness(this.businessId));

            if (custodyRequests == null)
                return new List<RequestPublishViewModel>();

            return custodyRequests.Select(x => businessHandler.CreateViewModel(this.businessId, x)).ToList();
        }

        protected override Task<State<bool>> Delete() => Invoke<CustodyController, State<bool>>(c => c.Delete(SelectedModel.Model));

        protected override void Open(bool isNew)
        {
            throw new System.NotImplementedException();
        }

        public ICommand ShowPublishDialogCommand { get; }
        protected override bool CanDelete()
        {
            return SelectedModel != null && SelectedModel.AllowDelete;
        }

        private bool CanPublish(ExecuteType dialogType)
        {
            return dialogType == ExecuteType.New ||
                   (dialogType == ExecuteType.View && SelectedModel != null) ||
                   (dialogType == ExecuteType.Edit && SelectedModel != null && CanDelete());
        }

        public string ViewId => businessId;
        public object ParseModel(string content) => content.Base64ProtoBufDeserialize<RequestPublishViewModel>();
        public void UpdateModel(object model) => Update(model as RequestPublishViewModel);
    }
}
