using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("api/taxaJuros")]
    [ApiController]
    public class TaxaJurosController : Controller
    {
        private readonly TaxaJurosService _iTaxaJurosService;

        public TaxaJurosController(TaxaJurosService iTaxaJurosService)
        {
            _iTaxaJurosService = iTaxaJurosService;
        }

        [HttpGet]
        public IActionResult GetTaxaJuros()
        {
            decimal decTaxaJuros = _iTaxaJurosService.GetTaxaJuros();
            return Ok(decTaxaJuros);
        }
    }
}