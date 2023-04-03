using CS.Application.Views.Custody;
using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Std;

namespace CS.Application.Services.Interfaces
{
    public class CustodyBusinessHandler : ICustodyBusinessHandler
    {

        public RequestPublishViewModel CreateViewModel(string businessId, CustodyRequestModel custodyRequestModel)
        {
            switch (businessId)
            {
                case BusinessIdProviderConstant.OpenOrCloseAccount:
                    return new VSD_1_1_DongMoTKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.CustodySecurities:
                    return new VSD_1_2_1_KyGuiCKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.WithdrawSecurities:
                    return new VSD_1_2_2_RutCKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.TransferSecurities:
                    return new VSD_1_3_ChuyenKhoanCKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.TransferRightToBuyAdditionalStock:
                    return new VSD_2_3_ChuyenNhuongQuyenViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.FinalSettlementAccount:
                    return new VSD_1_4_TatToanTKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.PlegingAndReleasingSecurities:
                    return new VSD_1_5_PhongToaGiaiToaCKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.LimitTransferChanges:
                case BusinessIdProviderConstant.LoggingAdditionalSecurities:
                case BusinessIdProviderConstant.ClearingAndSettlementConfirmation:
                case BusinessIdProviderConstant.SecuritiesBalanceConfirmation:
                case BusinessIdProviderConstant.AccountListConfirmation:
                case BusinessIdProviderConstant.TradingResultConfirmation:
                    return new VSD_1_8_XNSoDuCKViewModel(custodyRequestModel);

                case BusinessIdProviderConstant.ReportsRequested:
                    return new VSD_4_TraXuatBCViewModel(custodyRequestModel);
                case BusinessIdProviderConstant.RegisterRightToBuyAdditionalStock:
                    return new VSD_2_4_DKDatMuaViewModel(custodyRequestModel);

                default:
                    return null;
            }
        }

        public AccessRight RequiredAccessRight(string businessId)
        {
            switch (businessId)
            {
                case BusinessIdProviderConstant.OpenOrCloseAccount:
                    return AccessRight.DongMoTk;

                case BusinessIdProviderConstant.CustodySecurities:
                    return AccessRight.Kyguirutchungkhoan;

                case BusinessIdProviderConstant.WithdrawSecurities:
                    return AccessRight.Kyguirutchungkhoan;

                case BusinessIdProviderConstant.TransferSecurities:
                    return AccessRight.ChuyenKhoanCk;

                case BusinessIdProviderConstant.TransferRightToBuyAdditionalStock:
                    return AccessRight.ChuyenNhuongQuyen;

                case BusinessIdProviderConstant.FinalSettlementAccount:
                    return AccessRight.TatToanTk;

                case BusinessIdProviderConstant.PlegingAndReleasingSecurities:
                    return AccessRight.PhongToaGiaiToaCk;

                case BusinessIdProviderConstant.LimitTransferChanges:
                case BusinessIdProviderConstant.LoggingAdditionalSecurities:
                case BusinessIdProviderConstant.ClearingAndSettlementConfirmation:
                case BusinessIdProviderConstant.SecuritiesBalanceConfirmation:
                case BusinessIdProviderConstant.AccountListConfirmation:
                case BusinessIdProviderConstant.TradingResultConfirmation:
                    return AccessRight.TraXuatBc;

                case BusinessIdProviderConstant.ReportsRequested:
                    return AccessRight.CustodyReport;
                case BusinessIdProviderConstant.RegisterRightToBuyAdditionalStock:
                    return AccessRight.DkDatMua;

                default:
                    return AccessRight.DongMoTk;
            }
        }
    }
}
