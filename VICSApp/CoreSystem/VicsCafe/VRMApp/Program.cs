using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using VRMApp.ControlBase;
using VRMApp.Framework;

namespace VRMApp
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = VRMApp.Framework.Util.CurrentCulture;
         Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
         Application.EnableVisualStyles();

         Application.SetCompatibleTextRenderingDefault(false);

         try
         {
            Application.Run(VRMApp.Framework.Util.MainMDI);
         }
         catch (Exception ex)
         {
            string message = ex.Message.Replace("System.Web.Services.Protocols.SoapException: Server was unable to process request. ---> ", "");
            message = message.Split(new string[] { "\n   at " }, StringSplitOptions.RemoveEmptyEntries)[0];

            MessageBox.Show("Lỗi: " + message, "Thông báo lỗi");
         }
      }

      static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
      {
         var exception = e.Exception as WebException;
         if (exception != null)
         {
            var response = (HttpWebResponse)exception.Response;
            if (response.StatusCode == HttpStatusCode.Found)
            {
               // user must login
               foreach (Form f in Util.MainMDI.MdiChildren)
                  f.Close();
               FormBase.ShowDialog<Security.Login>(() => new Security.Login());

               return;
            }
            MessageBox.Show(
          "Có lỗi xảy ra, xin vui lòng chụp lại màn hình lỗi này và gửi đến bộ phận IT. \n Message: " +
          e.Exception.Message + "\n\n Trace log: " + e.Exception.StackTrace, "Vics Cafe");
         }
      }


   }
}
