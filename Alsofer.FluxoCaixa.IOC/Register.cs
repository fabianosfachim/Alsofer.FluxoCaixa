using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alsofer.FluxoCaixa.Application.Services;
using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Data;
using Alsofer.FluxoCaixa.Data.Helpers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Data.Repositories;
using Alsofer.FluxoCaixa.Data.Repositories.Entities;
using Alsofer.FluxoCaixa.Application;

namespace Alsofer.FluxoCaixa.IOC
{
    public static class Register
    {
        public static void RegisterDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            #region DependencyInjection

            //Services
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IContasPagarServices, ContasPagarServices>();
            services.AddScoped<IContasReceberServices, ContasReceberServices>();
            services.AddScoped<IDespesaServices, DespesaServices>();
            services.AddScoped<IFornecedorServices, FornecedorServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IReceitaServices, ReceitaServices>();
            services.AddScoped<IStatusServices, StatusServices>();
            services.AddScoped<IRelatorioFluxoCaixaDiarioServices, RelatorioFluxoCaixaDiarioServices>();

            //Repository//
            services.AddSingleton(typeof(IEntityRepository<>), typeof(EntityBaseRepository<>));

            //Entity
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContasPagarRepository, ContasPagarRepository>();
            services.AddScoped<IContasReceberRepository, ContasReceberRepository>();
            services.AddScoped<IDespesaRepository, DespesaRespository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IReceitaRepository, ReceitaRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            #endregion
        }
    }
}