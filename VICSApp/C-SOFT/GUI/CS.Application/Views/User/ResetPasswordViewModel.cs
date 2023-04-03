using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Application.Controllers;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.User
{
    public class ResetPasswordViewModel : EditDialogViewModel<ChangePasswordModel>
    {
        public ResetPasswordViewModel(ChangePasswordModel model, ExecuteType viewType = ExecuteType.Edit) 
            : base(model, viewType)
        {
        }

        public override string Title => Translate("ResetPasswordViewModel_Title");
        public override string SubTitle => Translate("ResetPasswordViewModel_SubTitle");
        public override string SaveButtonTitle => Translate("Command_ResetPassword");

        protected override async Task<RequestResult<ChangePasswordModel>> Save() 
            => await Invoke<UserController, RequestResult<ChangePasswordModel>>(c => c.ResetLogin(Model));
    }
}
