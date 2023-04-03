using System.Text;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;

namespace CS.Application.Views.Custody
{
    public class VSD_1_2_2_RutCKViewModel : BaseRequestCustomerStockPublishViewModel<Custody542Model>
    {
        public VSD_1_2_2_RutCKViewModel(CustodyRequestModel model) : base(model)
        { 
        }
        public override string Title => Translate("CustodyViewModel_VSD_1_2_2_RutCK_Dialog_Title");
        public override bool ContentModelValid => Model.ContentModel is Custody542Model model && model.IsValid; 
        public override Custody542Model SetCustomerToContenModel(Custody542Model model, CustomerModel customer)
        { 
            model.CustomerName = Customer.FullNameLocal;
            model.CardIdentity = Customer.CardIdentity;
            model.CardType = Customer.CardType;
            model.CardIssuedDate = Customer.CardIssuedDate;
            Model.Content = model.Base64ProtoBufSerialize();
            return model;
        }
        protected override AccessRight AccessRight => AccessRight.Kyguirutchungkhoan;
    }
}