using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Std;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.User
{
    public class UserListViewModel : ListViewModel<Guid, UserModel>
    {
        public UserListViewModel()
        {
            ResetPasswordCommand = new RelayCommand(() => Invoke<UserController>(c => c.ShowResetDialog(SelectedModel)), CanDelete);
        }

        public ICommand ResetPasswordCommand { get; }
        public override string Title => Translate("BrokerViewModel_Title");
        public override string SubTitle => Translate("BrokerViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.User;

        protected override Task<IList<UserModel>> GetList() => Invoke<UserController, IList<UserModel>>(c => c.GetAll());

        protected override async Task<State<bool>> Delete() => await Invoke<UserController, State<bool>>(c => c.Delete(SelectedModel));

        protected override void Open(bool isNew) => Invoke<UserController>(c => c.Open(SelectedModel != null ? SelectedModel.Id : Guid.Empty, isNew));
    }
}