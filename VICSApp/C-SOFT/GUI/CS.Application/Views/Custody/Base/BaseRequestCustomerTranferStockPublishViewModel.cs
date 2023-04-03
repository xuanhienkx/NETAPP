using CS.Application.Framework;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.Application.Views.Custody.Base
{
    public abstract class BaseRequestCustomerTranferStockPublishViewModel<T> : BaseRequestCustomerStockPublishViewModel<T> where T: Custody542TranferModel, new()
    {
        protected BaseRequestCustomerTranferStockPublishViewModel(CustodyRequestModel model) : base(model)
        {
            Model.ContentClrType = typeof(T).FullName;
        }

        protected override void RegisterContentModelChanged(T custody542)
        {
            custody542.EnablePropertyChange = true;
            custody542.AddOnPropertyChangeListener(() => custody542.SettlementType,
                                                   () => OnSettlementTypeChanged(custody542.SettlementType));
            //1f
            AddOnPropertyChangeListener(() => Receiver, () => OnReceiverChanged(custody542));
            AddOnPropertyChangeValidator(() => Receiver, () => ValidateReceiver(custody542)); 
            //2f
            custody542.AddOnPropertyChangeListener(() => custody542.ReceiverAccount,
                                                   () => OnReceiverAccountChanged(custody542));

        }

        private void OnReceiverAccountChanged(T custody542)
        {
            if (string.IsNullOrEmpty(custody542?.CustomerNumber) || custody542.ReceiverAccount?.Length < 3)
                return;

            var memberCode = custody542.ReceiverAccount?.Substring(0, 3);
            VsdMember = VsdMemberList.Current.GetMemberCode(memberCode);
            custody542.ReceiverBiccode = VsdMember?.BicCode;
        }

        private string ValidateReceiver(T custody542)
        {
            if (Receiver == null || string.IsNullOrEmpty(custody542.CustomerNumber))
                return null;

            return custody542.CustomerNumber.Equals(Receiver.CustomerNumber,
                StringComparison.InvariantCultureIgnoreCase)
                ? Translate("CustodyView_ReceiverAccount_Dulicate_Validation")
                : null;
        }

        private void OnReceiverChanged(T custody542)
        {
            custody542.ReceiverAccount = Receiver?.CustomerNumber;
        }


        private void OnSettlementTypeChanged(SettlementType type)
        {
            IsOneFirm = type == SettlementType.TransactionOnOneMember;
        }

        public VsdMember VsdMember { get => Get<VsdMember>(); set => Set(value); }

        public CustomerModel Receiver { get => Get<CustomerModel>(); set => Set(value); }
        public bool IsOneFirm { get => Get<bool>(); set => Set(value); }

        public override bool ContentModelValid =>
            Model.ContentModel != null && (Model.ContentModel is Custody542TranferModel m && m.IsValid);

        private static readonly IReadOnlyList<SettlementType> ExcludeList = new List<SettlementType>()
        {
            SettlementType.MoveAllStockAndCloseAcount,
            SettlementType.MoveAllStockAndNotCloseAcount
        };
        public EnumCollection<SettlementType> SettlementTypes { get; } = new EnumCollection<SettlementType>(ExcludeList);


        public override async Task LoadDataExtend(T model)
        {
            VsdMember = VsdMemberList.Current.GetMember(model.ReceiverBiccode);
            await base.LoadDataExtend(model);
        }

        public override T SetCustomerToContenModel(T model, CustomerModel customer)
        {
            model.CustomerName = Customer.FullNameLocal;
            model.CardIdentity = Customer.CardIdentity;
            model.CardType = Customer.CardType;
            model.CardIssuedDate = Customer.CardIssuedDate;
            model.ReceiverCompanyName = VsdMember.FullName;
            return model;
        } 
    }
}