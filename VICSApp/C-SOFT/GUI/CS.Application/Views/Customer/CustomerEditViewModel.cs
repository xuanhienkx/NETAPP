using CS.Application.Controllers;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;
using CS.UI.Common;
using CS.UI.Common.Extensions;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CS.Application.Views.Customer
{
    public class CustomerEditViewModel : EditViewModel<CustomerModel>
    {
        public CustomerEditViewModel(CustomerModel model, IList<BranchModel> branchs, IList<UserModel> users) : base(model)
        {
            if (branchs == null) throw new ArgumentNullException(nameof(branchs));
            if (users == null) throw new ArgumentNullException(nameof(users));

            AddContactCommand = new RelayCommand<ContactType>(AddNewContact);
            OpenFileCommand = new RelayCommand<bool>(p => Invoke<CustomerController>(c => c.OpenFile(Model, p).Result));

            Languagues = UI.Common.Localization.LocalizationManager.Instance.Languages.ToList();
            Branches = new ObservableCollection<BranchModel>(branchs);
            Brokers = new ObservableCollection<UserModel>(users);
        }

        public bool IsPersonal { get => Get<bool>(); set => Set(value); }
        protected override AccessRight AccessRight => AccessRight.Customer;
        public override string Title => Translate("CustomerViewModel_Title");
        public override string SubTitle => Translate("CustomerViewModel_SubTitle");
        protected override Task<RequestResult<CustomerModel>> Save() => Invoke<CustomerController, RequestResult<CustomerModel>>(c => c.Save(Model));
        protected override Task<State<bool>> Delete() => Invoke<CustomerController, State<bool>>(c => c.Delete(Model));

        public ObservableCollection<ContactModel> ContactModels { get; set; }
        public ObservableCollection<UserModel> Brokers { get; set; }
        public ObservableCollection<BranchModel> Branches { get; set; }
        public IList<CultureInfo> Languagues { get; }
        public IList<Country> Countries { get; } = CommonExtensions.GetListCountry();
        public EnumCollection<CustomerType> CustomerTypes { get; } = new EnumCollection<CustomerType>();
        public EnumCollection<GenereType> GenereTypes { get; } = new EnumCollection<GenereType>(GenereType.Male, GenereType.Female);
        public EnumCollection<CardType> CardTypes { get => Get<EnumCollection<CardType>>(); private set => Set(value); }
        public EnumCollection<CustomerStatus> StatusCloses { get; } = new EnumCollection<CustomerStatus>(CustomerStatus.Closed, CustomerStatus.PendingClose);

        public ICommand AddContactCommand { get; }
        public ICommand OpenFileCommand { get; }

        protected override bool CanSave()
        {
            if (!base.CanSave())
                return false;

            // validate the contacts list
            if (ContactModels == null || !ContactModels.Any())
            {
                ErrorMessage = null;
                return true;
            }

            var invalidContact = ContactModels.FirstOrDefault(x => !x.IsValid);
            if (invalidContact != null)
            {
                ErrorMessage = invalidContact.Error;
                return false;
            }

            var doubleDefaults = ContactModels.GroupBy(x => x.Type).Where(x => x.Count(g => g.IsDefault) > 1).ToList();
            if (doubleDefaults.Any())
            {
                ErrorMessage = $"There are {doubleDefaults.Count} contact account were selected as default";
                return false;
            }

            ErrorMessage = null;
            return true;
        }

        private void UpdateCardTypes()
        {
            switch (Model.Type)
            {
                case CustomerType.DomesticPrivate:
                    IsPersonal = true;
                    CardTypes = new EnumCollection<CardType>(CardType.DomesticIdentity, CardType.Passport,
                        CardType.SocialSecurity);
                    break;
                case CustomerType.DomesticOrganization:
                    IsPersonal = false;
                    CardTypes = new EnumCollection<CardType>(CardType.DomesticCorpIdentity,
                        CardType.Government);
                    break;
                case CustomerType.ForeignPrivate:
                    IsPersonal = true;
                    CardTypes = new EnumCollection<CardType>(CardType.Passport, CardType.ForeignIdentity);
                    break;
                case CustomerType.ForeignOrganization:
                    IsPersonal = false;
                    CardTypes = new EnumCollection<CardType>(CardType.ForeignCorpIdentity);
                    break;
                default:
                    CardTypes = new EnumCollection<CardType>().Exclude(CardType.None);
                    break;
            }
            var currentCardType = Model.CardType;

            Model.CardType = CardType.None;
            Model.CardType = CardTypes.Has(currentCardType) ? currentCardType : CardTypes.First().Value;
        }

        private void AddNewContact(ContactType contactType)
        {
            ContactModels?.Add(
                ContactModels.Any(x => x.IsDefault && x.Type == contactType)
                    ? new ContactModel(contactType)
                    : new ContactModel(contactType) { IsDefault = true });
        }
    }
}