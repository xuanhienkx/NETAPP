using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Application.Views.Group;
using CS.Common.Contract;
using CS.Common.Std;
using CS.UI.Common.Extensions;
using CS.UI.Common.Service.Interface;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.User
{
    public class UserEditViewModel : EditViewModel<UserModel>
    {
        private readonly IDataProvider dataProvider;
        private readonly IList<DepartmentModel> allDepartmentModels;
        private readonly IList<BranchModel> allBranchModels;
        public UserEditViewModel(IDataProvider dataProvider, UserModel model, ExecuteType viewType = ExecuteType.Edit)
            : base(model, viewType)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            allDepartmentModels = Invoke<DepartmentController, IList<DepartmentModel>>(c => c.GetAll()).Result ?? new List<DepartmentModel>();
            allBranchModels = Invoke<BranchController, IList<BranchModel>>(c => c.GetAll()).Result ?? new List<BranchModel>();
            Branches = new ObservableCollection<BranchModel>();
            Departments = new ObservableCollection<DepartmentModel>();
            ResetPasswordCommand = new RelayCommand(() => Invoke<UserController>(c => c.ShowResetDialog(Model)));
        }

        public ICommand ResetPasswordCommand { get; }

        protected override AccessRight AccessRight => AccessRight.User;
        public override string Title => Translate($"BrokerViewModel_Title_{ViewType}");
        public override string SubTitle => Translate($"BrokerViewModel_SubTitle_{ViewType}");

        public EnumCollection<UserType> UserTypes { get; } = new EnumCollection<UserType>(UserType.Manager, UserType.Broker, UserType.Operator);
        public ObservableCollection<BranchModel> Branches { get; }
        public ObservableCollection<DepartmentModel> Departments { get; }

        protected override Task<RequestResult<UserModel>> Save() => Invoke<UserController, RequestResult<UserModel>>(c => c.Save(Model));
        protected override Task<State<bool>> Delete() => Invoke<UserController, State<bool>>(c => c.Active(Model));

        public EnumCollection<AccessRight> AccessNames { get; } = new EnumCollection<AccessRight>().Exclude(AccessRight.NoLimitResourceBoundaries);
        public EnumCollection<AccessType> AccessTypes { get; } = new EnumCollection<AccessType>();

        public PermissionAccessViewModel UserRights { get; set; }
        public override void OnBinding()
        {
            if (ViewType != ExecuteType.New)
            {
                UserRights = new PermissionAccessViewModel(new PermissionModel()
                {
                    Group = Model.Groups?.FirstOrDefault(),
                    Permissions = Model.Rights
                }, ExecuteType.View);
            }
            else
            {
                UserRights = new PermissionAccessViewModel(new PermissionModel(), ExecuteType.View);
            }
            BuildBranches();
            BuildDepartments();
            Model.AddOnPropertyChangeListener(() => Model.Branch, () => BuildDepartments());
            base.OnBinding();
        }

        private void BuildDepartments()
        {
            Departments.Clear();

            if (Model.Branch == null)
                return;

            allDepartmentModels.Where(x => x.Branch.Id == Model.Branch.Id).OrderBy(x => x.Name).ToList().
                ForEach(x => Departments.Add(x));
        }

        private void BuildBranches()
        {
            Branches.Clear();

            var branches = CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin)
                ? allBranchModels
                : allBranchModels.RecursiveLookup(Shell.User.Branch, x => x.Parent?.Id ?? 0);

            branches.OrderBy(x => x.BranchName).ToList()
                .ForEach(x => Branches.Add(x));
        }
    }
}