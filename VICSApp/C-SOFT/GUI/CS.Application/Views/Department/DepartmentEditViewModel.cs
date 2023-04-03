using System.Collections.Generic;
using System.Linq;
using CS.Application.Controllers;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common.Interfaces;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Department
{
    public class DepartmentEditViewModel : EditViewModel<DepartmentModel>
    {
        public DepartmentEditViewModel(DepartmentModel model, ExecuteType viewType = ExecuteType.Edit) 
            : base(model, viewType)
        {
        }

        public override string Title => ViewType == ExecuteType.New
            ? Translate("DepartmentEditViewModel_Add_Title")
            : Translate("DepartmentEditViewModel_Edit_Title");
        public override string SubTitle => Translate("DepartmentEditViewModel_SubTitle");
        
        protected override Task<RequestResult<DepartmentModel>> Save() => Invoke<DepartmentController, RequestResult<DepartmentModel>>(c => c.Save(Model));
        protected override Task<State<bool>> Delete() => Invoke<DepartmentController, State<bool>>(c => c.Delete(Model));

        public IList<BranchModel> Branches { get; set; }

        protected override void OnUpdated(object sender, ModelEventArg<DepartmentModel> e)
        {
            if (e.IsCompleted && e.ExecuteType == ExecuteType.Edit)
                Model.Branch = Branches.FirstOrDefault(x => x.Id == Model.Branch.Id);

            base.OnUpdated(sender, e);
        }

        protected override AccessRight AccessRight { get; }
    }
}