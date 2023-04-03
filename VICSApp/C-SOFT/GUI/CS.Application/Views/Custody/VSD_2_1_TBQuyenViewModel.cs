using CS.Common.Contract.Models;
using CS.UI.Common.Interfaces;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Custody
{
    public class VSD_2_1_TBQuyenViewModel : EditViewModel<RightInformationModel>
    {
        public VSD_2_1_TBQuyenViewModel(RightInformationModel model) : base(model)
        {
        }

        protected override AccessRight AccessRight => AccessRight.RightInfomation;
        public override string Title => Translate("VSD_2_1_TBQuyenViewModel_Title");
        public override string SubTitle => Translate("VSD_2_1_TBQuyenViewModel_SubTitle");
        protected override Task<RequestResult<RightInformationModel>> Save()
        {
            throw new System.NotImplementedException();
        }

        protected override Task<State<bool>> Delete()
        {
            throw new System.NotImplementedException();
        }
        //implement later
        protected override bool CanDelete() => false; 
        // public override string DialogTitle => Translate("VSD_2_1_TBQuyenViewModel_DialogTitle");
    }
}