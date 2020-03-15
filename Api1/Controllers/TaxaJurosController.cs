using Api1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly TaxaJurosService objTaxaJurosService;

        public TaxaJurosController(TaxaJurosService _objTaxaJurosService)
        {
            objTaxaJurosService = _objTaxaJurosService;
        }

        [HttpGet]
        public IActionResult GetTaxaJuros()
        {
            decimal decTaxaJuros = objTaxaJurosService.GetTaxaJuros();
            return Ok(decTaxaJuros);
        }
    }
}