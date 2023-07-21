namespace PortalAuthenticationSample
{
    public interface IUserValidationService
    {
        Task Validate(ValidationRequest request);
    }
}
