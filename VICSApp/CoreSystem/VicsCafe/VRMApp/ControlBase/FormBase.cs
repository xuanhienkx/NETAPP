using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRMApp.Framework;
using System.Runtime.InteropServices;
using System.Threading;

namespace VRMApp.ControlBase
{
   public delegate FormBase CreateForm();

    public interface IValidatedAccess
    {
        bool CheckAccess();
    }

    public class FormBase : Form, IValidatedAccess
   {
        private const string MSG_TITTLE = "Thông báo";

      private delegate void SetStatus(string status);
      private delegate void HideProcess();

        public FormBase()
        {
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

      protected void ShowWaiting()
      {
         WaitingForm.ShowMe();
      }

      protected void ShowWaiting(string description)
      {
         WaitingForm.ShowMe(description);
      }

      protected void CloseWaiting()
      {
         WaitingForm.HideMe();
      }

      protected void SetWaitingStatus(string status)
      {
         WaitingForm.ShowMe(status);
      }

      public static T Find<T>() where T : FormBase
      {
         return Find<T>(null);
      }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            WaitingForm f = WaitingForm.GetMe();
            if (f != null)
            {
                f.ShowDialog(this);
            }
        }

        //protected override void OnActivated(EventArgs e)
      //{
      //   base.OnActivated(e);
      //   WaitingForm f = WaitingForm.GetMe();
      //    if (f != null)
      //    {
      //        f.Owner = this;
      //        f.MdiParent = this.MdiParent;
      //        f.Activate();
      //    }
      //}

      public static T Find<T>(Predicate<T> predicate) where T : FormBase
      {
         T result = null;
         foreach (Form f in Util.MainMDI.MdiChildren)
         {

            if (f is T)
            {
               if (predicate == null || predicate(f as T))
               {
                  result = f as T;
                  break;
               }
            }
         }
         return result;
      }

      public static T Show<T>(CreateForm create) where T : FormBase
      {
         return Show<T>(create, null);
      }
      public static DialogResult ShowDialog<T>(CreateForm create) where T : FormBase
      {
         var me = create() as T;
         return me.ShowDialog();
      }


      public static T Show<T>(CreateForm create, Predicate<T> predicate) where T : FormBase
      {
         T me;
         me = Find<T>(predicate);

         if (me == null)
         {
            me = create() as T;
            if (!me.CheckAccess())
            {
               MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               return null;
            }
            me.MdiParent = Util.MainMDI;
            me.Show();
         }
         else
         {
            if (!me.CheckAccess())
            {
               MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               return null;
            }

            me.Activate();
         }
         me.WindowState = FormWindowState.Normal;
         return me;
      }

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // FormBase
         // 
         this.ClientSize = new System.Drawing.Size(545, 318);
         this.Name = "FormBase";
         this.ResumeLayout(false);

      }

      protected void ShowNotice(string message)
      {
         WaitingForm.HideMe();
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }

      protected void ShowWaring(string message)
      {
         WaitingForm.HideMe();
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }

      protected void ShowError(string message)
      {
         WaitingForm.HideMe();
         message = message.Replace("System.Web.Services.Protocols.SoapException: Server was unable to process request. ---> ", "");
         message = message.Split(new string[] { "\n   at " }, StringSplitOptions.RemoveEmptyEntries)[0];
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      protected DialogResult ShowQuestion(string message)
      {
         WaitingForm.HideMe();
         return MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      }

      public virtual bool CheckAccess()
      {
          throw new NotImplementedException();
      }
   }
}
