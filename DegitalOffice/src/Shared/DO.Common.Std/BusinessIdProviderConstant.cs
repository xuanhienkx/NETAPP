using System.Collections.Generic;

namespace DO.Common.Std
{
    public static class BusinessIdProviderConstant
    {
        #region Fields

        public const string MessageId = "MessageId";

        public const string MessageType = "MessageType";
        public const string RequestType = "RequestType";
        public const string BusinessId = "BusinessId";
        public const string AcceptReject = "AcceptReject";
        public const string SessionInteger = "SessionInteger";
        public const string InputSequenceInteger = "InputSequenceInteger";
        public const string TransactionReferenceNumber = "OutReferenceNumber";
        public const string Proprietary = "Proprietary";
        public const string MessagePriority = "MessagePriority";
        public const string MessageFunction = "MessageFunction";
        public const string DeliveryMonitor = "DeliveryMonitor";
        public const string ReceiverBicode = "ReceiverBiccode";
        public const string VsdBicode = "VsdBiccode";
        public const string RequestDate = "RequestDate";
        public const string ConfirmCode = "ConfirmCode";
        public const string Rejected = "REJT";
        public const string Parameters = "Parameters";
        public const string ReportCode = "ReportCode";
        public const string ReportSetParam = "ReportSetParam";
        public const string CsvData = "Items";
        public const string FileName = "FileName";
        public const string MesssageConvererFilter = "MessageFilter";


        #endregion

        #region Business ids

        public const string OpenOrCloseAccount = "VSD_1_1_DongMoTK";
        public const string CustodySecurities = "VSD_1_2_1_KyGuiCK";
        public const string WithdrawSecurities = "VSD_1_2_2_RutCK";
        public const string LodggingAndRegisterSecurities = "VSD_1_2_3_KyGuiTP";
        public const string LoggingAdditionalSecurities = "VSD_1_2_4_KyGuiCKTuQuyen";
        public const string WithdrawByCancelledSecurities = "VSD_1_2_5_RutCKDoHuy";
        public const string TransferSecurities = "VSD_1_3_ChuyenKhoanCK";
        public const string FinalSettlementAccount = "VSD_1_4_TatToanTK";
        public const string PlegingAndReleasingSecurities = "VSD_1_5_PhongToaGiaiToaCK";
        public const string RevisingSecuritiesInfomation = "VSD_1_6_TBDieuChinhCK";
        public const string LimitTransferChanges = "VSD_1_7_TBThayDoiChuyenNhuong";
        public const string SecuritiesBalanceConfirmation = "VSD_1_8_XNSoDuCK";
        public const string RightInformation = "VSD_2_1_TBQuyen";
        public const string AccountListConfirmation = "VSD_2_2_XNDSThucHienQuyen";
        public const string TransferRightToBuyAdditionalStock = "VSD_2_3_ChuyenNhuongQuyen";
        public const string RegisterRightToBuyAdditionalStock = "VSD_2_4_DKDatMua";
        public const string TradingResultConfirmation = "VSD_3_1_XNKetQuaGD";
        public const string ClearingAndSettlementConfirmation = "VSD_3_2_TBKetQuaBuTru";
        public const string ClearingCompleteConfirmation = "VSD_3_3_TBThanhToanVoiTVLK";
        public const string ReportsRequested = "VSD_4_TraXuatBC";
        public const string InformNewRegistedStock = "VSD_5_1_TBCKMoi";
        public const string InformTransferStockBoard = "VSD_5_2_TBCKChuyenSan";
        public const string InformCancelledStock = "VSD_5_3_TBCKHuy";
        public const string InformIssuingProcedure = "VSD_5_4_TBDangKyBoSung";
        public const string SecuritiesReceverTransfer = "VSD_1_3_1_4_TBHT_TangTK_CNQ_TTTK";
        public const string WithdrawOffBoardSecurities = "UNKOWN";

        #endregion

        #region System Message Fields

        public const string RequestStatus = "requestStatus";
        public const string RejectionMessage = "ErrorMessage";

        public const string MessageRequestCommandPublished = "M";
        public const string MessageRequestCommandCancel = "C";
        public const string MessageRequestCommandFileInfo = "F";

        #endregion
        #region MarketInfo
        public const string MessageName = "MessageName";
        public const string UpdateType = "UpdateType";
        public const string MarketMessageConfig = "marketMessageConfig";
        public const string TradingDate = "TradingDate";
        public const string MarketPrs = "MarketPrs";
        #endregion

        public static int BufferSize = 2048;
    }

    public class VsdBranch
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public static IList<VsdBranch> Branches => new List<VsdBranch>()
        {
            new VsdBranch(){Code = "VSDSVN01", Name = "Trụ sở chính VSD tại Hà Nội"} ,
            new VsdBranch(){Code = "VSDSVN02", Name = "Chi nhánh VSD tại TP.HCM"}
        };
    }
}
