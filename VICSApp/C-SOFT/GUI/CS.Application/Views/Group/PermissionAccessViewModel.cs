using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Group
{
    public class PermissionItemViewModel
    {
        public PermissionItemViewModel(PermissionAccess permission)
        {
            Permission = permission;
        }
        public PermissionAccess Permission { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsAllowDeny { get; set; }
        public EnumCollection<AccessType> AccessTypes { get; set; }
        public string GroupTypeName { get; set; }
    }

    public class PermissionAccessViewModel : EditDialogViewModel<PermissionModel>
    {
        public PermissionAccessViewModel(PermissionModel model, ExecuteType viewType = ExecuteType.Edit)
            : base(model, viewType)
        {
            Permissions = new ObservableCollection<PermissionItemViewModel>(PermissionFactory.BuildAllAccessRights(model.Permissions));
        }

        public override string Title => Translate($"PermissionAccessViewModel_Dialog_Title") + Model.Group.Name;
        public override string SubTitle => Translate($"PermissionAccessViewModel_Dialog_SubTitle") + Model.Group.Name;

        protected override async Task<RequestResult<PermissionModel>> Save()
        {
            var ps = Permissions.Where(x => x.Permission.Type > 0).Select(x => x.Permission).ToList();
            var result = await Invoke<GroupController, bool>(c => c.SavePermission(Model.Group.Id, ps));
            if (result)
                Model.Permissions = ps;

            return new RequestResult<PermissionModel>(Model, result);
        }

        public ObservableCollection<PermissionItemViewModel> Permissions { get; }
    }
}