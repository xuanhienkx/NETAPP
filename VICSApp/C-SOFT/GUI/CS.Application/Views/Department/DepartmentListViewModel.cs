using CS.Application.Controllers;
using CS.Common.Contract.Models;
using CS.UI.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Department
{
    public class DepartmentListViewModel : ListViewModel<long, DepartmentModel>
    {
        public override string Title => Translate("DepartmentViewModel_Title");
        public override string SubTitle => Translate("DepartmentViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.Department;

        protected override Task<IList<DepartmentModel>> GetList() => Invoke<DepartmentController, IList<DepartmentModel>>(c => c.GetAll());
        protected override Task<State<bool>> Delete() => Invoke<DepartmentController, State<bool>>(c => c.Delete(SelectedModel));
        protected override void Open(bool isNew) => Invoke<DepartmentController>(c => c.Open(SelectedModel, isNew));
    }
}