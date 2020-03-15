using System.Threading.Tasks;
using Api2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [Route("calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly CalculaJurosService objCalcularJurosService;

        public CalculaJurosController(CalculaJurosService _objCalcularJurosService)
        {
            objCalcularJurosService = _objCalcularJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros([FromQuery]decimal decValorInicial, [FromQuery]int intMeses)
        {
            var resultado = await objCalcularJurosService.CalcularJuros(decValorInicial, intMeses);
            return Ok(resultado);
        }
    }
}