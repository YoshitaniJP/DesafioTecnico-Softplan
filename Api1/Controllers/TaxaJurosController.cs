using Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService objITaxaJurosService;

        public TaxaJurosController(ITaxaJurosService _objITaxaJurosService)
        {
            objITaxaJurosService = _objITaxaJurosService;
        }

        [HttpGet]
        public IActionResult GetTaxaJuros()
        {
            decimal decTaxaJuros = objITaxaJurosService.GetTaxaJuros();
            return Ok(decTaxaJuros);
        }
    }
}