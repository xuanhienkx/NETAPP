using CS.Application.Controllers;
using CS.Common.Contract.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Std;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Custody
{
    public class RightInformationListViewModel : ListViewModel<long, RightInformationModel>
    {
        public override string Title => Translate("RightInformationViewModel_Title");
        public override string SubTitle => Translate("RightInformationViewModel_SubTitle");
        protected override AccessRight AccessRight => AccessRight.RightInfomation;


        protected override Task<IList<RightInformationModel>> GetList() => Invoke<CustodyController, IList<RightInformationModel>>(c => c.GetList());

        protected override bool CanDelete() => false;
        protected override Task<State<bool>> Delete()
        {
            throw new System.NotImplementedException();
        }

        protected override void Open(bool isNew) => Invoke<CustodyController>(c => c.ShowRightInfoDialog(SelectedModel));
    }
}