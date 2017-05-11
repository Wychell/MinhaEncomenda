using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaEncomenda.WebApp.Controllers.ViewModel
{
  public class RastreamentoViewModel
  {
    public string StatusEvento { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }
    public string Numero { get; set; }
    public string DescricaoEvento { get; set; }
    public string Cidade { get; set; }
  }
}
