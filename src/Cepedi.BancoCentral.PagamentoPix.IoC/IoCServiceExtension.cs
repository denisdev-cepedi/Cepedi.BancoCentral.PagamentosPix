using System.Diagnostics.CodeAnalysis;
using Cepedi.BancoCentral.PagamentoPix.Cache;
using Cepedi.BancoCentral.PagamentoPix.Compartilhado;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios.Queries;
using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Data.Repositories;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Handlers.Pipelines;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio.Queries;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Servicos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.BancoCentral.PagamentoPix.IoC
{
    [ExcludeFromCodeCoverage]
    public static class IoCServiceExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurarDbContext(services, configuration);

            services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExcecaoPipeline<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidacaoComportamento<,>));

            ConfigurarFluentValidation(services);

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IPixRepository, PixRepository>();
            services.AddScoped<ITransacaoPixRepository, TransacaoPixRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPessoaQueryRepository, PessoaQueryRepository>();

            // Cache Redis
            services.AddStackExchangeRedisCache(obj =>
            {
                obj.Configuration = configuration["Redis::Connection"];
                obj.InstanceName = configuration["Redis::Instance"];
            });

            services.AddSingleton<IDistributedCache, RedisCache>();
            services.AddScoped(typeof(ICache<>), typeof(Cache<>));
            // CacheRedis
        
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void ConfigurarFluentValidation(IServiceCollection services)
        {
            var abstractValidator = typeof(AbstractValidator<>);
            var validadores = typeof(IValida)
                .Assembly
                .DefinedTypes
                .Where(type => type.BaseType?.IsGenericType is true &&
                type.BaseType.GetGenericTypeDefinition() ==
                abstractValidator)
                .Select(Activator.CreateInstance)
                .ToArray();

            foreach (var validator in validadores)
            {
                services.AddSingleton(validator!.GetType().BaseType!, validator);
            }
        }

        private static void ConfigurarDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddDbContext<AlternativeDbContext>((sp, options) =>
            {
                //options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }
    }
}
