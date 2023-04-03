namespace DSoft.InforGateway.Helpers
{
    public class IdentityServerSettings
    {
        public string DiscoveryUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string ClientPassword { get; set; }
        public bool UseHttps { get; set; }
        public string Scope { get; set; }

    }
}
