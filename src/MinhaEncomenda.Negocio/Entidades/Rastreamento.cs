using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Entidades
{
    public class Rastreamento
    {
        public string Versao { get; set; }
        public string Quantidade { get; set; }
        public string Pesquisa { get; set; }
        public string Resultado { get; set; }
        public IList<Objeto> Objeto { get; set; }

    }
}