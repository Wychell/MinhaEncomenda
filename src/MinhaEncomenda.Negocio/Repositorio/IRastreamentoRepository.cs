using MinhaEncomenda.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Repositorio
{
    public interface IRastreamentoRepository
    {
        Task<Rastreamento> ObterRastreamento(string codigo);
    }
}
