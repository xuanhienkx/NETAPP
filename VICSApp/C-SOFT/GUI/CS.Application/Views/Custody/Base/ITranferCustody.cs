using CS.Common.Contract.VsdModels;
using System.Windows.Input;

namespace CS.Application.Views.Custody.Base
{
    public interface ITranferCustody
    {
        ICommand FilterPartnerCommand { get; }
        VsdMember VsdMember { get; set; }
    }
}