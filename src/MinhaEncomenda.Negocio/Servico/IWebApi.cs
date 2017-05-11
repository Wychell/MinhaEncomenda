using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Servico
{
   public interface IWebApi
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url,string codigo);
    }
}
