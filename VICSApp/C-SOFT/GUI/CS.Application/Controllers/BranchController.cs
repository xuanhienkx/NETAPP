using CS.Application.Views.Branch;
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
using ExecuteType = CS.UI.Common.Interfaces.ExecuteType;

namespace CS.Application.Controllers
{
    public class BranchController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly IDataProvider dataProvider;
        private readonly ITranslator translator;

        public BranchController(IDataProvider dataProvider, ITranslator translator, IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }

        public async Task<Result<IList<BranchModel>>> GetAll()
        {
            var result = await dataProvider.GetList<BranchModel>("branches");
            return !result.HasResult ? new Result<IList<BranchModel>>() : Result(result.Value);
        }

        public ActionResult Index()
        {
            return ChildView("BranchList", new BranchListViewModel());
        }

        public ActionResult Open(BranchModel model, IList<BranchModel> allBranches, bool isNew)
        {
            var viewModel = isNew
                ? new BranchEditViewModel(new BranchModel(), allBranches, ExecuteType.New)
                : new BranchEditViewModel(model.Clone<BranchModel>(), allBranches);
            return ChildView("BranchEdit", viewModel);
        }

        public async Task<Result<RequestResult<BranchModel>>> Save(BranchModel model)
        {
            // set null to parent in case of this parent id is empty
            if (model.Parent?.Id == 0)
                model.Parent = null;

            var result = model.Id == 0
             ? await dataProvider.Post<BranchModel, BranchModel>("branches", model)
             : await dataProvider.Put($"branches/{model.Id}", model);

            return Result(result);
        }

        public async Task<Result<State<bool>>> Delete(BranchModel model)
        {
            var message = string.Format(translator.Translate("ViewModel_Confirm_MessageDelete"), $" {model.BranchName}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"branches/{model.Id}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }
    }
}