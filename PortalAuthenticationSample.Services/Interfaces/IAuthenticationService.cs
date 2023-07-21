using Microsoft.AspNetCore.Http;

namespace PortalAuthenticationSample
{
    public interface IAuthenticationService
    {
        void Authenticate(HttpRequest req);
    }
}
