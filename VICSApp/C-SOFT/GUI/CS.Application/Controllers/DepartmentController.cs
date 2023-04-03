using CS.Application.Views.Department;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Std;

namespace CS.Application.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly ITranslator translator;
        private readonly IDataProvider dataProvider;

        public DepartmentController(IDataProvider dataProvider, ITranslator translator, IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public async Task<Result<IList<DepartmentModel>>> GetAll()
        {
            var result = await dataProvider.GetList<DepartmentModel>("departments");
            return !result.HasResult? new Result<IList<DepartmentModel>>(): Result(result.Value);
        }

        public ActionResult Index()
        {
            return View("DepartmentList", new DepartmentListViewModel());
        }

        public async Task<ActionResult> Open(DepartmentModel model, bool isNew)
        {
            var viewModel = isNew
                ? new DepartmentEditViewModel(new DepartmentModel { Branch = Shell.User.Branch }, UI.Common.Interfaces.ExecuteType.New)
                : new DepartmentEditViewModel(model.Clone<DepartmentModel>());

            var result = await dataProvider.GetList<BranchModel>("branches", true);
            viewModel.Branches = result.HasResult ? result.Value : new List<BranchModel>();

            return ChildView("DepartmentEdit", viewModel);
        }

        public async Task<Result<RequestResult<DepartmentModel>>> Save(DepartmentModel model)
        {
            var result = model.Id == 0
                ? await dataProvider.Post<DepartmentModel, DepartmentModel>("departments", model)
                : await dataProvider.Put($"departments/{model.Id}", model);

            return Result(result);
        }

        public async Task<Result<State<bool>>> Delete(DepartmentModel model)
        {
            var message = string.Format(translator.Translate("ViewModel_Confirm_MessageDelete"), $" {model.Name}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"Departments/{model.Id}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }
    }
}