namespace DSoft.Common.Shared.Base
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
        public int StatusCode { set; get; }
        public ApiResult()
        {
        }
        public ApiResult(int statusCode, bool isSuccessed, string message = null)
        {
            Message = message;
            IsSuccessed = isSuccessed;
            StatusCode = statusCode;
        }

        public ApiResult(int statusCode, bool isSuccessed, T resultObj, string message = null)
        {
            ResultObj = resultObj;
            Message = message;
            IsSuccessed = isSuccessed;
            StatusCode = statusCode;
        }
    }
}
