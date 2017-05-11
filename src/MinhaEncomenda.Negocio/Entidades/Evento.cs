using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.Negocio.Entidades
{
    public class Evento
    {
        public string Tipo { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Criacao { get; set; }
        public string Descricao { get; set; }
        public Unidade Unidade { get; set; }
        public IList<Destino> Destino { get; set; }
        public string cepDestino { get; set; }
        public string prazoGuarda { get; set; }
        public DateTime DataPostagem { get; set; }

    }
}
