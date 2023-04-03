using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace CS.UI.Common.Interfaces
{
    public interface IDialogService
    {
        Task<MessageDialogResult> ShowConfirmDialog(object viewModel, string translate, string message);
        Task<byte[]> OpenFileDialog(string title, string filter, string defaultExtension = "");
    }
}