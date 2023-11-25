using Domain.Interfaces;
using Domain.InterfacesServices;
using Domain.Services;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig.HelpStartup
{
    public static class HelpStartup
    {
        public static void ConfigureScoped(IServiceCollection services)
        {
            // Interfaces e Repositorios
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<ICategoria, RepositoryCategoria>();
            services.AddScoped<IDespesa, RepositoryDespesa>();
            services.AddScoped<ISistemaFinanceiro, RepositorySistemaFinanceiro>();
            services.AddScoped<IUsuarioSistemaFinanceiro, RepositoryUsuarioSistemaFinanceiro>();

            // Serviço  Dominio
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped<ISistemaFinanceiroService, SistemaFinanceiroService>();
            services.AddScoped<IUsuarioSistemaFinanceiroService, UsuarioSistemaFinanceiroService>();
        }
    }
}
