namespace PortalAuthenticationSample
{
    public class SampleClaimsService : IClaimsService
    {
        public async Task<ClaimsResponse> GenerateClaims(ClaimsRequest request)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            var user = await GetUser(request).ConfigureAwait(false);
            return CreateClaimsResponse(user);
        }

        private ClaimsResponse CreateClaimsResponse(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            return new ClaimsResponse()
            {
                companyId = user.CompanyId,
                companyName = user.CompanyName,
                userId = user.UserId,
                roles = user.Roles == null ? "" : String.Join(",", user.Roles)
            };
        }

        private async Task<User> GetUser(ClaimsRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.objectId)) throw new ValidationException("Missing required `objectId` element.");
            var emailAddress = string.IsNullOrWhiteSpace(request.email) ? request.signInName : request.email;

            // TODO: Find the user by emailAddress or request.objectId
            var user = new User()
            {
                UserId = "user-123",
                CompanyId = "company-123-abc",
                CompanyName = "ABC Limited",
                IdentityProviderName = "amazon.com",
                Roles = new string[] { "customer_admin", "user_admin" }
            };

            // TODO: Validate that the user's account is active/enabled

            return user;
        }
    }
}
