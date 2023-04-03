using System.Runtime.Serialization;

namespace CS.Common.Contract.Enums
{
    public enum CustodyRequestStatus : byte
    {
        /// <summary>
        /// Request is publish to VSD gateway
        /// </summary>
        Published = 0,
        /// <summary>
        /// Request is publish to VSD gateway but an error occured while building the FIN message
        /// </summary>
        PublishedFailed = 1,
        /// <summary>
        /// Request is publish to VSD, receive ACK to confirm and waiting for aproval
        /// </summary>
        PendingProcess = 2,
        /// <summary>
        /// Request is reject by NAK message because of error
        /// </summary>
        FailureRejected = 3,
        /// <summary>
        /// The request is sent to VSD and a FIN message receive to reject the request
        /// </summary>
        RequestRejected = 4,
        /// <summary>
        /// Request approved by VSD but the process is not complete because of error
        /// </summary>
        ApprovalPending = 5,
        /// <summary>
        /// Request approved by VSD. This request is only be found in audit database
        /// </summary>
        Finished = 6  ,
        /// <summary>
        /// Response VSD  infomation
        /// </summary>
        ResponseInfo = 7,
        /// <summary>
        /// Response VSD  infomation
        /// </summary>
        ResponseReportInfo = 8
    }

    public enum MessagePriority : byte
    {
        /// <summary>
        /// Thông thường
        /// </summary>
        [EnumMember(Value = "N")] Normal = 2,
        /// <summary>
        /// Khẩn
        /// </summary>
        [EnumMember(Value = "U")] Urgent = 1
    }
    public enum CustodyRequestType : byte
    {
        [EnumMember(Value = "NEWM")] New = 0,
        [EnumMember(Value = "CANC")] Cancel = 1,
         Response = 2
    }
}
