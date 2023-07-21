namespace PortalAuthenticationSample
{
    public class ResponseError
    {
        public string version { get; set; } = "1.0.1";
        public int status { get; set; } = 409;
        public string userMessage { get; set; }
    }
}
