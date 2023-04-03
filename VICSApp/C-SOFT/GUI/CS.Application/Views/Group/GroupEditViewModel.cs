using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Application.Controllers;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;
using CS.UI.Controls;

namespace CS.Application.Views.Group
{
    public class GroupEditViewModel : EditViewModel<GroupModel>
    {
        private readonly IList<GroupModel> allGroupModels;
        private readonly IList<BranchModel> allBranchModels;
        private readonly IList<GroupMemberModel> allMemberModels;

        public GroupEditViewModel(GroupModel model, IList<GroupModel> allGroupModels, ExecuteType viewType = ExecuteType.Edit)
            : base(model, viewType)
        {
            this.allGroupModels = allGroupModels ?? new List<GroupModel>();
            allBranchModels = Invoke<BranchController, IList<BranchModel>>(c => c.GetAll()).Result ?? new List<BranchModel>();
            allMemberModels = Invoke<GroupController, IList<GroupMemberModel>>(c => c.GetMembers(Model.Id)).Result ?? new List<GroupMemberModel>();

            Parents = new ObservableCollection<GroupModel>();
            Branches = new ObservableCollection<BranchModel>();
            UserMembers = new ObservableCollection<GroupMemberModel>();
            GroupMembers = new ObservableCollection<GroupMemberModel>();

            ShowRightCommand = new RelayCommand<bool>(g => Invoke<GroupController>(c => c.ShowAccessRightDialog(Model, g)), g => Model != null);
            ShowAddUserCommand = new RelayCommand<bool>(ShowAddUserMember);
            FilterCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterUser(f));
            RemoveUserMemberCommand = new RelayCommand<GroupMemberModel>(RemoveUserMember);
            AddOnPropertyChangeListener(() => SuggestionUser, () => UpdateSuggestionUser());


        }

        private void ShowAddUserMember(bool isShow)
        {
            IsShowAddUser = isShow;
        }

        private void RemoveUserMember(GroupMemberModel selected)
        {
            UserMembers.Remove(selected);
        }

        private void UpdateSuggestionUser()
        {
            if (SuggestionUser == null)
                return;
            if (UserMembers.Any(x => x.MemberType == MemberType.User && x.Id == SuggestionUser.Id))
                return;

            UserMembers.Add(new GroupMemberModel()
            {
                Id = SuggestionUser.Id,
                MemberType = MemberType.User,
                FullName = SuggestionUser.FullName,
                AccountLogin = SuggestionUser.AccountLogin,
                Email = SuggestionUser.Email
            });

        }

        private async Task<IEnumerable> FilterUser(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
                return null;

            return await Invoke<UserController, IList<UserModel>>(c => c.GetAll(fullname));
        }

        public override string Title => ViewType == ExecuteType.New
             ? Translate("GroupEditViewModel_Add_Title")
             : Translate("GroupEditViewModel_Edit_Title");
        public override string SubTitle => Translate("GroupEditViewModel_SubTitle");

        protected override Task<RequestResult<GroupModel>> Save()
        {
            if (ViewType == ExecuteType.Edit)
                Model.Members = UserMembers.ToList();
            return Invoke<GroupController, RequestResult<GroupModel>>(c => c.Save(Model));
        }
        protected override Task<State<bool>> Delete() => Invoke<GroupController, State<bool>>(c => c.Delete(Model));

        public ICommand ShowRightCommand { get; }
        public ICommand ShowAddUserCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand RemoveUserMemberCommand { get; }
        public ObservableCollection<GroupModel> Parents { get; }
        public ObservableCollection<BranchModel> Branches { get; }
        public ObservableCollection<GroupMemberModel> GroupMembers { get; }
        public ObservableCollection<GroupMemberModel> UserMembers { get; }
        public UserModel SuggestionUser { get => Get<UserModel>(); set => Set(value); }
        public GroupMemberModel SelectedMember { get; set; }
        public bool IsShowAddUser { get => Get<bool>(); set => Set(value); }
        public override void OnBinding()
        {
            BuildMembers();
            BuildBranches();

            if (ViewType == ExecuteType.New)
                Model.Branch = Shell.User.Branch ?? Branches.FirstOrDefault();

            BuildParents();

            // execute model change to setup the model data
            Model.AddOnPropertyChangeListener(() => Model.Branch, () => BuildParents());
        }

        private void BuildMembers()
        {
            foreach (var member in allMemberModels)
            {
                if (member.MemberType == MemberType.Group)
                    GroupMembers.Add(member);
                else
                    UserMembers.Add(member);
            }
        }

        protected override void OnUpdated(object sender, ModelEventArg<GroupModel> e)
        {
            if (!e.IsCompleted)
            {
                if (e.ExecuteType == ExecuteType.New)
                    BuildParents();

                return;
            }

            switch (e.ExecuteType)
            {
                case ExecuteType.Delete:
                    allGroupModels.Remove(e.Model);
                    break;
                case ExecuteType.Edit:
                    allGroupModels.Remove(Model);
                    allGroupModels.Add(e.Model);
                    e.Model.Parent = allGroupModels.SingleOrDefault(x => x.Id == e.Model.Parent?.Id);
                    break;
                case ExecuteType.New:
                    allGroupModels.Add(e.Model);
                    break;
            }

            base.OnUpdated(sender, e);
        }

        protected override AccessRight AccessRight { get; } = AccessRight.Group;

        private void BuildBranches()
        {
            Branches.Clear();

            var branches = CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin)
                ? allBranchModels
                : allBranchModels.RecursiveLookup(Shell.User.Branch, x => x.Parent?.Id ?? 0);

            branches.OrderBy(x => x.BranchName).ToList()
                .ForEach(x => Branches.Add(x));
        }

        private void BuildParents()
        {
            Parents.Clear();

            var defaultGroup = new GroupModel { Id = Guid.Empty, Name = Translate("GroupViewModel_EditDialog_ChooseOneTitle") };
            Parents.Add(defaultGroup);

            if (Model.Branch == null || Model.Parent?.Id == Guid.Empty)
                return;

            var groupMembers = allMemberModels.Where(x => x.MemberType == MemberType.Group).Select(m => m.Id).ToList();
            groupMembers.Add(Model.Id);
            allGroupModels.Where(x => x.Branch.Id == Model.Branch.Id
                                    && !groupMembers.Contains(x.Id))
                .OrderBy(x => x.Name).ToList()
                .ForEach(x => Parents.Add(x));

            if (Model.Parent == null || Parents.All(x => x.Id != Model.Parent.Id))
                Model.Parent = defaultGroup;
        }
    }
}