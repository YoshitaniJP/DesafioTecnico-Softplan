using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService iTaxaJurosService;

        public TaxaJurosController(ITaxaJurosService _iTaxaJurosService)
        {
            iTaxaJurosService = _iTaxaJurosService;
        }

        [HttpGet]
        public IActionResult GetTaxaJuros()
        {
            TaxaJuros objTaxaJuros = iTaxaJurosService.GetTaxaJuros();
            if (objTaxaJuros == null)
                return BadRequest("Nenhuma taxa de juros cadastrado!");

            return Ok(objTaxaJuros.ValorTaxa);
        }
    }
}