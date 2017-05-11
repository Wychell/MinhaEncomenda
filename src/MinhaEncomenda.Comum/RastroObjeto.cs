using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MinhaEncomenda.Comum
{
    public class RastroObjeto 
    {
        public string Usuario { get; private set ; }
        public string Senha { get; set; }
        public string Tipo { get; private set; }
        public string Resultado { get; private set; }
        public string Objetos { get; set; }
        public string Lingua { get; private set; }
        public string Token { get; private set; }

        public RastroObjeto(string objetos,string resultado)
        {
            Usuario = "MobileXect";
            Tipo = "L";
            Lingua= "101";
            Objetos = objetos;
            Resultado = resultado;
        }
    }
}
