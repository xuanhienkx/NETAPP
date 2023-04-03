using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using VRMApp.Framework;

namespace VRMApp.ControlBase
{
   public partial class WaitingForm : Form
   {
      delegate void UpdateStatus(string status);
      delegate void StartWaiingDialog();
      private static WaitingForm waitingForm;
      private static Thread thread;

      public WaitingForm()
      {
         InitializeComponent();
      }

      private static void StartWaiting()
      {
          if (Util.MainMDI.InvokeRequired)
          {
              Util.MainMDI.Invoke(new StartWaiingDialog(StartWaiting));
          }
          else
          {
              if (waitingForm != null)
              {
                  if (Util.MainMDI.ActiveMdiChild == null)
                      waitingForm.Show(Util.MainMDI);
                  else
                      waitingForm.ShowDialog(Util.MainMDI.ActiveMdiChild);
              }
          }
      }

      public static void ShowMe()
      {
         ShowMe("Đang xử lý ...");
      }

      public static void ShowMe(string description)
      {
          if (waitingForm == null)
          {
              waitingForm = new WaitingForm
              {
                  lblProcess = {Text = description},
                  IsMdiContainer = false
              };

              thread = new Thread(StartWaiting) {IsBackground = true};
              thread.SetApartmentState(ApartmentState.STA);
              thread.Start();
          }
          else
              waitingForm.UpdateLabel(description);
      }

      public static void HideMe()
      {
         if (waitingForm == null)
            return;
         waitingForm.SetHide();
      }

      private void SetHide()
      {
         if (waitingForm != null && !waitingForm.IsDisposed)
         {
             if (waitingForm.InvokeRequired)
                waitingForm.Invoke(new MethodInvoker(waitingForm.Close));
             else
                 waitingForm.Close();
         }
         thread = null;
         waitingForm = null;
      }

      private void UpdateLabel(string status)
      {
         if (lblProcess.InvokeRequired)
            lblProcess.Invoke(new UpdateStatus(UpdateLabel), status);
         else
            waitingForm.lblProcess.Text = status;
      }

      public static WaitingForm GetMe()
      {
         return waitingForm;
      }

      private void label1_DoubleClick(object sender, EventArgs e)
      {
          HideMe();
      }
   }
}
