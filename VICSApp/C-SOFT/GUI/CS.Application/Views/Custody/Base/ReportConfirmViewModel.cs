using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;
using System;
using System.Threading.Tasks;

namespace CS.Application.Views.Custody.Base
{
    public abstract class ReportConfirmViewModel : RequestPublishViewModel
    {
        protected ReportConfirmViewModel(CustodyRequestModel model) : base(model)
        {
        }
         

        public override Task LoadData()
        {
            throw new NotImplementedException();
        }

        public override bool ContentModelValid => Model.ContentModel is Custody598Confirm m && m.IsValid;
    }
}