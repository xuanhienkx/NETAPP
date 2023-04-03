using CS.Domain.Contract.Shared.Models;

namespace CS.Application.Views.Custody
{
    public class VSD_3_1_XNKetQuaGDViewModel: VSD_1_8_XNSoDuCKViewModel
    {
        public VSD_3_1_XNKetQuaGDViewModel(CustodyRequestModel model) : base(model)
        {
        }

        public override string DialogTitle => Translate("CustodyViewModel_VSD_3_1_XNKetQuaGD_Dialog_Title");
    }
}