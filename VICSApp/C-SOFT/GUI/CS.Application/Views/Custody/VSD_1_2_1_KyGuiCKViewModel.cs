using System.Text;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;

namespace CS.Application.Views.Custody
{
    public class VSD_1_2_1_KyGuiCKViewModel : BaseRequestCustomerStockPublishViewModel<CustodySecurityModel>
    {
        public VSD_1_2_1_KyGuiCKViewModel(CustodyRequestModel model)
        : base(model)
        {
        }
        public override string Title => Translate("CustodyViewModel_VSD_1_2_1_KyGuiCK_Dialog_Title");

        public override bool ContentModelValid => Customer != null && Stock != null &&
                                                  (Model.ContentModel is CustodySecurityModel model && model.IsValid);

        public override CustodySecurityModel SetCustomerToContenModel(CustodySecurityModel model, CustomerModel customer)
        {
            model.BirthDay = Customer.BirthDay;
            model.CustomerName = Customer.FullNameLocal;
            model.CardIdentity = Customer.CardIdentity;
            model.CardType = Customer.CardType;
            model.CardIssuedDate = Customer.CardIssuedDate;
            model.CardIssuer = Customer.CardIssuer;
            model.CountryCode = Customer.CountryCode;
            model.NationalityCode = Customer.NationalityCode;
            return model;
        }

        protected override AccessRight AccessRight => AccessRight.Kyguirutchungkhoan;
    }
}