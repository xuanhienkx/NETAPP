namespace DSoft.Common.Models.Identity
{
    public class IdentityUserPhoneNumber : IdentityUserContactRecord
    {
        public IdentityUserPhoneNumber()
        {
        }

        public IdentityUserPhoneNumber(string phoneNumber) : base(phoneNumber)
        {
        }
    }
}
