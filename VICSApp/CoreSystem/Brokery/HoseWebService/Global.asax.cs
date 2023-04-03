using System;
using System.IO;
using System.Web.Services.Protocols;
using HoseWebService.Common;

namespace HoseWebService
{
   public class WebServiceErrorHandler : SoapExtension
   {
      public override object GetInitializer(Type serviceType)
      {
         return null;
      }

      public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
      {
         return null;
      }

      public override void Initialize(object initializer)
      {
         return;
      }

      public override Stream ChainStream(Stream stream)
      {
         return stream;
      }

      public override void ProcessMessage(SoapMessage message)
      {
         switch (message.Stage)
         {
            case SoapMessageStage.BeforeDeserialize:
               break;
            case SoapMessageStage.AfterSerialize:
               if (message.Exception != null)
               {
                  if (AccessFactory.CurrentInstance() != null)
                  {
                     AccessFactory.CurrentInstance().Abort("Rollback performed from WebServiceErrorHandler");
                     AccessFactory.CurrentInstance().Dispose();
                  }
               }
               break;
         }
      }
   }

   /// <summary>
   /// Summary description for Global.
   /// </summary>
   public class Global : System.Web.HttpApplication
   {
      public Global()
      {
         InitializeComponent();
      }

      protected void Application_BeginRequest(Object sender, EventArgs e)
      {
         // Tear down the existing access factory on the thread
         if (AccessFactory.CurrentInstance() != null)
         {
            AccessFactory.CurrentInstance().Abort("Rollback performed from Application_BeginRequest");
            AccessFactory.CurrentInstance().Dispose();
         }

         AccessFactory.CreateFactory();
      }

      protected void Application_EndRequest(Object sender, EventArgs e)
      {
         // Tear down the existing access factory on the thread
         if (AccessFactory.CurrentInstance() != null)
         {
            AccessFactory.CurrentInstance().Commit("Committed from Application_EndRequest");
            AccessFactory.CurrentInstance().Dispose();
         }
      }

      #region Web Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
      }

      #endregion
   }
}
