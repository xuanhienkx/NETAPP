using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Controls
{
   public partial class Loading : FormBase
   {
      public Loading(string desc)
      {
         InitializeComponent();
         lblStatus.Text = desc;
         lblStatus.Left = (this.Width - lblStatus.Width) / 2;
      }

      public static void BeginLoading(string title, IWin32Window owner)
      {
         Loading form = Loading.Find<Loading>();
         if (form == null)
            form = new Loading(title);
         else
            form.Activate();
         form.Cursor = Cursors.WaitCursor;
         form.ShowDialog(owner);
      }

      public static void EndLoading()
      {
         Loading form = Loading.Find<Loading>();
         if (form == null)
            return;
         form.Cursor = Cursors.Default;
         form.Close();
         form.Dispose();
      }

      public static void UpdateCursorUI(Form form, bool isWaitCursor)
      {
         if (isWaitCursor)
            form.Cursor = Cursors.WaitCursor;
         else
            form.Cursor = Cursors.Default;
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { yield return AccessPermission.None; }
      }

      private void Loading_AutoSizeChanged(object sender, EventArgs e)
      {
         //int x = (this.pictureBox1.Size.Width + this.label1.Size.Width) + 13;
         //int height = base.Size.Height;
         //base.Size = new Size(new Point(x, height));
      }
   }
}
