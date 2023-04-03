using System.Text;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;

namespace CS.Application.Views.Custody
{
    public class VSD_2_4_DKDatMuaViewModel:BaseRequestCustomerStockPublishViewModel<Custody565Model>
    {
        public VSD_2_4_DKDatMuaViewModel(CustodyRequestModel model) : base(model)
        {
        }

        public override string Title => Translate("CustodyViewModel_VSD_2_4_DKDatMua_Dialog_Title");
        public override bool ContentModelValid => Model.ContentModel != null && Model.ContentModel is Custody565Model model && model.IsValid; 

        public override Custody565Model SetCustomerToContenModel(Custody565Model model, CustomerModel customer)
        { 
            model.CardIdentity = Customer.CardIdentity;
            model.CardType = Customer.CardType;
            model.CardIssuedDate = Customer.CardIssuedDate;
            return model;
        }
        protected override AccessRight AccessRight => AccessRight.DkDatMua;
    }
}