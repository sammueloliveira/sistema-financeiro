using Domain.Interfaces;
using Domain.InterfacesServices;
using Domain.Services;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig.HelpStartup
{
     public static class HelpStartup
    {
        public static void ConfigureSingleton(IServiceCollection services)
        {
            // Interfaces e Repositorios
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddSingleton<ICategoria, RepositoryCategoria>();
            services.AddSingleton<IDespesa, RepositoryDespesa>();
            services.AddSingleton<ISistemaFinanceiro, RepositorySistemaFinanceiro>();
            services.AddSingleton<IUsuarioSistemaFinanceiro, RepositoryUsuarioSistemaFinanceiro>();

            // Serviço  Dominio
            services.AddSingleton<IServiceCategoria, ServiceCategoria>();
            services.AddSingleton<IServiceDespesa, ServiceDespesa>();
            services.AddSingleton<ISistemaFinanceiroService, SistemaFinanceiroService>();
            services.AddSingleton<IUsuarioSistemaFinanceiroService, UsuarioSistemaFinanceiroService>();
        }
    }
}
