using Microsoft.Extensions.DependencyInjection;
using Webmotors.Application.Interfaces;
using Webmotors.Application.Services;
using Webmotors.Domain.Interfaces.Gateway;
using Webmotors.Domain.Interfaces.Repository;
using Webmotors.Domain.Validators.AnuncioWebmotors;
using Webmotors.Gateway;
using Webmotors.Infraestructure;
using Webmotors.Infraestructure.Interfaces;
using Webmotors.Repository.Repositories;

namespace Webmotors.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IGatewayOnlineChallenge, GatewayOnlineChallenge>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnuncioWebmotorsRepository, AnuncioWebmotorsRepository>();
            services.AddScoped<IAnunciosWebmotorsService, AnunciosWebmotorsService>();

            RegisterValidators(services);

            return services;
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            services.AddScoped<CreateAnuncioWebmotorValidator>();
            services.AddScoped<UpdateAnuncioWebmotorValidator>();
        }
    }
}
