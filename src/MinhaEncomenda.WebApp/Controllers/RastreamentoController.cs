using Microsoft.AspNetCore.Mvc;
using MinhaEncomenda.Negocio.Entidades;
using MinhaEncomenda.Negocio.Repositorio;
using MinhaEncomenda.WebApp.Controllers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MinhaEncomenda.WebApp.Controllers
{
  [Route("api/[controller]")]
  public class RastreamentoController : Controller
  {
    private readonly IRastreamentoRepository rastreamentoRepository;

    public RastreamentoController(IRastreamentoRepository rastreamentoRepository)
    {
      this.rastreamentoRepository = rastreamentoRepository;
    }


    [HttpGet("{codigo}")]
    public async Task<IActionResult> Obter(string codigo)
    {
      var rastreamento = await rastreamentoRepository.ObterRastreamento(codigo);

      var objeto = rastreamento.Objeto.FirstOrDefault();

      if (rastreamento == null || objeto == null || objeto.Evento == null)
        return ResultadoNaoEncontrado();

      var rastreamentos = objeto.Evento.Select(x => new RastreamentoViewModel
      {
        Numero = objeto.Numero,
        StatusEvento = x.Descricao,
        DescricaoEvento = PreparaTexto(x),
        Data = x.Data.ToString("dd/MM/yyyy"),
        Hora = x.Hora.ToString("hh:mm"),
        Cidade = x.Destino?.FirstOrDefault().Cidade ?? x.Unidade?.Cidade ?? ""
      });
      return Json(rastreamentos);
    }

    private string PreparaTexto(Evento evento)
    {
      if (evento.Destino == null)
        return $@"Em {evento.Unidade.Local}  </br> {evento.Unidade.Cidade} / {evento.Unidade.Uf}".ToUpper();

      return $@"de {evento.Unidade.TipoUnidade} em {evento.Unidade.Local} para {evento.Destino.FirstOrDefault().Local} / {evento.Destino.FirstOrDefault().Cidade} / {evento.Destino.FirstOrDefault().Uf}".ToUpper();
    }

    private IActionResult ResultadoNaoEncontrado()
    {
      Response.StatusCode = (int)HttpStatusCode.BadRequest;
      ModelState.AddModelError("RAST0001", "RAST0001");

      return Json(new { codigo = ModelState.SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).FirstOrDefault() });
    }
  }
}
