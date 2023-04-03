using HOGW_PT_Dealer.HosePTConnector;

namespace HOGW_PT_Dealer
{
   public static class Util
   {
      static private LoginResult loginResult;
      static public LoginResult LoginResult
      {
         set { loginResult = value; }
         get { return loginResult; }
      }

      private static HoseConnector.GWConnectorWS hoseGW;
      public static HoseConnector.GWConnectorWS HoseGW
      {
         get
         {
            if (hoseGW == null)
            {
               hoseGW = new HoseConnector.GWConnectorWS();
               hoseGW.Url = HOGW_PT_Dealer.Properties.Settings.Default.HoseConnector_GWConnectorWS;
            }
            return hoseGW;
         }
      }

      private static HosePTConnector.PTConnectorWS hosePTGW;
      public static HosePTConnector.PTConnectorWS HosePTGW
      {
         get
         {
            if (hosePTGW == null)
            {
               hosePTGW = new HosePTConnector.PTConnectorWS();
               hosePTGW.Url = HOGW_PT_Dealer.Properties.Settings.Default.HosePTConnector_PTConnectorWS;
            }
            return hosePTGW;
         }
      }

      private static CoreConnector.CoreConnectorWS coreGW;
      public static CoreConnector.CoreConnectorWS CoreGW
      {
         get
         {
            if (coreGW == null)
            {
               coreGW = new CoreConnector.CoreConnectorWS();
               coreGW.Url = HOGW_PT_Dealer.Properties.Settings.Default.CoreConnector_CoreConnectorWS;
            }
            return coreGW;
         }
      }

      private static SBSGateway.CommonService sbsGW;
      public static SBSGateway.CommonService SBSGW
      {
         get
         {
            if (sbsGW == null)
            {
               sbsGW = new SBSGateway.CommonService();
               sbsGW.Url = HOGW_PT_Dealer.Properties.Settings.Default.SBSGateway_CommonService;
            }
            return sbsGW;
         }
      }

      private static SBSCommon.CommonService sbsCommonGW;
      public static SBSCommon.CommonService SBSCommonGW
      {
         get
         {
            if (sbsCommonGW == null)
            {
               sbsCommonGW = new SBSCommon.CommonService();
               sbsCommonGW.Url = HOGW_PT_Dealer.Properties.Settings.Default.SBSCommon_CommonService;
            }
            return sbsCommonGW;
         }
      }
   }

   public class PTBoardType
   {
      public PTBoardType(string boardName, string boardType)
      {
         BoardType = boardType;
         BoardName = boardType + " - " + boardName;
      }
      public string BoardName { get; set; }
      public string BoardType { get; set; }
   }
   public class PTStatus
   {
      public PTStatus(string status, string description)
      {
         Status = status;
         Description = status + " - " + description;
      }
      public string Status { get; set; }
      public string Description { get; set; }
   }
}
