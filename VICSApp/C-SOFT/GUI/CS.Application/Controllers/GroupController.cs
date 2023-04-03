using CS.Application.Views.Group;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Models;
using CS.Common.Std;

namespace CS.Application.Controllers
{
    public class GroupController : Controller
    {
        private readonly IDialogService dialogService;
        private readonly IDataProvider dataProvider;
        private readonly ITranslator translator;

        public GroupController(IDataProvider dataProvider, ITranslator translator, IDialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            this.translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }

        public async Task<Result<IList<GroupModel>>> GetAll()
        {
            var result = await dataProvider.GetList<GroupModel>("groups");
            return !result.HasResult ? new Result<IList<GroupModel>>() : Result(result.Value);
        }

        public ActionResult Index()
        {
            return View("GroupList", new GroupListViewModel());
        }

        public ActionResult Open(GroupModel model, IList<GroupModel> allGroupModels, bool isNew)
        {
            var viewModel = isNew
                ? new GroupEditViewModel(new GroupModel { Branch = Shell.User.Branch }, allGroupModels, UI.Common.Interfaces.ExecuteType.New)
                : new GroupEditViewModel(model.Clone<GroupModel>(), allGroupModels);

            return ChildView("GroupEdit", viewModel);
        }

        public async Task<Result<RequestResult<GroupModel>>> Save(GroupModel model)
        {
            var isNew = model.Id == Guid.Empty;

            // set null to parent in case of this parent id is empty
            if (model.Parent?.Id == Guid.Empty)
                model.Parent = null;

            var result = isNew
             ? await dataProvider.Post<GroupModel, GroupModel>("groups", model)
             : await dataProvider.Put($"groups/{model.Id}", model);

            return Result(result);
        }

        public async Task<Result<State<bool>>> Delete(GroupModel model)
        {
            var message = string.Format(translator.Translate("ViewModel_Confirm_MessageDelete"), $" {model.Name}");
            var dialogResult = await dialogService.ShowConfirmDialog(Shell, translator.Translate("Confirm_Title"), message);
            if (dialogResult == MessageDialogResult.Negative)
                return Result(new State<bool>(false));

            var result = await dataProvider.Delete($"groups/{model.Id}");
            return Result(new State<bool>(result.IsSuccess && result.Value, StateType.Executed));
        }

        public async Task<Result<bool>> SavePermission(Guid groupId, IList<PermissionAccess> permissionAccesses)
        {
            var result = await dataProvider.Put<IList<PermissionAccess>, bool>($"groups/{groupId}/rights", permissionAccesses);

            return Result(result.HasResult && result.Value);
        }

        public async Task<ActionResult> ShowAccessRightDialog(GroupModel model, bool isNew)
        {
            var permissions = await dataProvider.GetList<PermissionAccess>($"groups/{model.Id}/rights");
            var item = new PermissionModel()
            {
                Group = model,
                Permissions = permissions.Value
            };
            var view = new PermissionAccessViewModel(item);
            return Dialog("PermissionAccess", view);
        }

        public async Task<Result<IList<GroupMemberModel>>> GetMembers(Guid id)
        {
            var result = await dataProvider.GetList<GroupMemberModel>($"groups/{id}/members");
            return Result(result.HasResult ? result.Value : new List<GroupMemberModel>());
        }
    }
}