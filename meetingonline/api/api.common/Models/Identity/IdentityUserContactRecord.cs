using api.common.Shared;
using System;
using System.Diagnostics.CodeAnalysis;

namespace api.common.Models.Identity
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public abstract class IdentityUserContactRecord : IEquatable<IdentityUserEmail>
    {
        protected IdentityUserContactRecord()
        {
        }

        protected IdentityUserContactRecord(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("message", nameof(value));
            }

            Value = value;
        } 
        public string Value { get; set; }
        public Occurrence ConfirmationRecord { get; private set; }

        public bool IsConfirmed()
        {
            return ConfirmationRecord != null;
        }

        public void SetConfirmed()
        {
            SetConfirmed(new Occurrence());
        }

        public void SetConfirmed(Occurrence confirmationRecord)
        {
            if (ConfirmationRecord == null)
            {
                ConfirmationRecord = confirmationRecord;
            }
        }

        public void SetUnconfirmed()
        {
            ConfirmationRecord = null;
        }

        public bool Equals(IdentityUserEmail other)
        {
            return other.Value.Equals(Value);
        }
    }
}
