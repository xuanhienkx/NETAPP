using CS.Application.Controllers;
using CS.Common.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Branch
{
    public class BranchListViewModel : ListViewModel<long, BranchModel>
    {
        public override string Title => Translate("BranchViewModel_Title");
        public override string SubTitle => Translate("BranchViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.Branch;

        protected override Task<IList<BranchModel>> GetList() => Invoke<BranchController, IList<BranchModel>>(c => c.GetAll());
        protected override Task<State<bool>> Delete() => Invoke<BranchController, State<bool>>(c => c.Delete(SelectedModel));
        protected override void Open(bool isNew) => Invoke<BranchController>(c => c.Open(SelectedModel, ListModels, isNew));
        
    }
}