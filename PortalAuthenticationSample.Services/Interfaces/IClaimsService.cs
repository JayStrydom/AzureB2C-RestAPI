namespace PortalAuthenticationSample
{
    public interface IClaimsService
    {
        Task<ClaimsResponse> GenerateClaims(ClaimsRequest request);
    }
}
