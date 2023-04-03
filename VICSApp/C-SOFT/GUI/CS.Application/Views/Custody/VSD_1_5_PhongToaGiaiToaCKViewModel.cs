using CS.Application.Controllers;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using CS.UI.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS.Application.Views.Custody
{
    public interface IBankCustody
    {
        ICommand FilterBankCommand { get; }
        BankModel Bank { get; set; }
        BankModel SuggestionBank { get; set; }
    }
    public class VSD_1_5_PhongToaGiaiToaCKViewModel : BaseRequestCustomerStockPublishViewModel<Custody524Model>, IBankCustody
    {
        public VSD_1_5_PhongToaGiaiToaCKViewModel(CustodyRequestModel model) : base(model)
        {
            FilterBankCommand = new AutoCompleteTextBox.FilterCommand(async f => await FilterBank(f));

            AddOnPropertyChangeListener(() => SuggestionBank, () => UpdateSuggestionBank());

            if (Model.ContentModel is Custody524Model contentModel)
            {
                contentModel.EnablePropertyChange = true;
            }

            AddOnPropertyChangeValidator(() => SuggestionBank,
                () => Bank == null
                    ? Translate("CustodyView_Bank_Validation")
                    : null);
        }


        private async Task<IEnumerable> FilterBank(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;

            return await Invoke<BankController, IList<BankModel>>(c => c.FilterBank(filter));
        }

        public ICommand FilterBankCommand { get; }
        public EnumCollection<PledgeReleasingType> BlRlTypes { get; } = new EnumCollection<PledgeReleasingType>();
        public override string Title => Translate("CustodyViewModel_VSD_1_5_PhongToaGiaiToaCK_Dialog_Title");
        public override bool ContentModelValid => Model.ContentModel is Custody524Model model && model.IsValid;

        public BankModel Bank
        {
            get => Get<BankModel>();
            set => Set(value);
        }

        public BankModel SuggestionBank
        {
            get => Get<BankModel>();
            set => Set(value);
        }
        private void UpdateSuggestionBank()
        {
            if (SuggestionBank == null)
                return;

            var model = (Custody524Model)Model.ContentModel;
            Bank = SuggestionBank;
            model.BankCode = Bank.BankPlRlCode;
            model.BankName = Bank.FullName;
            ErrorMessage = null;

        }

        public override Custody524Model SetCustomerToContenModel(Custody524Model model, CustomerModel customer)
        {
            return model;
        } 
        public override async Task LoadDataExtend(Custody524Model model)
        {
            Bank = await Invoke<BankController, BankModel>(c => c.GetBank(model.BankCode));
            await base.LoadDataExtend(model);
        }
        protected override AccessRight AccessRight => AccessRight.PhongToaGiaiToaCk;
    }
}