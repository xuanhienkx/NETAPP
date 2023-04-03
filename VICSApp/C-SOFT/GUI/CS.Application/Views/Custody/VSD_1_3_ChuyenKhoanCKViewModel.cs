using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;

namespace CS.Application.Views.Custody
{
    public class VSD_1_3_ChuyenKhoanCKViewModel : BaseRequestCustomerTranferStockPublishViewModel<Custody542TranferModel>
    {
        public VSD_1_3_ChuyenKhoanCKViewModel(CustodyRequestModel model) : base(model)
        { 
        }
        public override string Title => Translate("CustodyViewModel_VSD_1_3_ChuyenKhoanCK_Dialog_Title");

        protected override AccessRight AccessRight => AccessRight.ChuyenKhoanCk;
    }
}