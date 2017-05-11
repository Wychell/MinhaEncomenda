using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Entidades
{
    public class Unidade
    {
        public string Local { get; set; }
        public string Codigo { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Sto { get; set; }
        public string TipoUnidade { get; set; }
        public Endereco Endereco { get; set; }
    }
}
