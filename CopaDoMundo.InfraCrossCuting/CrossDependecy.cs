﻿using CopaDoMundo.Domain.Interfaces.Api_terceiras;
using CopaDoMundo.Domain.Interfaces.Auxiliares;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Domain.Interfaces.Service;
using CopaDoMundo.Infra.Auxiliares;
using CopaDoMundo.Infra.Repository;
using CopaDoMundo.Infra.Repository.RepositoryAutenticacao;
using CopaDoMundo.Service;
using CopaDoMundo.Service.Rest;
using Microsoft.Extensions.DependencyInjection;

namespace CopaDoMundo.InfraCrossCuting
{
    public static class CrossDependecy
    {
        public static IServiceCollection SetupDepencencyInjection(this IServiceCollection services)
        {
            services.ConfigureServices()
                    .ConfiguringRepositories()
                    .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICopaDoMundoService, CopaDoMundoService>();
            services.AddTransient<IGerarTokenService, AutenticacaoService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            // services.AddTransient<IBancoService, BancoService>();
            services.AddTransient<IBrasilApi, BrasilApiRest>();

            services.AddAutoMapper(typeof(CrossMapper));

            return services;
        }

        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICopaDoMundoRepository, CopaDoMundoRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

    }
}
