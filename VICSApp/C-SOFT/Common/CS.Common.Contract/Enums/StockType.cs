namespace CS.Common.Contract.Enums
{
    public enum StockType : byte
    {
        S = 0,//Stock
        D = 1,//Bond
        U = 2,//InestmentFund
        E = 3,//ETF Product,
        W = 4,//CW Product
    }

    public enum ReportType : byte
    {
        Info,
        Confirm
    }
    public enum ReportStatus : byte
    {
        Receive,
        RequestConfirm,
        Confirmed,
        Fineshed
    }
}