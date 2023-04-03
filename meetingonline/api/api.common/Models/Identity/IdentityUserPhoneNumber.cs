namespace api.common.Models.Identity
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
