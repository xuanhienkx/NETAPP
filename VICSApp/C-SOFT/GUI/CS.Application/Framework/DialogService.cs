using System;
using System.IO;
using System.Threading.Tasks;
using CS.UI.Common.Interfaces;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;

namespace CS.Application.Framework
{
    public class DialogService : IDialogService
    {
        private readonly IShell shell;
        private readonly IDialogCoordinator dialogCoordinator;

        public DialogService(IDialogCoordinator dialogCoordinator, IShell shell)
        {
            this.shell = shell ?? throw new ArgumentNullException(nameof(shell));
            this.dialogCoordinator = dialogCoordinator ?? throw new ArgumentNullException(nameof(dialogCoordinator));
        }

        public Task<MessageDialogResult> ShowConfirmDialog(object viewModel, string title, string message)
        {
            var busyState = shell.IsBusy;
            shell.IsBusy = false;

            var task = dialogCoordinator.ShowMessageAsync(viewModel, title, message, MessageDialogStyle.AffirmativeAndNegative);
            task.ConfigureAwait(false);
            task.ContinueWith(t =>
            {
                if (t.Result != MessageDialogResult.Negative)
                    shell.IsBusy = busyState;
            });

            return task;
        }

        public async Task<byte[]> OpenFileDialog(string title, string filter, string defaultExtension = "")
        {
            var busyState = shell.IsBusy;
            shell.IsBusy = false;

            var fd = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                DefaultExt = defaultExtension,
            };

            if (!fd.ShowDialog().GetValueOrDefault())
            {
                shell.IsBusy = busyState;
                return null;
            }

            var stream = fd.OpenFile();
            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream);
                shell.IsBusy = busyState;
                return memStream.ToArray();
            }
        }

        //public async Task<byte[]> SaveFileDialog(string title, string filter, string defaultExtension = "")
        //{
        //    var fd = new SaveFileDialog
        //    {
        //        Title = title,
        //        Filter = filter,
        //        DefaultExt = defaultExtension
        //    };

        //    if (!fd.ShowDialog().GetValueOrDefault())
        //        return null;

        //    var stream = fd.OpenFile();
        //    using (var memStream = new MemoryStream())
        //    {
        //        await stream.CopyToAsync(memStream);
        //        return memStream.ToArray();
        //    }
        //}
    }
}
