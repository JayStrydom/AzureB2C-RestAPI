using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(PortalAuthenticationSample.Startup))]
namespace PortalAuthenticationSample
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Configuration
            var config = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                                 .AddEnvironmentVariables()
                                 .Build();
            builder.Services.AddSingleton<IConfiguration>(config);

            // Monitoring
            builder.Services.AddLogging();

            // Services
            var services = new Services.Registrar();
            services.Register(builder.Services, config);
        }
    }
}
