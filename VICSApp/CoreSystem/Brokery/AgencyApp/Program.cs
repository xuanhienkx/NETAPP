using System;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using Brokery.Controls;
using Brokery.Framework;

namespace Brokery
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = Util.CurrentCulture;
         Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
         Application.EnableVisualStyles();

         Application.SetCompatibleTextRenderingDefault(false);

         Application.Run(Util.MainMDI);
      }

      static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
      {
         var exception = e.Exception as WebException;
         if (exception != null)
         {
            var response = (HttpWebResponse) exception.Response;
            if (response.StatusCode == HttpStatusCode.Found)
            {
               // user must login
               foreach (Form f in Util.MainMDI.MdiChildren)
                  f.Close();
               FormBase.ShowDialog<Security.Login>(() => new Security.Login());
      
               return;
            }
         }
         MessageBox.Show(
            "Có lỗi xảy ra, xin vui lòng chụp lại màn hình lỗi này và gửi đến bộ phận IT. \n Message: " +
            e.Exception.Message + "\n\n Trace log: " + e.Exception.StackTrace, "Vics Brockery");
      }
   }
}
