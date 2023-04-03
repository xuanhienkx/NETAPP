namespace DSoft.Common.Models.Identity
{
    public class IdentityUserToken
    {
        public string LoginProvider { get; set; }
        public string TokenName { get; set; }
        public string TokenValue { get; set; }
    }
}