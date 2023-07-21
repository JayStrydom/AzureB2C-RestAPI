
namespace PortalAuthenticationSample
{
    public class SampleUserValidationService : IUserValidationService
    {
        public async Task Validate(ValidationRequest request)
        {
            // TODO: Validate that the user is using an expected identity provider request.identityProvider
            // TODO: Check for duplicate users where the user was registered under a different identity provider

            if (request is null) throw new ArgumentNullException(nameof(request));
            var emailAddress = GetEmail(request);

            if (emailAddress == "fake@mailinator.com")
            {
                throw new ValidationException("Your user account does not exist. Please contract the support team.");
            }
        }

        private string GetEmail(ValidationRequest request)
        {
            // the email address is empty for the localUserAccount provider and we need to use the signInName instead
            var email = string.IsNullOrWhiteSpace(request.email) ? request.signInName : request.email;
            if (string.IsNullOrWhiteSpace(email)) throw new ValidationException("Missing required `email` element.");
            if (!email.Contains("@")) throw new ValidationException("An invalid `email` was specified.");
            return email;
        }
    }
}
