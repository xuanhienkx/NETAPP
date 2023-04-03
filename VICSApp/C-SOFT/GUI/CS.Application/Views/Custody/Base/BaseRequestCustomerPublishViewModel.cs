using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.UI.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract;

namespace CS.Application.Views.Custody.Base
{
    public interface IVsdCustmerViewModel
    {
        ICommand FilterCommand { get; }
        CustomerModel Customer { get; set; }
        CustomerModel SuggestionCustomer { get; set; }
    }
    public interface IVsdStockCustmerViewModel : IVsdCustmerViewModel
    {
        AssetModel Stock { get; set; }
        AssetModel SuggestionStock { get; set; }
        ICommand FilterStockCommand { get; }
    }
    public abstract class BaseRequestCustomerPublishViewModel<T>
        : RequestPublishViewModel, IVsdCustmerViewModel where T : VsdCustomer, new()
    {
        protected BaseRequestCustomerPublishViewModel(CustodyRequestModel model) : base(model)
        {
            if (string.IsNullOrEmpty(model.ContentClrType))
                Model.ContentClrType = typeof(T).FullName;

            FilterCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterCustomer(f));

            AddOnPropertyChangeListener(() => SuggestionCustomer, () => UpdateSuggestionCustomer());
            AddOnPropertyChangeValidator(() => SuggestionCustomer,
                () => Customer == null || !Customer.Status.Equals(CustomerStatus.Open)
                    ? Translate("CustodyView_Customer_Validation")
                    : null);

            if (Model.ContentModel == null)
                Model.ContentModel = new T();

            RegisterContentModelChanged((T)Model.ContentModel);
        }

        protected virtual void RegisterContentModelChanged(T contentModel)
        {

        } 

        protected async Task<IEnumerable> FilterCustomer(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;

            return await Invoke<CustomerController, IList<CustomerModel>>(c => c.FilterCustomer(filter));
        }

        public ICommand FilterCommand { get; }
        public virtual Task LoadDataExtend(T model)
        {
            return Task.CompletedTask;
        }

        public override async Task LoadData()
        {

            if (Model.ContentModel != null)
            {
                var contentModel = (T)Model.ContentModel;
                Customer = await Invoke<CustomerController, CustomerModel>(c => c.GetCustomer(contentModel.CustomerNumber));
                await LoadDataExtend(contentModel);
            }
            else
            {
                Model.ContentModel = new T();
            }
        }
        public CustomerModel Customer { get => Get<CustomerModel>(); set => Set(value); }
        public CustomerModel SuggestionCustomer { get => Get<CustomerModel>(); set => Set(value); }

        private void UpdateSuggestionCustomer()
        {
            if (SuggestionCustomer == null)
                return;

            var model = (T)Model.ContentModel;
            Customer = SuggestionCustomer;
            model.CustomerNumber = Customer.CustomerNumber;
            model.CustomerName = Customer.FullNameLocal;
            model.Id = Customer.Id;
            model.Version = Customer.Version;
            SetCustomerToContenModel(model, Customer);
        }

        public abstract T SetCustomerToContenModel(T model, CustomerModel customer);
        protected override AccessRight AccessRight { get; }
    }
}