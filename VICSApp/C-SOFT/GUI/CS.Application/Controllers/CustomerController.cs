using CS.Application.Views.Customer;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Std;

namespace CS.Application.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly IDataProvider dataProvider;
        private readonly ITranslator translator;

        public CustomerController(IDataProvider dataProvider, ITranslator translator, IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }

        public async Task<Result<IList<CustomerModel>>> FilterCustomer(string searchText)
        {
            var data = await dataProvider.GetList<CustomerModel>($"customers?filter={searchText}");
            return data.IsSuccess ? Result(data.Value) : Result<IList<CustomerModel>>();
        }

        public async Task<Result<ListPaged<CustomerModel>>> FilterCustomer(IDictionary<string, string> filterOptions)
        {
            var data = await dataProvider.GetListPage<CustomerModel>("customers/filter", filterOptions);
            return data.IsSuccess ? Result(data.Value) : Result<ListPaged<CustomerModel>>();
        }

        public ActionResult Index()
        {
            return Index(null);
        }

        public ActionResult Index(string filter)
        {
            return View("CustomerList", new CustomerListViewModel(filter));
        }

        public async Task<ActionResult> OpenFile(CustomerModel model, bool isSignature1)
        {
            var filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
            var img = await dialogService.OpenFileDialog(translator.Translate("Selecte customer signature"), filter);
            if (img == null)
                return End();

            if (isSignature1)
                model.SignatureImage1 = img;
            else
                model.SignatureImage2 = img;

            return End();
        }

        public async Task<ActionResult> Create()
        {
            var model = new CustomerModel
            {
                IsActive = false,
                Status = CustomerStatus.Initial,
                CreatedDate = DateTime.Now,
                CardIssuedDate = DateTime.Now.AddDays(-1),
                BirthDay = DateTime.Now.AddYears(-18),
                Contacts = new List<ContactModel>(),
                Type = CustomerType.DomesticPrivate
            };

            var branches = await dataProvider.GetList<BranchModel>("branches", true);
            var users = await dataProvider.GetList<UserModel>("users", true);

            return View("CustomerEdit", new CustomerEditViewModel(model, branches.Value?? new List<BranchModel>(), users.Value?? new List<UserModel>()));
        }

        public async Task<ActionResult> Open(CustomerModel model, bool isNew)
        {
            if (isNew)
            {
                model = new CustomerModel
                {
                    IsActive = false,
                    Status = CustomerStatus.Initial,
                    CreatedDate = DateTime.Now,
                    CardIssuedDate = DateTime.Now.AddDays(-1),
                    BirthDay = DateTime.Now.AddYears(-18),
                    Contacts = new List<ContactModel>(),
                    Type = CustomerType.DomesticPrivate
                };
            }
            else
            {
                model = model.Clone<CustomerModel>();

                if (model.SignatureImage1.Length == 0 && model.SignatureImage2.Length == 0)
                {
                    var result = await dataProvider.GetList<byte[]>($"customers/{model.Id}/signature");
                    if (result.HasResult)
                    {
                        var signatures = result.Value;
                        model.SignatureImage1 = signatures[0];
                        model.SignatureImage2 = signatures[1];
                    }
                }
            }
            var branches = await dataProvider.GetList<BranchModel>("branches", true);
            var users = await dataProvider.GetList<UserModel>("users", true);

            return ChildView("CustomerEdit", new CustomerEditViewModel(model, branches.Value ?? new List<BranchModel>(), users.Value ?? new List<UserModel>()));
        }

        public async Task<Result<RequestResult<CustomerModel>>> Save(CustomerModel model)
        {
            var isNew = model.Id == Guid.Empty;
            if (isNew)
            {
                model.LanguageCode = LocalizationManager.Instance.CurrentLanguage.Name;
            }

            //model.Contacts = viewModel.ContactModels;
            var result = isNew
                ? await dataProvider.Post<CustomerModel, CustomerModel>($"customers", model)
                : await dataProvider.Put($"customers/{model.Id}", model);

            return Result(result);
        }

        public async Task<Result<State<bool>>> Delete(CustomerModel model)
        {
            var active = !model.IsActive;
            if (!active)
            {
                var message = string.Format(translator.Translate("CustomerViewModel_Confirm_MessageDelete"), $" {model.CustomerNumber}");
                var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
                if (dialogResult == MessageDialogResult.Negative)
                    return new Result<State<bool>>(new State<bool>(false));
            }
            var result = await dataProvider.Delete($"customers/{model.Id}/{active}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }

        public async Task<Result<CustomerModel>> GetCustomer(string customerNumber)
        {
            if (string.IsNullOrEmpty(customerNumber))
                return Result<CustomerModel>();

            var data = await dataProvider.Get<CustomerModel>($"customers/{customerNumber}");
            return data.HasResult ? Result(data.Value) : Result<CustomerModel>();
        }
    }
}