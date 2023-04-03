using CS.Common.Contract.Enums;
using ProtoBuf;
using System;
using System.Text.RegularExpressions;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    [ProtoInclude(360, typeof(Custody542RightTranferModel))]
    public class Custody542TranferModel : Custody542Model
    {
        public Custody542TranferModel()
        {
            SettlementDate = DateTime.Now;
            SettlementType = SettlementType.TransactionWithOtherMember;
        }

        [ProtoMember(1)]
        public string ReceiverBiccode { get; set; }
        [ProtoMember(2)]
        public string ReceiverAccount { get => Get<string>(); set => Set(value); }
        [ProtoMember(3)]
        public string ReceiverCompanyName { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(ReceiverAccount), "CustodyModel_ReceiverAccount_Validation", () => !string.IsNullOrEmpty(ReceiverAccount));
            rules.Add(nameof(ReceiverAccount), "CustodyModel_ReceiverAccount_Dulicate_Validation", () => !string.IsNullOrEmpty(ReceiverAccount) && !ReceiverAccount.Equals(CustomerNumber, StringComparison.InvariantCultureIgnoreCase));
            rules.Add(nameof(ReceiverAccount), "CustodyModel_ReceverBiccode_Validation", () => !string.IsNullOrEmpty(ReceiverBiccode));
            base.SetupRules(rules);
        }
    }

    [ProtoContract]
    [Serializable]
    public class Custody542RightTranferModel : Custody542TranferModel
    {
        /// <summary>
        /// RightPandingRefNumber
        /// Sử dụng cho trường hợp lưu ký chứng khoán chờ giao dịch.
        /// Giá trị trường này lưu số hiệu tham chiếu của đợt sự kiện liên quan đến chứng khoán chờ giao dịch  
        /// </summary>
        [ProtoMember(1)]
        public string OrigTransferRef { get; set; }
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(OrigTransferRef), "CustodyModel_OrigTransferRef_Validation", () => !string.IsNullOrEmpty(OrigTransferRef));
            base.SetupRules(rules);
        }
    }
}