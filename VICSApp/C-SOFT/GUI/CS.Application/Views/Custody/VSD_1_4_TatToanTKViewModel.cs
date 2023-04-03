using System.Text;
using CS.Application.Framework;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using System.Threading.Tasks;

namespace CS.Application.Views.Custody
{
    public class VSD_1_4_TatToanTKViewModel : BaseRequestCustomerPublishViewModel<Custody598FinalSettAccountModel>
    {
        public VSD_1_4_TatToanTKViewModel(CustodyRequestModel model) : base(model)
        {

        }

        protected override void RegisterContentModelChanged(Custody598FinalSettAccountModel contentModel)
        {
            // 2f
            contentModel.EnablePropertyChange = true;
            contentModel.AddOnPropertyChangeListener(() => contentModel.ReceiverAccount, () => OnContentModelReceiverAccountChanged(contentModel));
        }



        private void OnContentModelReceiverAccountChanged(Custody598FinalSettAccountModel contentModel)
        {
            if (string.IsNullOrEmpty(contentModel?.CustomerNumber) || contentModel.ReceiverAccount?.Length < 3)
                return;

            var memberCode = contentModel.ReceiverAccount?.Substring(0, 3);
            VsdMember = VsdMemberList.Current.GetMemberCode(memberCode);
            contentModel.ReceiverBiccode = VsdMember?.BicCode;
        }


        public override string Title => Translate("CustodyViewModel_VSD_1_4_TatToanTK_Dialog_Title");
        public override bool ContentModelValid => Model.ContentModel is Custody598FinalSettAccountModel model && model.IsValid;

        public EnumCollection<SettlementType> SettlementTypes { get; } = new EnumCollection<SettlementType>(SettlementType.MoveAllStockAndCloseAcount, SettlementType.MoveAllStockAndNotCloseAcount);

        public VsdMember VsdMember { get => Get<VsdMember>(); set => Set(value); }
        public override Task LoadDataExtend(Custody598FinalSettAccountModel model)
        {
            VsdMember = VsdMemberList.Current.GetMember(model.ReceiverBiccode);
            return Task.CompletedTask;
        }

        public override Custody598FinalSettAccountModel SetCustomerToContenModel(Custody598FinalSettAccountModel model, CustomerModel customer)
        {
            model.CustomerName = Customer.FullNameLocal;
            model.CardIdentity = Customer.CardIdentity;
            model.CardType = Customer.CardType;
            model.CardIssuedDate = Customer.CardIssuedDate;
            model.CardIssuer = Customer.CardIssuer;
            model.CountryCode = Customer.CountryCode;
            model.NationalityCode = Customer.NationalityCode;
            model.Address = Customer.Address;
            model.ReceiverCompanyName = VsdMember.FullName;
            return model;
        }
        protected override AccessRight AccessRight => AccessRight.TatToanTk;
    }
}