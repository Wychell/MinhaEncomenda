using Microsoft.Extensions.Options;
using MinhaEncomenda.Comum.Compartilhado;
using MinhaEncomenda.Negocio.Entidades;
using MinhaEncomenda.Negocio.Repositorio;
using MinhaEncomenda.Negocio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MinhaEncomenda.Dados.Repositorio
{
    public class RastreamentoRepository : IRastreamentoRepository
    {
        private readonly IWebApi api;
        private readonly IOptions<AppSettings> configurcao;
        private string url;
        public RastreamentoRepository(IWebApi api, IOptions<AppSettings> configurcao)
        {
            this.api = api;
            this.configurcao = configurcao;
            url = configurcao.Value.Host + configurcao.Value.ApiRastreamento;
        }


        public async Task<Rastreamento> ObterRastreamento(string codigo)
        {
            try
            {
                return await api.PostAsync<Rastreamento>(url, codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
