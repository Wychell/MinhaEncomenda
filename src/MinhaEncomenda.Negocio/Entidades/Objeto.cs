using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Entidades
{
    public class Objeto
    {
        public string Numero { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public IList<Evento> Evento { get; set; }
    }
}
