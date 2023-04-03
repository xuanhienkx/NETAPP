using CS.Domain.Contract.Shared.Models;

namespace CS.Application.Views.Custody
{
    public class VSD_2_2_XNDSThucHienQuyenViewMode : VSD_1_8_XNSoDuCKViewModel
    {
        public VSD_2_2_XNDSThucHienQuyenViewMode(CustodyRequestModel model) : base(model)
        {
        }

        public override string DialogTitle => Translate("CustodyViewModel_VSD_2_2_XNDSThucHienQuyen_Dialog_Title");

    }
}
