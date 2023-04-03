using System;
using CS.Application.Controllers;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;
using CS.UI.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.UI.Common.Interfaces;

namespace CS.Application.Views.Custody
{
    public class VSD_1_1_DongMoTKViewModel : RequestPublishViewModel, IVsdCustmerViewModel
    {
        public VSD_1_1_DongMoTKViewModel(CustodyRequestModel model)
            : base(model)
        {
            Model.ContentClrType = typeof(CustomerModel).FullName;
            FilterCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterCustomer(f));
            AddOnPropertyChangeListener(() => SuggestionCustomer, () => UpdateSuggestionCustomer());
            AddOnPropertyChangeValidator(() => SuggestionCustomer,
                () => Customer == null || !IsAllowStatuses.Contains(Customer.Status)
                    ? Translate("Custody_OpenOrClose_Invalidation")
                    : null);
        }
        private void UpdateSuggestionCustomer()
        {
            if (SuggestionCustomer == null || !IsAllowStatuses.Contains(SuggestionCustomer.Status))
            {
                ErrorMessage = Translate("Custody_OpenOrClose_Invalidation");
            }
            else
            {
                ErrorMessage = null;
                Model.ContentModel = SuggestionCustomer;
                Customer = SuggestionCustomer;
            }
        }

        public override string Title => Translate("CustodyViewModel_VSD_1_1_DongMoTK_Dialog_Title");

        private async Task<IEnumerable> FilterCustomer(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;

            ErrorMessage = null;
            return await Invoke<CustomerController, IList<CustomerModel>>(c => c.FilterCustomer(filter));
        }
        public ICommand FilterCommand { get; }

        public override Task LoadData()
        {
            if (Model.ContentModel != null)
            { 
                Customer = Model.ContentModel as CustomerModel; 
            }
            else
            {
                Model.ContentModel = new CustomerModel();
            }
            return Task.CompletedTask;
        }

        public override bool ContentModelValid => Customer != null && Customer.IsValid;

        public CustomerModel Customer { get => Get<CustomerModel>(); set => Set(value); }
        public CustomerModel SuggestionCustomer { get => Get<CustomerModel>(); set => Set(value); }

        private static readonly IReadOnlyList<CustomerStatus> IsAllowStatuses = new List<CustomerStatus>()
        {
            CustomerStatus.RequestDeleted,
            CustomerStatus.Initial
        }; 
        protected override AccessRight AccessRight => AccessRight.DongMoTk;
    }
}
