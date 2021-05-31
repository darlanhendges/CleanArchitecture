using Microsoft.Extensions.DependencyInjection;
using Webmotors.Application.Automapper;

namespace Webmotors.Api.Configuration
{
    public  static class AutomapperConfig
    {
        public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CurrencyMapping).Assembly);

            return services;
        }
    }
}
