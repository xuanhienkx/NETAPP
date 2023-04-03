using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.UI.Common.Interfaces;

namespace CS.UI.Common.ViewBase
{
    public abstract class EditDialogViewModel<T> : EditViewModel<T>, IDialogViewModel
        where T : DataContract, new()
    {
        protected EditDialogViewModel(T model, ExecuteType viewType = ExecuteType.Edit) 
            : base(model, viewType)
        {
        }

        public virtual string SaveButtonTitle => Translate("Command_Save");
        public string CloseButtonTitle => Translate("Command_Close");

        protected override AccessRight AccessRight { get; }

        protected override Task<State<bool>> Delete()
        {
            return null;
        }
    }
}