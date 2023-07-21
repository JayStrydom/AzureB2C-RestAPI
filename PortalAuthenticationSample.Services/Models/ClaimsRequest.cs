namespace PortalAuthenticationSample
{
    public class ClaimsRequest
    {
        public string objectId { get; set; }
        public string email { get; set; }
        public string signInName { get; set; }
        public bool newUser { get; set; }
        public string identityProvider { get; set; }
        public string givenName { get; set; }
        public string surname { get; set; }
    }
}
