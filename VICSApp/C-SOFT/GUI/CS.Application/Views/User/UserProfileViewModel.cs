using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Service.Interface;
using CS.UI.Common.ViewBase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;

namespace CS.Application.Views.User
{
    internal class UserProfileViewModel : ViewModelBase
    {
        private readonly IDataProvider dataProvider;
        public IUserLogin LoginUser { get; }
        public IList<BranchModel> Branches { get; }
        public IList<CultureInfo> Languagues { get; }


        public UserProfileViewModel(IDataProvider dataProvider, IUserLogin loginUser, IList<BranchModel> branches)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
            LoginUser = loginUser ?? throw new ArgumentNullException(nameof(loginUser));
            Branches = branches ?? new List<BranchModel>();
            Languagues = UI.Common.Localization.LocalizationManager.Instance.Languages.ToList();

            UserInformationSaveCommand = new RelayCommand(
                async () => await dataProvider.Put($"users/{LoginUser.Id}", LoginUser));
        }

        public override string Title => Translate("UserProfileView_Title");
        public override string SubTitle => Translate("UserProfileView_SubTitle");

        public ICommand UserInformationSaveCommand { get; }
    }
}