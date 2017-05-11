using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Entidades
{
    public class Endereco
    {
        public string Codigo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Bairro { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
