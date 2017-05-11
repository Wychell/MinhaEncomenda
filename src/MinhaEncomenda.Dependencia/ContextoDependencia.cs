using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MinhaEncomenda.Negocio.Servico;
using MinhaEncomenda.Dados.Servico;
using MinhaEncomenda.Negocio.Repositorio;
using MinhaEncomenda.Dados.Repositorio;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContext
    {

        public static void Configure(this IServiceCollection services)
        {
            services.AddSingleton<IWebApi, WebApp>();
            services.AddSingleton<IRastreamentoRepository, RastreamentoRepository>();
        }
    }
}
