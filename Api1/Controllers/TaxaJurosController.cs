using Domain.Interfaces;
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
            decimal decTaxaJuros = iTaxaJurosService.GetTaxaJuros();
            return Ok(decTaxaJuros);
        }
    }
}