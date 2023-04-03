using CS.Application.Controllers;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;


namespace CS.Application.Views.Customer
{
    public class CustomerListViewModel : ListPagedViewModel<Guid, CustomerModel>
    {
        public CustomerListViewModel(string searchText) 
        {
            SearchText = searchText;
            AddFilteredFields(x => x.FullName, x => x.UserName);
        }

        public override string Title => Translate("CustomerViewModel_Title");
        public override string SubTitle => Translate("CustomerViewModel_SubTitle");

        protected override Task<ListPaged<CustomerModel>> GetListPaged(IDictionary<string, string> filterOptions) 
            => Invoke<CustomerController, ListPaged<CustomerModel>>(c => c.FilterCustomer(filterOptions));

        protected override AccessRight AccessRight { get; } = AccessRight.Customer;

        protected override Task<State<bool>> Delete() => Invoke<CustomerController, State<bool>>(c => c.Delete(SelectedModel));

        protected override void Open(bool isNew) => Invoke<CustomerController>(c => c.Open(SelectedModel, isNew));
    }
}