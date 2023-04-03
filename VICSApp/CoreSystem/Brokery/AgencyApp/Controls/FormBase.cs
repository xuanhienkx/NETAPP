using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Brokery.Framework;
using CommonDomain;

namespace Brokery.Controls
{
   public delegate FormBase CreateForm();

   public class FormBase : VicsFormBase
   {
      private delegate void SetStatus(string status);
      private delegate void HideProcess();

      protected ErrorTracker Error;

      public FormBase()
      {
         //InitializeComponent();
      }

      protected void SetErrorTracker(ErrorProvider errorProvider, Action onError )
      {
         Error = new ErrorTracker(errorProvider, onError);
      }

      public override IEnumerable<AccessPermission> AccessKey
      {
         get { throw new NotImplementedException("Lỗi lập trình không khai báo."); }
      }

      protected void ShowWaiting(string description)
      {
         return;
         //this.Invoke(new Action(() =>
         //                          {
         //                             if (!panelProcess.Visible)
         //                             {
         //                                int x = (this.Height - panelProcess.Height) / 2;
         //                                int y = (this.Width - panelProcess.Width) / 2;
         //                                panelProcess.Location = new System.Drawing.Point(x, y);
         //                                panelProcess.Visible = true;
         //                                panelProcess.BringToFront();
         //                                panelProcess.Click += (sender, args) => this.CloseWaiting();
         //                                processingBox.Click += (sender, args) => this.CloseWaiting();
         //                                this.Cursor = Cursors.WaitCursor;
         //                             }

         //                             lblMessage.Text = description;
         //                          }));
      }

      protected void CloseWaiting()
      {
         return;
         //if (processingBox.InvokeRequired)
         //{
         //   Invoke(new HideProcess(CloseWaiting), new object[] { });
         //   return;
         //}

         //if (processingBox.Visible)
         //{
         //   processingBox.Visible = false;
         //   this.Cursor = Cursors.Default;
         //}
      }

      public static T Find<T>() where T : FormBase
      {
         return Find<T>(null);
      }

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
         if (!Util.CheckAccess(me.AccessKey))
         {
            MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return DialogResult.Cancel;
         }
         return me.ShowDialog();
      }

      public static T Show<T>(CreateForm create, Predicate<T> predicate) where T : FormBase
      {
         T me;
         me = Find<T>(predicate);

         if (me == null)
         {
            me = create() as T;
            if (!Util.CheckAccess(me.AccessKey))
            {
               MessageBox.Show("Bạn không có quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               return null;
            }
            me.MdiParent = Util.MainMDI;
            me.Show();
         }
         else
         {
            if (!Util.CheckAccess(me.AccessKey))
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
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Name = "FormBase";
         this.ResumeLayout(false);

      }
   }

   public abstract class VicsFormBase : Form
   {
      private const string MSG_TITTLE = "Thông báo";
      public VicsFormBase()
      {
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = FormStartPosition.CenterScreen;
      }

      public abstract IEnumerable<AccessPermission> AccessKey { get; }

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // FormBase
         // 
         this.ClientSize = new System.Drawing.Size(292, 266);
         this.Name = "FormBase";
         this.ShowIcon = false;
         this.ResumeLayout(false);

      }

      protected void ShowNotice(string message)
      {
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }

      protected void ShowWaring(string message)
      {
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }

      protected void ShowError(string message)
      {
         message = message.Replace("System.Web.Services.Protocols.SoapException: Server was unable to process request. ---> ", "");
         var messages = message.Split(new string[] { "Exception:", "\n   at " }, StringSplitOptions.RemoveEmptyEntries);
         message = messages.Length > 1 ? messages[1] : message;
         MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      protected DialogResult ShowQuestion(string message)
      {
         return MessageBox.Show(this, message, MSG_TITTLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      }
   }
}
