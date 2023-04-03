namespace SMS.Common.Models
{
    public enum StatusSms
    {
        DangChoDuyet = 1,
        DangChoGui = 2,
        DangGui=3,
        BiTuChoi = 4,
        DaGuiXong = 5,
        DaBiXoa = 6,
        ThuNghiem=8
    }

    public enum CodeResult
    {
        RequestSuccess = 100,
        BrandnameInvalid = 104,
        MessageExisted = 124,
        NotAuthorize = 101,
        NotMoney = 101 
    }
}