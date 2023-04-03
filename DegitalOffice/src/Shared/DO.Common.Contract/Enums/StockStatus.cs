namespace DO.Common.Contract.Enums
{
    public enum StockStatus
    {
        Normal = 0,//: Bình thường
        Holiday = 1,//Tạm ngưng giao dịch do ngày nghỉ 
        TopTrading = 2,//: Ngừng giao dịch
        Cancel = 6,//Hủy niêm yết
        NewTrading = 7,//Niêm yết mới
        PreCancel = 8,//Sắp hủy niêm yết
        Halted = 10,//Tạm ngừng giao dịch giữa phiên 
        SpecialTrading = 25//Giao dịch đặc biệt
    }
}