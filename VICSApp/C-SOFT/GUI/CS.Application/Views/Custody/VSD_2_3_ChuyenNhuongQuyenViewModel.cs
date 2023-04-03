using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;

namespace CS.Application.Views.Custody
{
    public class VSD_2_3_ChuyenNhuongQuyenViewModel : BaseRequestCustomerTranferStockPublishViewModel<Custody542RightTranferModel>
    {
        public VSD_2_3_ChuyenNhuongQuyenViewModel(CustodyRequestModel model) : base(model)
        { 
        } 
      
        public override string Title => Translate("CustodyViewModel_VSD_2_3_ChuyenNhuongQuyen_Dialog_Title");
        protected override AccessRight AccessRight => AccessRight.ChuyenNhuongQuyen;
    }
}