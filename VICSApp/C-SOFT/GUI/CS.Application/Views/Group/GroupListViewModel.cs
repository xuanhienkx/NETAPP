using CS.Application.Controllers;
using CS.Common.Contract.Models;
using CS.Common.Std.Extensions;
using CS.UI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Group
{
    public class GroupListViewModel : ListViewModel<Guid, GroupModel>
    {
        public GroupListViewModel()
        {
            ShowRightCommand = new RelayCommand<bool>(g => Invoke<GroupController>(c => c.ShowAccessRightDialog(SelectedModel, g)), g => SelectedModel != null);
        }

        public override string Title => Translate("GroupViewModel_Title");
        public override string SubTitle => Translate("GroupViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.Group;

        protected override Task<IList<GroupModel>> GetList() => Invoke<GroupController, IList<GroupModel>>(c => c.GetAll());
        protected override Task<State<bool>> Delete() => Invoke<GroupController, State<bool>>(c => c.Delete(SelectedModel));
        protected override void Open(bool isNew) => Invoke<GroupController>(c => c.Open(SelectedModel, ListModels, isNew));
        public ICommand ShowRightCommand { get; }
    }
}