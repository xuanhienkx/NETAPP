using CS.Application.Views.User;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Std;

namespace CS.Application.Controllers
{
    public class UserController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly ITranslator translator;
        private readonly IDataProvider dataProvider;

        public UserController(IDataProvider dataProvider, ITranslator translator, IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public async Task<Result<State<bool>>> Active(UserModel selectedModel)
        {
            var message = string.Format(translator.Translate("ViewModel_Confirm_MessageDelete"), $" {selectedModel.FullName}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"users/{selectedModel.Id}/{false}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }

        public async Task<Result<IList<UserModel>>> GetAll(string fullName = null)
        {
            var result = await dataProvider.GetList<UserModel>($"users?filter={fullName}");
            return !result.IsSuccess ? null : Result(result.Value);
        }

        public ActionResult Index()
        {
            return View("UserList", new UserListViewModel());
        }

        public async Task<ActionResult> Open(Guid id, bool isNew)
        {
            var viewModel = isNew
              ? new UserEditViewModel(dataProvider, new UserModel
              {
                  IsActive = true,
                  UserType = UserType.Broker,
                  Branch = Shell.User.Branch
              }, ExecuteType.New)
                : new UserEditViewModel(dataProvider, (await dataProvider.Get<UserModel>(id, $"users")).Value);
            return ChildView("UserEdit", viewModel);
        }

        public async Task<Result<RequestResult<UserModel>>> Save(UserModel model)
        {
            var isNew = model.Id == Guid.Empty;
            model.LanguageCode = LocalizationManager.Instance.CurrentLanguage.Name;

            var result = isNew
                ? await dataProvider.Post<UserModel, UserModel>("users", model)
                : await dataProvider.Put($"users/{model.Id}", model);

            return Result(result);
        }

        public async Task<Result<State<bool>>> Delete(UserModel model)
        {
            var message = string.Format(translator.Translate("BrokerViewModel_Confirm_MessageDelete"), $" {model.FullName}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"users/{model.Id}");
            return Result(new State<bool>(result.IsSuccess, StateType.Executed));
        }


        public async Task<ActionResult> UserProfile()
        {
            var branches = CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin)
                ? await dataProvider.GetList<BranchModel>("branches")
                : null;

            return ChildView("UserProfile", new UserProfileViewModel(dataProvider, Shell.User, branches?.Value));
        }

        public async Task<Result<RequestResult<ChangePasswordModel>>> ResetLogin(ChangePasswordModel login)
        {
            var result = await dataProvider.Put($"security/reset", login);
            return Result(result);
        }

        public async Task<Result<bool>> ActiveLogin(UserModel user)
        {
            var result = await dataProvider.Get<bool>($"users/{user.Id}/{user.IsActive}");
            return Result(result.IsSuccess);
        }

        public ActionResult ShowResetDialog(UserModel model)
        {
            if (model == null)
                return End();

            var viewModel = new ResetPasswordViewModel(new ChangePasswordModel
            {
                Id = model.Id
            });
            return Dialog("ResetPassword", viewModel);
        }
    }
}