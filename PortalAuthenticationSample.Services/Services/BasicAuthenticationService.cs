using Microsoft.AspNetCore.Http;
using System.Text;

namespace PortalAuthenticationSample
{
    public class BasicAuthenticationService : IAuthenticationService
    {
        private readonly string _username;
        private readonly string _password;

        public BasicAuthenticationService(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            _username = username;
            _password = password;
        }

        public void Authenticate(HttpRequest req)
        {
            if (req is null) throw new ArgumentNullException(nameof(req));
            string authorizationHeader = req.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Basic"))
            {
                throw new UnauthorizedAccessException("Authentication required.");
            }
                
            // Extracting credentials
            var encodedUsernamePassword = authorizationHeader.Substring("Basic ".Length).Trim(); 
            string usernamePassword = Encoding.GetEncoding("iso-8859-1")
                                              .GetString(Convert.FromBase64String(encodedUsernamePassword));

            var credentials = usernamePassword.Split(':');
            if (credentials.Length != 2) throw new UnauthorizedAccessException("Invalid credentials.");
            if (!_username.Equals(credentials[0]) && !_password.Equals(credentials[1])) throw new UnauthorizedAccessException("Invalid credentials.");
        }
    }
}
