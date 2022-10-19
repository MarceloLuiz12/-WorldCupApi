using CopaDoMundo.Domain.Interfaces.Auxiliares;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Domain.Interfaces.Service;
using CopaDoMundo.Infra.Auxiliares;
using CopaDoMundo.Infra.Repository;
using CopaDoMundo.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDoMundo.InfraCrossCuting
{
    public static class CrossDependecy
    {
        public static IServiceCollection SetupDepencencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServices()
                    .ConfiguringRepositories()
                    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICopaDoMundoService, CopaDoMundoService>();

            return services;
        }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICopaDoMundoRepository, CopaDoMundoRepository>();

            return services;
        }

    }
}
