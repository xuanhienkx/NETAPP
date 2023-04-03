using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CS.Application.Controllers;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Branch
{
    public class BranchEditViewModel : EditViewModel<BranchModel>
    {
        private readonly BranchModel defaultBranch;
        private readonly IList<BranchModel> allBranches;

        public BranchEditViewModel(BranchModel model, IList<BranchModel> allBranches, ExecuteType viewType = ExecuteType.Edit)
            : base(model, viewType)
        {
            defaultBranch = new BranchModel { Id = 0, BranchName = Translate("BranchViewModel_EditDialog_ChooseOneTitle") };

            this.allBranches = allBranches ?? new List<BranchModel>();

            Parents = new ObservableCollection<BranchModel> {defaultBranch};
            BuildParents();
        }
        
        protected override void OnUpdated(object sender, ModelEventArg<BranchModel> e)
        {
            if (!e.IsCompleted)
            {
                if (e.ExecuteType == ExecuteType.New)
                {
                    Parents.Clear();
                    Parents.Add(defaultBranch);
                    BuildParents();
                }
                return;
            }

            switch (e.ExecuteType)
            {
                case ExecuteType.Delete:
                    allBranches.Remove(e.Model);
                    break;
                case ExecuteType.Edit:
                    allBranches.Remove(Model);
                    allBranches.Add(e.Model);
                    e.Model.Parent = allBranches.SingleOrDefault(x => x.Id == e.Model.Parent?.Id);
                    break;
                case ExecuteType.New:
                    allBranches.Add(e.Model);
                    break;
            }

            base.OnUpdated(sender, e);
        }

        protected override AccessRight AccessRight => AccessRight.AdminSetting;

        public ObservableCollection<BranchModel> Parents { get; }

        public bool CanEditBranchCode => CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin) || ViewType == ExecuteType.Edit;
        public override string Title => ViewType == ExecuteType.New
            ? Translate("BranchEditViewModel_Add_Title")
            : Translate("BranchEditViewModel_Edit_Title");
        public override string SubTitle => Translate("BranchEditViewModel_SubTitle");

        protected override async Task<State<bool>> Delete() => await Invoke<BranchController, State<bool>>(c => c.Delete(Model));
        protected override async Task<RequestResult<BranchModel>> Save() => await Invoke<BranchController, RequestResult<BranchModel>>(c => c.Save(Model));

        private void BuildParents()
        {
            var allExcepts = ViewType == ExecuteType.New
                ? new List<BranchModel>()
                : allBranches.RecursiveLookup(Model, x => x.Parent?.Id ?? 0);

            allBranches.Except(allExcepts)
                .OrderBy(x => x.BranchName).ToList()
                .ForEach(x => Parents.Add(x));
        }
    }
}