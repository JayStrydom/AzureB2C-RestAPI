using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PortalAuthenticationSample.Services
{
    public class Registrar
    {
        public void Register(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAuthenticationService, BasicAuthenticationService>(serviceProvider =>
            {               
                return new BasicAuthenticationService(config["AuthenticationUsername"], config["AuthenticationPassword"]);
            });

            services.AddScoped<IUserValidationService, SampleUserValidationService>();
            services.AddScoped<IClaimsService, SampleClaimsService>();
        }
    }
}